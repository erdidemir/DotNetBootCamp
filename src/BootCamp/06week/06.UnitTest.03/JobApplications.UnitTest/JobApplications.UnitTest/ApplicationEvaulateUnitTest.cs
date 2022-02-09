using JobApplications.Services;
using Moq;
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
            ApplicantEvaluator applicantEvaluator = new ApplicantEvaluator(null);
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

            var mockValidator = new Mock<IIdentityValidator>();
            mockValidator.DefaultValue = DefaultValue.Mock;
            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);
            mockValidator.Setup(i => i.CountryDataProvider.CountryData.Country).Returns("TURKEY");

            ApplicantEvaluator applicantEvaluator = new ApplicantEvaluator(mockValidator.Object);
            var form = new JobApplication()
            {
                Applicant = new Applicant()
                {
                    Age = 19,
                    IdentityNumber = ""
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

            var mockValidator = new Mock<IIdentityValidator>();
            mockValidator.DefaultValue = DefaultValue.Mock;
            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);
            mockValidator.Setup(i => i.CountryDataProvider.CountryData.Country).Returns("TURKEY");

            ApplicantEvaluator applicantEvaluator = new ApplicantEvaluator(mockValidator.Object);
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

        [Test]
        public void Application_ShouldTransferredtoTranferredToHR_WithNoValidIdentityNumber()
        {
            //Arrange
            //Testlerin her biri kendi baþýna çalýþabilmesi için class testin içine ekliyoruz

            var mockValidator = new Mock<IIdentityValidator>();

            mockValidator.DefaultValue = DefaultValue.Mock;
            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(false);
            mockValidator.Setup(i => i.CountryDataProvider.CountryData.Country).Returns("TURKEY");

            //Sahte bir tane obje yaratýp bu validasyonlarý kullanabiliriz
            //mockValidator.Setup(i => i.IsValid(It.IsAny<string>(false))).Returns();
            //mockValidator.Setup(i => i.CheckConnectionToRemoveServer()).Returns(false);

            ApplicantEvaluator applicantEvaluator = new ApplicantEvaluator(mockValidator.Object);
            var form = new JobApplication()
            {
                Applicant = new Applicant()
                {
                    Age = 19
                }
            };

            //Action

            var appResult = applicantEvaluator.Evaulate(form);

            //Assert

            Assert.AreEqual(appResult, ApplicantResult.TranferredToHR);

        }

        [Test]
        public void Application_ShouldTranferredToCTO_WithOfficeLocation()
        {
            //Arrange
            //Testlerin her biri kendi baþýna çalýþabilmesi için class testin içine ekliyoruz

            var mockValidator = new Mock<IIdentityValidator>();
            mockValidator.DefaultValue = DefaultValue.Mock;

            //var mockCountryData = new Mock<ICountryData>();
            //mockCountryData.Setup(i => i.Country).Returns("TURKEY");

            //var mockProvider = new Mock<ICountryDataProvider>();
            //mockProvider.Setup(i => i.CountryData).Returns(mockCountryData.Object);


            ////Sahte bir tane obje yaratýp bu validasyonlarý kullanabiliriz
            ////mockValidator.Setup(i => i.CheckConnectionToRemoveServer()).Returns(false);
            //mockValidator.Setup(i => i.CountryDataProvider).Returns(mockProvider.Object);

            mockValidator.Setup(i => i.CountryDataProvider.CountryData.Country).Returns("SPAIN");

            mockValidator.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);

            ApplicantEvaluator applicantEvaluator = new ApplicantEvaluator(mockValidator.Object);
            var form = new JobApplication()
            {
                Applicant = new Applicant()
                {
                    Age = 19
                }
            };

            //Action

            var appResult = applicantEvaluator.Evaulate(form);

            //Assert

            Assert.AreEqual(ApplicantResult.TranferredToCTO, appResult);

        }


    }
}