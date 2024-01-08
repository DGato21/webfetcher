using Infrastructure.Configuration;
using Infrastructure.Configuration.AbstractConfigs;

namespace Application.Core.ApiFetchApplication.Interface
{
    public interface IApiFetchApplication
    {
        public Task FetchApiList(IList<ABaseConfiguration> configurationList);
    }
}
