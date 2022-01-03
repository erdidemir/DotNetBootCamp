namespace PosIntegration.Model.Auth
{
    public class AuthResponse
    {
        public AuthResponse(bool isSuccess, string resultCode, string resultMessage, string transactionId, string rawResponse, string authCode, string hostReferenceNumber)
        {
            IsSuccess = isSuccess;
            ResultCode = resultCode;
            ResultMessage = resultMessage;
            TransactionId = transactionId;
            RawResponse = rawResponse;
            AuthCode = authCode;
            HostReferenceNumber = hostReferenceNumber;
        }

        public bool IsSuccess { get; set; }
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public string TransactionId { get; set; }
        public string RawResponse { get; set; }
        public string AuthCode { get; set; }
        public string HostReferenceNumber { get; set; }
    }
}