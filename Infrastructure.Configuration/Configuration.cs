using Infrastructure.Configuration.AbstractConfigs;
using Infrastructure.Configuration.SpecificConfigs;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

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

    [JsonConverter(typeof(StringEnumConverter))]
    public enum WebFetchType
    {
        AutomaticWebsite,
        Website,
        Api
    }
}
