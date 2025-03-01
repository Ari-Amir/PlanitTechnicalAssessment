using Microsoft.Playwright;

namespace PlanitTechnicalAssessment.Utils
{
    /*  
        WaitForVisibleAsync: Waits for an element to become visible.
        WaitForHiddenAsync: Waits for an element to become hidden.
       
        Parameters:
            locator - The element locator to wait for.
            timeout - Timeout in milliseconds (default: 10000).
    */

    public static class WaitUtils
    {
        public static async Task WaitForVisibleAsync(ILocator locator, int timeout = 10000)
        {
            await locator.WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Visible,
                Timeout = timeout
            });
        }

        public static async Task WaitForHiddenAsync(ILocator locator, int timeout = 10000)
        {
            await locator.WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Hidden,
                Timeout = timeout
            });
        }
    }
}
