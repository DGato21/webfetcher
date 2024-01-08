using Infrastructure.Configuration.AbstractConfigs;
using Infrastructure.Configuration.Auxiliar;

namespace Infrastructure.Configuration
{
    public class WebsiteAutoConfiguration : ABaseConfiguration
    {
        public readonly WebFetchType FetchType = WebFetchType.AutomaticWebsite;

        //In WebsiteAutoConfiguration, the Relative URL should belong to it "Section"/"Page" to fetch

        public IList<AutomaticSectionFetch> PageList { get; set; }
    }
}
