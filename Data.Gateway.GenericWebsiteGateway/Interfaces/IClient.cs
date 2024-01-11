namespace Data.Gateway.GenericWebsiteGateway.Interfaces
{
    public interface IClient
    {
        public Task<string> FetchWebpageAsync(string url);

        public Task<byte[]> FetchFileAsync(string url);
    }
}
