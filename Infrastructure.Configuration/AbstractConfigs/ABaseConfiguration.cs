using Infrastructure.Configuration.JsonSerializerHelper;
using System.Text.Json.Serialization;

namespace Infrastructure.Configuration.AbstractConfigs
{

    /// <summary>
    /// Base Configuration interface to encapsulate all the configurations available in a single interface type
    /// </summary>
    /// 
    [JsonConverter(typeof(ABaseConfigurationConverter))]
    public abstract class ABaseConfiguration
    {
        public string MainPageURL { get; set; }

        public readonly WebFetchType FetchType;
    }
}
