namespace Domain.DTO
{
    public abstract class FetchResultDTO
    {
        public string Id { get; set; }
        public string RequestId { get; set; }
        public Guid RequestIdempotencyId { get; set; }
    }

    public class ApiResultDTO : FetchResultDTO
    {
        public string json { get; set; }
    }

    public class FileResultDTO : FetchResultDTO
    {
        public FileResultDTO(byte[] data, string outputFolder, string outputFile, string outputFileExtension)
        {
            this.data = data;
            this.OutputFolder = outputFolder;
            this.OutputFile = outputFile;
            this.OutputFileExtension = outputFileExtension;
        }

        public byte[] data { get; set; }
        public string OutputFolder { get; set; }
        public string OutputFile { get; set; }
        public string OutputFileExtension { get; set; }
    }

    public class HtmlResultDTO : FetchResultDTO
    {
        public HtmlResultDTO(string html)
        {
            this.html = html;
        }

        public string html { get; set; }
    }
}
