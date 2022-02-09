using JobApplications.Services;
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
        private const int autoAcceptedYearOfExperience = 15;
        private readonly IIdentityValidator _identityValidator;

        public ApplicantEvaluator(IIdentityValidator identityValidator)
        {
            _identityValidator = identityValidator;
        }

        private List<string> techStackList = new() { "C#", "RabbitMQ", "Microservice", "Visual Studio" };
        public ApplicantResult Evaulate(JobApplication jobApplication)
        {
            if (jobApplication.Applicant.Age < minAge)
                return ApplicantResult.AutoRejected;

            //var connectionSucceed = _identityValidator.CheckConnectionToRemoveServer();
            var validIdentity = _identityValidator.IsValid(jobApplication.Applicant.IdentityNumber);

            if(!validIdentity)
                return ApplicantResult.TranferredToHR;

            var sr = GetTechStackSimilarityRate(jobApplication.TechStackList);
            if(sr < 25)
                return ApplicantResult.AutoRejected;

            if (sr > 75 && jobApplication.YearsOfExperience > autoAcceptedYearOfExperience)
                return ApplicantResult.AutoAccepted;



            return ApplicantResult.AutoAccepted;


        }

        private int GetTechStackSimilarityRate(List<string> techStacks)
        {
            var macthedCount =
                techStacks
                    .Where(i => techStackList.Contains(i, StringComparer.OrdinalIgnoreCase))
                    .Count();

            return (int)((macthedCount / techStackList.Count() * 100));
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
