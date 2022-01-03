namespace PosIntegration.Model.Refund
{
    public class RefundResponse
    {
        public RefundResponse(bool isSuccess, string resultCode, string resultMessage, string bankReferenceNumber, string rawResponse)
        {
            IsSuccess = isSuccess;
            ResultCode = resultCode;
            ResultMessage = resultMessage;
            BankReferenceNumber = bankReferenceNumber;
            RawResponse = rawResponse;
        }

        public bool IsSuccess { get; set; }
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public string BankReferenceNumber { get; set; }
        public string RawResponse { get; set; }
    }
}