using Data.Gateway.ABSWebsiteGateway.Interfaces;

namespace Data.Gateway.ABSWebsiteGateway
{
    public class Client : IClient
    {
        private HttpClient httpClient;

        public Client()
        {
            this.httpClient = new HttpClient();
            SetHttpClientDefautlHeaders();
        }

        //TODO: Improve the part of Async with await (check why it's not working)

        public async Task<string> FetchWebpage(string url)
        {
            try
            {
                var response = await this.httpClient.GetStringAsync(url).ConfigureAwait(false);

                return response;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<byte[]> FetchFile(string url)
        {
            try
            {
                var response = await this.httpClient.GetByteArrayAsync(url).ConfigureAwait(false);

                return response;
            }
            catch (Exception ex) { throw ex; }
        }

        private void SetHttpClientDefautlHeaders()
        {
            this.httpClient.DefaultRequestHeaders.Add("User-Agent", "Other");
        }
    }
}
