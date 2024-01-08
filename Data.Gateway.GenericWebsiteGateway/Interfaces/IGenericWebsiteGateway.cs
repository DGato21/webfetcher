using Data.Gateway.GenericWebsiteGateway.Model;

namespace Data.Gateway.GenericWebsiteGateway.Interfaces
{
    public interface IGenericWebsiteGateway
    {
        public Task<string> FetchHtml(WebsiteGatewayRequest request);
        public Task<byte[]> FetchFile(WebsiteGatewayRequest request);
    }
}
