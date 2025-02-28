using AventStack.ExtentReports;
using PlanitTechnicalAssessment.Pages;
using Xunit;
using System.Threading.Tasks;

namespace PlanitTechnicalAssessment.Tests
{
    [Collection("Sequential Tests")]
    public class ContactPageTests : TestBase
    {
        private static ExtentReports _extent = ExtentReportManager.GetInstance();
        private ExtentTest _test;

        [Fact]
        public async Task ValidateContactFormErrors()
        {
            _test = _extent.CreateTest("ValidateContactFormErrors");
            _test.Log(Status.Info, "Test started");

            await LaunchBrowser();
            await homePage.OpenContactPage();

            _test.Log(Status.Info, "Clicking submit button with empty fields...");
            await contactPage.ClickSubmitButton();
            await contactPage.VerifyErrorsAreDisplayed();

            _test.Log(Status.Info, "Filling mandatory fields and resubmitting...");
            await contactPage.FillMandatoryFields();
            await contactPage.ClickSubmitButton();
            await contactPage.VerifyErrorsAreNotDisplayed();

            _test.Log(Status.Pass, "Contact form validation passed");

            _extent.Flush();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async Task ValidateSuccessfulContactFormSubmission(int runNumber)
        {
            _test = _extent.CreateTest($"ValidateSuccessfulContactFormSubmission - Run {runNumber}");
            _test.Log(Status.Info, $"Running form submission test with set {runNumber}...");

            await LaunchBrowser();
            await homePage.OpenContactPage();

            await contactPage.FillMandatoryFields();
            await contactPage.ClickSubmitButton();
            _test.Log(Status.Info, "Filling mandatory fields and resubmitting...");

            await contactPage.VerifySuccessPageIsDisplayed();
            _test.Log(Status.Pass, "Contact form successfully submitted");

            _extent.Flush();
        }
    }
}
