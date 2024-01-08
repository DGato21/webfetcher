using Data.Gateway.GenericWebsiteGateway.Model;
using Infrastructure.Configuration;

namespace Domain.DTO.Mappers
{
    public static class WebsiteFetcherMapper
    {
        public static WebsiteGatewayRequest ToWebsiteGatewayRequest(WebsiteAutoConfiguration websiteConfiguration)
        {
            return new WebsiteGatewayRequest()
            {
                Url = websiteConfiguration.MainPageURL
                //relativeUrl comes from each section
            };
        }

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
