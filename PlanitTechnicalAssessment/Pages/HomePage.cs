using Microsoft.Playwright;

namespace PlanitTechnicalAssessment.Pages
{
    /* 
       OpenContactPage: Navigates to the contact page.
       OpenShopPage: Navigates to the shop page.
       OpenCartPage: Navigates to the cart page.
    */

    public class HomePage
    {
        private readonly IPage page;

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
