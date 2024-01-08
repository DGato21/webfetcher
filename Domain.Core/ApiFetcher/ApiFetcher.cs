using Infrastructure.Configuration.AbstractConfigs;

namespace Domain.Core.ApiFetcher
{
    public class ApiFetcher
    {
        private readonly ABaseConfiguration configuration;

        public ApiFetcher(ABaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task FetchApi(Guid requestGuid)
        {
            return Task.CompletedTask;
        }

        private void ApiLogin()
        {

        }

        private void ApiEndpoint()
        {

        }
    }
}
