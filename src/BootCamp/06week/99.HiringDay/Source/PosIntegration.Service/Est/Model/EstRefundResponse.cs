using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosIntegration.Service.Est.Model
{
    public class EstRefundResponse
    {
        public string Response { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public string RawBody { get; set; }

        public bool IsSuccess()
        {
            return "[refund-ok]".Equals(Response);
        }
    }
}
