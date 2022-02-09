using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplications.Services
{
    public class IdentityValidator : IIdentityValidator
    {
        public ICountryDataProvider CountryDataProvider => throw new NotImplementedException();

        public bool CheckConnectionToRemoveServer()
        {
            return false;
        }

        public bool IsValid(string identityNumber)
        {
            return true;
        }
    }
}
