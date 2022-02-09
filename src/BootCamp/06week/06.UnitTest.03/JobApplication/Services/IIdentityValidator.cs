using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplications.Services
{
    public interface IIdentityValidator
    {
        public bool IsValid(string identityNumber);
    }
}
