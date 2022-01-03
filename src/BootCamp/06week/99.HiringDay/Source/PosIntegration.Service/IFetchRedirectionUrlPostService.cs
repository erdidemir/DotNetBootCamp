using PosIntegration.Model.RedirectUrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosIntegration.Service
{
    public interface IFetchRedirectionUrlPostService
    {
        Task<RedirectUrlResponse> FetchRedirectionUrlAsync(RedirectUrlRequest request);
    }
}
