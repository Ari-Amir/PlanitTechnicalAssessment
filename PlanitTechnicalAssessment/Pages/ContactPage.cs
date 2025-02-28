using Microsoft.Playwright;
using Xunit;
using static PlanitTechnicalAssessment.WaitUtils;

namespace PlanitTechnicalAssessment.Pages
{
    public class ContactPage
    {
        private IPage page;

        public ContactPage (IPage page)
        {
            this.page = page;
        }

        public async Task ClickSubmitButton()
        {
            var submitButton = page.GetByText("Submit");
            await WaitForVisibleAsync(submitButton);
            await submitButton.ClickAsync();
        }

        public async Task VerifyErrorsAreDisplayed()
        {
            var forenameError = page.GetByText("Forename is required");
            await WaitForVisibleAsync(forenameError);
            Assert.True(await forenameError.IsVisibleAsync());

            var emailError = page.GetByText("Email is required");
            await WaitForVisibleAsync(emailError);
            Assert.True(await emailError.IsVisibleAsync());

            var messageError = page.GetByText("Message is required");
            await WaitForVisibleAsync(messageError);
            Assert.True(await messageError.IsVisibleAsync());
        }

        public async Task FillMandatoryFields()
        {
            var forenameInput = page.GetByRole(AriaRole.Textbox, new() { Name = "forename" });
            await WaitForVisibleAsync(forenameInput);
            await forenameInput.FillAsync("John");

            var emailInput = page.GetByRole(AriaRole.Textbox, new() { Name = "email" });
            await WaitForVisibleAsync(emailInput);
            await emailInput.FillAsync("john@example.com");

            var messageInput = page.GetByRole(AriaRole.Textbox, new() { Name = "message" });
            await WaitForVisibleAsync(messageInput);
            await messageInput.FillAsync("Hi, my name is John");
        }

        public async Task VerifyErrorsAreNotDisplayed()
        {
            var forenameError = page.GetByText("Forename is required");
            await WaitForHiddenAsync(forenameError);
            Assert.False(await forenameError.IsVisibleAsync());

            var emailError = page.GetByText("Email is required");
            await WaitForHiddenAsync(emailError);
            Assert.False(await emailError.IsVisibleAsync());

            var messageError = page.GetByText("Message is required");
            await WaitForHiddenAsync(messageError);
            Assert.False(await messageError.IsVisibleAsync());

            var sendingFeedback = page.GetByText("Sending Feedback");
            await WaitForVisibleAsync(sendingFeedback);
            Assert.True(await sendingFeedback.IsVisibleAsync());
        }

        public async Task VerifySuccessPageIsDisplayed()
        {
            var successMessage = page.Locator(".alert.alert-success");
            await WaitForVisibleAsync(successMessage);
            Assert.True(await successMessage.IsVisibleAsync());
        }
    }
}
