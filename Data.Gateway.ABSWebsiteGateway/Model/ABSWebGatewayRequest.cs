namespace Data.Gateway.ABSWebsiteGateway.Model
{
    public class ABSWebGatewayRequest
    {
        public string MainPageBaseURL { get; set; }
        public string MainPageRelativeURL { get; set; }
        public string DownloadFileFolder { get; set; }

        public string SECTION_MAINPAGE_FILTER { get; set; }
        public string SECTION_MAINPAGE_HREFDIV { get; set; }

        public string SECTION_DATAPAGE_FILTER { get; set; }
        public string SECTION_DATAPAGE_HREFDIV { get; set; }
    }
}
