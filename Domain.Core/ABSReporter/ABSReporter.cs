using Domain.Services.WebFetcherService.Interfaces;
using Infrastructure.Configuration.SpecificConfigs;
using Infrastructure.CrossCutting;

namespace Domain.Core.ABSReporter
{
    public class ABSReporter
    {
        private readonly ABSGatewayConfiguration configuration;
        private readonly IWebFetcherService webFetcherService;

        public ABSReporter(ABSGatewayConfiguration configuration, IWebFetcherService webFetcherService)
        {
            this.configuration = configuration;
            this.webFetcherService = webFetcherService;
        }

        public async Task<Boolean> GenerateReport()
        {
            try
            {
                //Go to WebFetcherService to Get the Data Needed from Web & Use FileHandlerService to Write the File
                Console.WriteLine($"Domain.Core.ABSReporter: Fetching Website for the excel file.");
                byte[] data = await this.webFetcherService.FetchABSWebsiteFile(this.configuration.ToABSWebsiteRequestDto());
                string filePath = FileHandler.SaveFile(this.configuration.DownloadFileFolder, this.configuration.MainFileName, data);

                //Go to ExcelService to Arrange the Data Needed
                Console.WriteLine($"Domain.Core.ABSReporter: Loading excel, transversing it and building the output file.");
                var fileDT = FileHandler.LoadFileInMemory(filePath, this.configuration.FILE_TABLE_SHEET);
                var transversedDT = FileHandler.TransverseFile(fileDT);
                IEnumerable<string> csvData = FileHandler.TransformDataTableToCsv(transversedDT, configuration.DateStringFormat);

                string csvFilePath = FileHandler.SaveFile(this.configuration.OutputFileFolder, this.configuration.OutputFileName, csvData);

                return true;
            }
            catch (Exception ex) { Console.WriteLine("Domain.ABSReporter: Error when generating ABSReporter."); return false; }

        }
    }
}
