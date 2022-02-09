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

        //public bool CheckConnectionToRemoveServer();

        ICountryDataProvider CountryDataProvider { get; }
    }

    public interface ICountryData
    {
        string Country { get; }
    }

    public interface ICountryDataProvider
    {
        ICountryData CountryData { get; }
    }
}
