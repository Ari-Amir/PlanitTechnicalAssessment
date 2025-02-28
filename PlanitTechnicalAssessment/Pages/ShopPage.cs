using Microsoft.Playwright;


namespace PlanitTechnicalAssessment.Pages
{
    public class ShopPage
    {
        private IPage page;

        public Dictionary<string, decimal> productsPrices;
        public Dictionary<string, int> productsAmounts;


        public ShopPage(IPage page)
        {
            this.page = page;
            productsPrices = new Dictionary<string, decimal>();
            productsAmounts = new Dictionary<string, int>();
        }

        public async Task AddProductToCart(string productName, int productAmount)
        {
            for (int i=0; i < productAmount; i++)
            {
                var buyButton = page.Locator($"li.product:has-text('{productName}') >> a.btn.btn-success");
                await buyButton.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
                await buyButton.ClickAsync();
            }

            var productPriceText = await page.Locator($"li.product:has-text('{productName}') >> span.product-price").InnerTextAsync();
            var productPrice = decimal.Parse(productPriceText.Replace("$", "").Trim());

            if (productsAmounts.ContainsKey(productName))
            {
                productsAmounts[productName] += productAmount;
            }
            else
            {
                productsAmounts[productName] = productAmount;
                productsPrices[productName] = productPrice;
            }
        }       
    }
}
