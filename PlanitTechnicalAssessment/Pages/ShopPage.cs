using Microsoft.Playwright;
using static PlanitTechnicalAssessment.Utils.WaitUtils;

namespace PlanitTechnicalAssessment.Pages
{
     /*  
        AddProductToCart: Adds specified products to the cart.
        Also implements logic to save their price and amount into these fields:     
          productsPrices - Stores product prices.
          productsAmounts - Stores product quantities.
        This is done for cart validation later.
     */

    public class ShopPage
    {
        private readonly IPage page;
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
            var buyButton = page.Locator($"li.product:has-text('{productName}') >> a.btn.btn-success");
            for (int i = 0; i < productAmount; i++)
            {
                await WaitForVisibleAsync(buyButton);
                await buyButton.ClickAsync();
            }

            var priceLocator = page.Locator($"li.product:has-text('{productName}') >> span.product-price");
            await WaitForVisibleAsync(priceLocator);
            var productPriceText = await priceLocator.InnerTextAsync();
            decimal.TryParse(productPriceText.Replace("$", "").Trim(), out decimal productPrice);

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
