using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosIntegration.Service.Est.Model
{
    public class EstAuthResponse
    {
        public string OrderId { get; set; }
        public string GroupId { get; set; }
        public string Response { get; set; }
        public string AuthCode { get; set; }
        public string HostRefNum { get; set; }
        public string ProcReturnCode { get; set; }
        public string TransactionId { get; set; }
        public string ErrMsg { get; set; }
        public string RawBody { get; set; }

        public bool IsSuccess()
        {
            return "Approved".Equals(Response);
        }
    }
}
