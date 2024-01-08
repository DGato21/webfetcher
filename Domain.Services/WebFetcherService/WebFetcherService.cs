using Data.Gateway.ABSWebsiteGateway;
using Data.Gateway.ABSWebsiteGateway.Interfaces;
using Domain.Services.WebFetcherService.Interfaces;
using Domain.Services.WebFetcherService.Model;

namespace Domain.Services.WebFetcherService
{
    //DEPRECATEAD
    public class WebFetcherService : IWebFetcherService
    {
        private IABSWebGateway absWebGateway;

        public WebFetcherService()
        {
            this.absWebGateway = new ABSWebGateway();
        }

        public Task<byte[]> FetchABSWebsiteFile(ABSWebsiteRequestDto absWebsiteRequestDto)
        {
            return this.absWebGateway.FetchData(absWebsiteRequestDto.ToABSWebsiteRequestDto());
        }

        //Example of the intent of this Service: a orchestrator for calling multiple Websites
        public Task FetchOtherWebsiteFile()
        {
            throw new NotImplementedException();
        }
    }
}
