using Data.Gateway.ABSWebsiteGateway.Model;

namespace Domain.Services.WebFetcherService.Model
{
    public class ABSWebsiteRequestDto
    {
        public string MainPageBaseURL { get; set; }
        public string MainPageRelativeURL { get; set; }
        public string DownloadFileFolder { get; set; }

        public string SECTION_MAINPAGE_FILTER { get; set; }
        public string SECTION_MAINPAGE_HREFDIV { get; set; }

        public string SECTION_DATAPAGE_FILTER { get; set; }
        public string SECTION_DATAPAGE_HREFDIV { get; set; }

        public ABSWebGatewayRequest ToABSWebsiteRequestDto()
        {
            return new ABSWebGatewayRequest
            {
                DownloadFileFolder = this.DownloadFileFolder,
                MainPageBaseURL = this.MainPageBaseURL,
                MainPageRelativeURL = this.MainPageRelativeURL,
                SECTION_MAINPAGE_FILTER = this.SECTION_MAINPAGE_FILTER,
                SECTION_MAINPAGE_HREFDIV = this.SECTION_MAINPAGE_HREFDIV,
                SECTION_DATAPAGE_FILTER = this.SECTION_DATAPAGE_FILTER,
                SECTION_DATAPAGE_HREFDIV = this.SECTION_DATAPAGE_HREFDIV
            };
        }
    }
}
