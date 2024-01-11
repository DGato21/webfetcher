using Infrastructure.Configuration.AbstractConfigs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Infrastructure.Configuration.JsonSerializerHelper
{
    public class BaseSpecifiedConcreteClassConverter : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (typeof(ABaseConfiguration).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
            return base.ResolveContractConverter(objectType);
        }
    }

    public class ABaseConfigurationConverter : JsonConverter
    {
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new BaseSpecifiedConcreteClassConverter() };

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ABaseConfiguration);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            WebFetchType fetchType;
            if (!Enum.TryParse<WebFetchType>(jo["FetchType"].ToString(), out fetchType))
                throw new Exception("Invalid type of configuration fetch type");

            switch (fetchType)
            {
                case WebFetchType.AutomaticWebsite:
                    return JsonConvert.DeserializeObject<WebsiteAutoConfiguration>(jo.ToString(), SpecifiedSubclassConversion);
                case WebFetchType.Website:
                    return JsonConvert.DeserializeObject<WebsiteConfiguration>(jo.ToString(), SpecifiedSubclassConversion);
                case WebFetchType.Api:
                    return JsonConvert.DeserializeObject<ApiFetchConfiguration>(jo.ToString(), SpecifiedSubclassConversion);
            }
            throw new NotImplementedException();
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
