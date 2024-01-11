namespace Data.Gateway.GenericWebsiteGateway.Model
{
    public class WebsiteGatewayRequest
    {
        public string Url { get; set; }
        public string RelativeUrl { get; set; }

        public string GetRequestURL() { return this.Url + this.RelativeUrl; }
    }
}
