namespace Data.Gateway.ABSWebsiteGateway.Interfaces
{
    public interface IClient
    {
        public Task<string> FetchWebpage(string url);

        public Task<byte[]> FetchFile(string url);
    }
}
