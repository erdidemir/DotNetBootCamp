using System.Threading.Tasks;
using PosIntegration.Model.Auth;
using PosIntegration.Model.RedirectUrl;
using PosIntegration.Model.Refund;

namespace PosIntegration.Service.TyBank
{
    public class TyBankPosService : IPosService
    {
        public Task<RefundResponse> RefundAsync(RefundRequest request)
        {
            // TODO: business implementation section
            // "refund" flow provides to refund the amount to user via TyBank virtual pos.
            // The user will see refunded amount in his or her account in 1-2 days.
            return null;
        }

        public Task<AuthResponse> AuthAsync(AuthRequest request)
        {
            // TODO: business implementation section
            // "auth" flow enables the user to make payment via credit card from TyBank virtual pos.
            // This payment method captures the amount from the user's credit card directly.
            return null;
        }

        public Task<RedirectUrlResponse> FetchRedirectionUrlAsync(RedirectUrlRequest request)
        {
            return null;
        }
    }
}
