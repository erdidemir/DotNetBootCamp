using PosIntegration.Model.Common;

namespace PosIntegration.Model.Auth
{
    public class AuthRequest
    {
        public string ReferenceNumber { get; set; }
        public PosCredential PosCredential { get; set; }

        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public string CVV { get; set; }

    }
}