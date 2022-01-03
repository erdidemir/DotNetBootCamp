namespace PosIntegration.Model.RedirectUrl
{
    public class RedirectUrlResponse
    {
        public RedirectUrlResponse(string url, string rawBody)
        {
            Url = url;
            RawBody = rawBody;
        }

        public string Url { get; set; }
        public string RawBody { get; set; }
    }
}