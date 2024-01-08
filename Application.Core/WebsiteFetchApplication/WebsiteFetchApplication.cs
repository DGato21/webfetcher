using Application.Core.WebsiteFetchApplication.Interface;
using Data.Gateway.GenericWebsiteGateway.Interfaces;
using Domain.Core.WebsiteFetcher;
using Domain.Services.WebFetcherService.Interfaces;
using Infrastructure.Configuration.AbstractConfigs;
using Infrastructure.Core;

namespace Application.Core.WebsiteFetchApplication
{
    public class WebsiteFetchApplication : IWebsiteFetchApplication
    {
        private readonly IWebFetcherService webFetcherService;
        private readonly IGenericWebsiteGateway websiteGateway;

        public WebsiteFetchApplication()
        {
            ServiceInjection.LoadServices(out this.webFetcherService, out this.websiteGateway);
        }

        public Task FetchWebsiteList(IList<ABaseConfiguration> configurationList)
        {
            try
            {
                /*
                 * TODO: Transform this into a Parallel.Foreach
                 * -> For each website request, open a Task to fetch the website in a parallel way
                 * -> Check how we can handle the webFetcherService: because maybe it should be individual for each
                 * or it can be the same resource shared for all, using the lock to lock the use of this service
                 * and the remaining tasks for each of the requests should be done in a parallel way
                 */

                foreach (var websiteRequest in configurationList)
                {
                    Guid idempontencyKey = new Guid();
                    WebsiteFetcher fetcher = new WebsiteFetcher(websiteRequest, this.webFetcherService, this.websiteGateway);
                    fetcher.FetchWebsite(idempontencyKey);
                }

                return Task.CompletedTask;
            }
            catch (Exception ex) { return Task.CompletedTask; }
        }
    }
}
