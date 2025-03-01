using Microsoft.Playwright;
using PlanitTechnicalAssessment.Pages;
using System;
using System.Threading.Tasks;

namespace PlanitTechnicalAssessment
{
    public class TestBase : IDisposable
    {
        protected IPage page;
        protected IBrowser browser;
        protected IBrowserContext context;
        protected HomePage homePage;
        protected ContactPage contactPage;
        protected ShopPage shopPage;
        protected CartPage cartPage;
        
        private static readonly string BaseUrl = "http://jupiter.cloud.planittesting.com";

        public TestBase()
        {
            LaunchBrowser().GetAwaiter().GetResult();
        }

        protected async Task LaunchBrowser()
        {
            var playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1680, Height = 900 }       
            });
            page = await context.NewPageAsync();
            await page.GotoAsync(BaseUrl);

            homePage = new HomePage(page);
            contactPage = new ContactPage(page);
            shopPage = new ShopPage(page);
            cartPage = new CartPage(page, shopPage);
        }

        public void Dispose()
        {
            browser?.CloseAsync();
        }
    }
}