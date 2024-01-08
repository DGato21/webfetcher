using Data.Gateway.ABSWebsiteGateway.Interfaces;
using Data.Gateway.ABSWebsiteGateway.Model;
using Infrastructure.CrossCutting;

namespace Data.Gateway.ABSWebsiteGateway
{
    public class ABSWebGateway : IABSWebGateway
    {
        private readonly Client client;

        public ABSWebGateway()
        {
            this.client = new Client();
        }

        public async Task<byte[]> FetchData(ABSWebGatewayRequest request)
        {
            //Connect to First Main Page
            Console.WriteLine($"ABSWebGateway.FetchData: Fetching from {request.MainPageRelativeURL}");
            string mainPageRequestUrl = request.MainPageBaseURL + request.MainPageRelativeURL;
            string mainPageContent = await this.client.FetchWebpage(mainPageRequestUrl);

            string secondPageLink = WebPageSniffer.SearchURLFromContentDivAndClass(mainPageContent, request.SECTION_MAINPAGE_FILTER, request.SECTION_MAINPAGE_HREFDIV);
            string secondPageUrl = request.MainPageBaseURL + secondPageLink;

            //Connect To Second Page
            Console.WriteLine($"ABSWebGateway.FetchData: Fetching from {secondPageUrl}");
            string secondPageContent = await this.client.FetchWebpage(secondPageUrl);

            //Get the Excel URL
            string excelFileLink = WebPageSniffer.SearchURLFromContentAElementAndAriaLabel(secondPageContent, request.SECTION_DATAPAGE_FILTER, request.SECTION_DATAPAGE_HREFDIV);
            string excelFileUrl = request.MainPageBaseURL + excelFileLink;

            //Download Excel
            Console.WriteLine($"ABSWebGateway.FetchData: Downlading excel from {excelFileUrl}");
            byte[] excelFile = await this.client.FetchFile(excelFileUrl);

            return excelFile;
        }
    }
}
