using Domain.Services.WebFetcherService.Model;

namespace Domain.Services.WebFetcherService.Interfaces
{
    public interface IWebFetcherService
    {
        public Task<byte[]> FetchABSWebsiteFile(ABSWebsiteRequestDto aBSWebsiteRequestDto);

        //Example of another use of the service for other website/service
        public Task FetchOtherWebsiteFile();
    }
}
