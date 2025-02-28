using PlanitTechnicalAssessment.Pages;


namespace PlanitTechnicalAssessment.Tests
{
    public class ContactPageTests : TestBase
    {
        [Fact]
        public async Task ValidateContactFormErrors()
        {
            await LaunchBrowser();
            await homePage.OpenContactPage();
            await contactPage.ClickSubmitButton();
            await contactPage.VerifyErrorsAreDisplayed();
            await contactPage.FillMandatoryFields();
            await contactPage.ClickSubmitButton();
            await contactPage.VerifyErrorsAreNotDisplayed();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async Task ValidateSuccessfulContactFormSubmission(int runNumber)
        {
            await LaunchBrowser();
            await homePage.OpenContactPage();
            await contactPage.FillMandatoryFields();
            await contactPage.ClickSubmitButton();
            await contactPage.VerifySuccessPageIsDisplayed();
        }
    }
}
