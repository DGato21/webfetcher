using Data.Gateway.ABSWebsiteGateway.Model;

namespace Data.Gateway.ABSWebsiteGateway.Interfaces
{
    public interface IABSWebGateway
    {
        public Task<byte[]> FetchData(ABSWebGatewayRequest request);
    }
}
