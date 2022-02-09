using NUnit.Framework;

namespace JobApplications.UnitTest
{
    public class ApplicationEvaulateUnitTest
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        //UnitofWork_Condition_ExpectedResult
        //Condition_Result
        //UnitofWork_ExpectedResult_Condition
        //Code Snipped


        [Test]
        public void Application_ShouldTransferredtoAutoRejected_WithUnderAge()
        {
            //Arrange
            //Testlerin her biri kendi baþýna çalýþabilmesi için class testin içine ekliyoruz
            ApplicantEvaluator applicantEvaluator = new ApplicantEvaluator();
            var form = new JobApplication()
            {
                Applicant = new Applicant()
                {
                    Age = 17
                }
            };

            //Action

            var appResult = applicantEvaluator.Evaulate(form);

            //Assert

            Assert.AreEqual(appResult, ApplicantResult.AutoRejected);

        }

        [Test]
        public void Application_ShouldTransferredtoAutoRejected_WithNoTechStack()
        {
            //Arrange
            //Testlerin her biri kendi baþýna çalýþabilmesi için class testin içine ekliyoruz
            ApplicantEvaluator applicantEvaluator = new ApplicantEvaluator();
            var form = new JobApplication()
            {
                Applicant = new Applicant()
                {
                    Age = 19
                },
                TechStackList = new System.Collections.Generic.List<string> { "" }
            };

            //Action

            var appResult = applicantEvaluator.Evaulate(form);

            //Assert

            Assert.AreEqual(appResult, ApplicantResult.AutoRejected);

        }

        [Test]
        public void Application_ShouldTransferredtoAutoAccepted_WithTechStackOver75()
        {
            //Arrange
            //Testlerin her biri kendi baþýna çalýþabilmesi için class testin içine ekliyoruz
            ApplicantEvaluator applicantEvaluator = new ApplicantEvaluator();
            var form = new JobApplication()
            {
                Applicant = new Applicant()
                {
                    Age = 19
                },
                TechStackList = new System.Collections.Generic.List<string> { "C#", "RabbitMQ", "Microservice", "Visual Studio" },
                YearsOfExperience = 16
            };

            //Action

            var appResult = applicantEvaluator.Evaulate(form);

            //Assert

            Assert.AreEqual(appResult, ApplicantResult.AutoAccepted);

        }


    }
}