using Infrastructure.Configuration;
using Infrastructure.Configuration.AbstractConfigs;

namespace Application.Core.WebsiteFetchApplication.Interface
{
    public interface IWebsiteFetchApplication
    {
        public Task FetchWebsiteList(IList<ABaseConfiguration> configurationList);
    }
}
