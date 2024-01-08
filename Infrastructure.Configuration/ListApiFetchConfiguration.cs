namespace Infrastructure.Configuration
{
    public class ListApiFetchConfiguration
    {
        public string ApiName { get; set; }

        public IList<ApiFetchConfiguration> ApiFetchConfigurations { get; set; }
    }
}
