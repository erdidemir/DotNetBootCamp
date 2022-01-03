using PosIntegration.Model.Common;

namespace PosIntegration.Model.RedirectUrl
{
    public class RedirectUrlRequest
    {
        public PosCredential PosCredential { get; set; }

        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public string ReferenceNumber { get; set; }
        public string CountryCode { get; set; }
        public string CallbackUrl { get; set; }
    }
}