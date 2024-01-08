using ExcelDataReader;
using System.Data;
using System.Globalization;

namespace Infrastructure.CrossCutting
{
    public static class FileHandler
    {
        public static DataTable LoadFileInMemory(string filePath, string sheetName)
        {
            DataTable? outputDT = null;

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader;

                try
                {
                    reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);
                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true,
                            ReadHeaderRow = rowReader =>
                            {
                                rowReader.Read(); rowReader.Read(); rowReader.Read();
                                rowReader.Read(); rowReader.Read(); rowReader.Read();
                                rowReader.Read(); rowReader.Read(); rowReader.Read();
                            }
                        },

                    };

                    //TODO: See how to filter at loading time the DataSet
                    var dataSet = reader.AsDataSet(conf);

                    outputDT = dataSet.Tables[sheetName];
                }
                catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            }

            return outputDT;
        }

        public static DataTable TransverseFile(DataTable originalDT)
        {
            DataTable? output = new DataTable();

            // Add columns by looping rows

            // Header row's first column is same as in inputTable
            output.Columns.Add(originalDT.Columns[0].ColumnName.ToString());

            // Header row's second column onwards, 'inputTable's first column taken
            foreach (DataRow inRow in originalDT.Rows)
            {
                string newColName = inRow[0].ToString();
                output.Columns.Add(newColName);
            }

            // Add rows by looping columns        
            for (int rCount = 1; rCount <= originalDT.Columns.Count - 1; rCount++)
            {
                DataRow newRow = output.NewRow();

                // First column is inputTable's Header row's second column
                newRow[0] = originalDT.Columns[rCount].ColumnName.ToString();
                for (int cCount = 0; cCount <= originalDT.Rows.Count - 1; cCount++)
                {
                    string colValue = originalDT.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }
                output.Rows.Add(newRow);
            }

            return output;
        }

        public static IEnumerable<string> TransformDataTableToCsv(DataTable datatable, string? datetimeFormat = null)
        {
            IList<string> output = new List<string>();

            IEnumerable<string> columnNames = datatable.Columns.Cast<DataColumn>().
                                              Select(column =>
                                              datetimeFormat != null
                                              ? _transformDateTime(column.ColumnName, datetimeFormat)
                                              : column.ColumnName);
            output.Add(string.Join(",", columnNames));

            foreach (DataRow row in datatable.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                output.Add(string.Join(",", fields));
            }

            return output;
        }

        public static string SaveFile(string downloadFileFolder, string fileName, byte[] data)
        {
            string filePath = _baseSaveFile(downloadFileFolder, fileName);
            File.WriteAllBytes(filePath, data);

            return filePath;
        }

        public static string SaveFile(string downloadFileFolder, string fileName, IEnumerable<string> data)
        {
            string filePath = _baseSaveFile(downloadFileFolder, fileName);
            File.WriteAllLines(filePath, data);

            return filePath;
        }

        private static string _baseSaveFile(string downloadFileFolder, string fileName)
        {
            //Save file
            string mainSolutionFolder = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string fileDir = Path.Combine(mainSolutionFolder, downloadFileFolder);
            string filePath = Path.Combine(fileDir, fileName);

            Directory.CreateDirectory(fileDir);
            if (File.Exists(filePath)) File.Delete(filePath);

            return filePath;
        }

        private static string _transformDateTime(string str, string datetimeFormat)
        {
            DateTime dt;

            bool succeed = DateTime.TryParse(str, DateTimeFormatInfo.InvariantInfo, out dt);

            if (succeed)
                return dt.ToString(datetimeFormat);
            else
                return str;
        }
    }
}
