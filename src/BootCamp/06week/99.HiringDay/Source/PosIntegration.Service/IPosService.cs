using System.Threading.Tasks;
using PosIntegration.Model.Auth;
using PosIntegration.Model.RedirectUrl;
using PosIntegration.Model.Refund;

namespace PosIntegration.Service
{
    public interface IPosService
    {
        Task<RefundResponse> RefundAsync(RefundRequest request);

        Task<AuthResponse> AuthAsync(AuthRequest request);

    }
}