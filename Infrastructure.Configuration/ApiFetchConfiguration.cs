using Infrastructure.Configuration.AbstractConfigs;
using Infrastructure.Configuration.Auxiliar;

namespace Infrastructure.Configuration
{
    public class ApiFetchConfiguration : ABaseConfiguration
    {
        public string ApiName { get; set; }

        public IList<ApiParameters> ApiRequests { get; set; }
    }

    public class ApiParameters : FileFetchConfiguration
    {
        public string Endpoint { get; set; }

        public string Parameters_GET { get; set; }
    }
}
