using Microsoft.Playwright;

namespace PlanitTechnicalAssessment.Pages
{
    public class HomePage
    {
        private IPage page;

        public HomePage(IPage page)
        {
            this.page = page;
        }

        public async Task OpenContactPage()
        {
            await page.Locator("#nav-contact a").ClickAsync();
        }

        public async Task OpenShopPage()
        {
            await page.Locator("#nav-shop a").ClickAsync();
        }

        public async Task OpenCartPage()
        {
            await page.Locator("#nav-cart a").ClickAsync();
        }
    }
}
    