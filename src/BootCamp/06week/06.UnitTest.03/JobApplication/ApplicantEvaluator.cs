using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplications
{
    public class ApplicantEvaluator
    {
        private const int minAge = 18;
        public ApplicantResult Evaulate(JobApplication jobApplication)
        {
            if(jobApplication.Applicant.Age < minAge)
                return ApplicantResult.AutoRejected;


            return ApplicantResult.AutoAccepted;


        }


    }

    public enum ApplicantResult
    {
        AutoRejected,
        TranferredToHR,
        TranferredToLead,
        TranferredToCTO,
        AutoAccepted
    }
}
