using Application.Core.ApiFetchApplication.Interface;
using Domain.Core.ApiFetcher;
using Domain.Core.WebsiteFetcher;
using Infrastructure.Configuration;
using Infrastructure.Configuration.AbstractConfigs;

namespace Application.Core.ApiFetchApplication
{
    public class ApiFetchApplication : IApiFetchApplication
    {
        public ApiFetchApplication()
        {

        }

        public Task FetchApiList(IList<ABaseConfiguration> configurationList)
        {
            try
            {
                foreach (var websiteRequest in configurationList)
                {
                    Guid idempontencyKey = new Guid();
                    ApiFetcher fetcher = new ApiFetcher(websiteRequest);
                    fetcher.FetchApi(idempontencyKey);
                }
                return Task.CompletedTask;
            }
            catch (Exception ex) { return Task.CompletedTask; }
        }
    }
}
