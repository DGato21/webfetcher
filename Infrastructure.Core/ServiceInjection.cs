using Data.Gateway.GenericWebsiteGateway;
using Data.Gateway.GenericWebsiteGateway.Interfaces;
using Domain.Services.WebFetcherService;
using Domain.Services.WebFetcherService.Interfaces;

namespace Infrastructure.Core
{
    public static class ServiceInjection
    {
        public static void LoadServices(out IWebFetcherService webFetcherService)
        {
            webFetcherService = new WebFetcherService();
        }

        public static void LoadServices(out IWebFetcherService webFetcherService,
            out IGenericWebsiteGateway websiteGateway)
        {
            webFetcherService = new WebFetcherService();
            websiteGateway = new GenericWebsiteGateway();
        }
    }
}
