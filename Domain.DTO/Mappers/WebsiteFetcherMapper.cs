using Data.Gateway.GenericWebsiteGateway.Model;
using Infrastructure.Configuration;
using Infrastructure.Configuration.Auxiliar;

namespace Domain.DTO.Mappers
{
    public static class WebsiteFetcherMapper
    {
        public static WebsiteGatewayRequest ToWebsiteGatewayRequest(WebsiteAutoConfiguration websiteConfiguration, 
            AutomaticSectionFetch section)
        {
            return new WebsiteGatewayRequest()
            {
                Url = websiteConfiguration.MainPageURL,
                //relativeUrl comes from each section
                RelativeUrl = section.RelativeURL
            };
        }

        //TODO: RelativeURL mapping might be a problem because the variable is acessible and might not be mapped
        public static WebsiteGatewayRequest ToWebsiteGatewayRequest(WebsiteConfiguration websiteConfiguration)
        {
            return new WebsiteGatewayRequest()
            {
                Url = websiteConfiguration.MainPageURL,
                RelativeUrl = websiteConfiguration.RelativeURL
            };
        }
    }
}
