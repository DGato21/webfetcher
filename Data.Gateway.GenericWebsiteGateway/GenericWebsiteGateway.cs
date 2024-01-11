using Data.Gateway.GenericWebsiteGateway.Interfaces;
using Data.Gateway.GenericWebsiteGateway.Model;

namespace Data.Gateway.GenericWebsiteGateway
{
    public class GenericWebsiteGateway : IGenericWebsiteGateway
    {
        private readonly Client client;

        public GenericWebsiteGateway()
        {
            this.client = new Client();
        }

        public Task<string> FetchHtml(WebsiteGatewayRequest request)
        {
            return this.client.FetchWebpageAsync(request.GetRequestURL());
        }

        public Task<byte[]> FetchFile(WebsiteGatewayRequest request)
        {
            return this.client.FetchFileAsync(request.GetRequestURL());
        }
    }
}
