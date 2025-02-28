using Microsoft.Playwright;

namespace PlanitTechnicalAssessment
{
    public static class WaitUtils
    {
        public static async Task WaitForVisibleAsync(ILocator locator)
        {
            await locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        }

        public static async Task WaitForHiddenAsync(ILocator locator)
        {
            await locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden });
        }
    }
}
