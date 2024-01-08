using Infrastructure.Configuration.AbstractConfigs;

namespace Infrastructure.Configuration.Auxiliar
{
    public class AutomaticSectionFetch
    {
        /// <summary>
        /// Relative URL to Fetch. Might be nullable in case of [receiveRelativeUrlFromPreviousSection]=true,
        /// meaning that this URL is completed according to the output of the last AutomaticSectionFetch
        /// </summary>
        public string? RelativeURL { get; set; }

        public SectionFetch Section { get; set; }
        public FileFetchConfiguration FileFetch { get; set; }

        /// <summary>
        /// Meaning that this section has the intent to serve has a redirect information to another website
        /// </summary>
        public bool isRedirect { get; set; }

        /// <summary>
        /// Meaning that this section should be saved in the response
        /// </summary>
        public bool saveContent { get; set; }

        /// <summary>
        /// Meaning that this section should receive it's relative URL from it's previous caller
        /// </summary>
        public bool receiveRelativeUrlFromPreviousSection { get; set; }
    }
}
