using Infrastructure.Configuration.AbstractConfigs;
using Infrastructure.Configuration.SpecificConfigs;

namespace Infrastructure.Configuration
{
    public class Configuration
    {
        //TODO: Automatic Deserializer according to the type

        public ABSGatewayConfiguration absGatewayConfiguration { get; set; }

        public IList<ABaseConfiguration> configurationList { get; set; }

        public Configuration()
        {
            this.absGatewayConfiguration = new ABSGatewayConfiguration();
            this.configurationList = new List<ABaseConfiguration>();
        }
    }

    public enum WebFetchType
    {
        AutomaticWebsite,
        Website,
        Api
    }
}
