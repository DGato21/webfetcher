using Infrastructure.Configuration.AbstractConfigs;
using Infrastructure.Configuration.Auxiliar;

namespace Infrastructure.Configuration
{
    public class WebsiteConfiguration : ABaseConfiguration
    {
        public readonly WebFetchType FetchType = WebFetchType.Website;

        public string RelativeURL { get; set; }

        /// <summary>
        /// If SectionFetch is not nullable, means that we want to fetch a single part of the website
        /// </summary>
        public SectionFetch? SectionToFetch { get; set; }

        /// <summary>
        /// If FileFetch is not nullable, means that we want to fetch a file from the site
        /// </summary>
        public FileFetchConfiguration? FileFetch { get; set; }
    }
}
