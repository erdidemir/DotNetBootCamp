using PosIntegration.Model.Common;

namespace PosIntegration.Model.Refund
{
    public class RefundRequest
    {
        public PosCredential PosCredential { get; set; }

        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public string RefundReferenceNumber { get; set; }
    }
}