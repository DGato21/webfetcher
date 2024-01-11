using Data.Gateway.GenericWebsiteGateway.Interfaces;

namespace Data.Gateway.GenericWebsiteGateway
{
    public class Client : IClient
    {
        private HttpClient httpClient;

        public Client()
        {
            httpClient = new HttpClient();
            SetHttpClientDefautlHeaders();
        }

        //TODO: Improve the part of Async with await (check why it's not working)

        public async Task<string> FetchWebpageAsync(string url)
        {
            try
            {
                var response = this.httpClient.GetStringAsync(url).ConfigureAwait(false);
                var result = response.GetAwaiter().GetResult();

                return result;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<byte[]> FetchFileAsync(string url)
        {
            try
            {
                var response = this.httpClient.GetByteArrayAsync(url).ConfigureAwait(false);
                var result = response.GetAwaiter().GetResult();

                return result;
            }
            catch (Exception ex) { throw ex; }
        }

        private void SetHttpClientDefautlHeaders()
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Other");
        }
    }
}
