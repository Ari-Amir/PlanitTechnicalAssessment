using AventStack.ExtentReports;
using PlanitTechnicalAssessment.Pages;
using Xunit;

namespace PlanitTechnicalAssessment.Tests
{
    /* 
       ValidateContactFormErrors: Tests error visibility and clearance on contact form.
       ValidateSuccessfulContactFormSubmission: Tests successful form submission with 5 runs.
       Uses ExtentReports logs for test reporting.
    */

    public class ContactPageTests : TestBase
    {
        private static readonly ExtentReports reports = ExtentReportManager.GetInstance();
        private ExtentTest testLogger;

        [Fact]
        public async Task ValidateContactFormErrors()
        {
            testLogger = reports.CreateTest("ValidateContactFormErrors");
            testLogger.Log(Status.Info, "Test started");

            try
            {
                await homePage.OpenContactPage();
                testLogger.Log(Status.Info, "Clicking submit button with empty fields...");
                await contactPage.ClickSubmitButton();
                await contactPage.VerifyErrorsAreDisplayed();

                testLogger.Log(Status.Info, "Filling mandatory fields and resubmitting...");
                await contactPage.FillMandatoryFields();
                await contactPage.ClickSubmitButton();
                await contactPage.VerifyErrorsAreNotDisplayed();

                testLogger.Log(Status.Pass, "Contact form validation passed");
            }
            catch (Exception ex)
            {
                testLogger.Log(Status.Fail, $"Test failed: {ex.ToString()}");
                throw;
            }
            finally
            {
                reports.Flush();
            }             
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async Task ValidateSuccessfulContactFormSubmission(int runNumber)
        {
            testLogger = reports.CreateTest($"ValidateSuccessfulContactFormSubmission - Run {runNumber}");
            testLogger.Log(Status.Info, $"Running form submission testLogger with set {runNumber}...");

            try
            {
                await homePage.OpenContactPage();
                await contactPage.FillMandatoryFields();
                await contactPage.ClickSubmitButton();
                testLogger.Log(Status.Info, "Filling mandatory fields and resubmitting...");
                await contactPage.VerifySuccessPageIsDisplayed();
                testLogger.Log(Status.Pass, "Contact form successfully submitted");
            }
            catch (Exception ex)
            {
                testLogger.Log(Status.Fail, $"Test failed: {ex.ToString()}");
                throw;
            }
            finally
            {
                reports.Flush();
            }
        }
    }
}
