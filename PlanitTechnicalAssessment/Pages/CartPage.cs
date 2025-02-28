using Microsoft.Playwright;
using Xunit;

namespace PlanitTechnicalAssessment.Pages
{
    public class CartPage
    {
        private IPage page;
        private ShopPage shopPage;

        public CartPage(IPage page, ShopPage shopPage)
        {
            this.page = page;
            this.shopPage = shopPage;
        }

        public async Task ValidateCartSubtotals(string productName)
        {
            shopPage.productsPrices.TryGetValue(productName, out decimal shopPagePrice);
            shopPage.productsAmounts.TryGetValue(productName, out int shopPageAmount);
            var shopPageSubtotal = (shopPagePrice * shopPageAmount);

            var subtotal = page.Locator($"tr.cart-item:has-text('{productName}') >> td.ng-binding:nth-child(4)");
            await subtotal.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            var subtotalText = await subtotal.InnerTextAsync();
            var cleanedSubtotalText = subtotalText.Replace("$", "").Trim();
            decimal.TryParse(cleanedSubtotalText, out var cartPageSubtotal);
            Assert.Equal(shopPageSubtotal, cartPageSubtotal);
        }

        public async Task ValidateCartPrices(string productName)
        {
            shopPage.productsPrices.TryGetValue(productName, out decimal shopPagePrice);

            var price = page.Locator($"tr.cart-item:has-text('{productName}') >> td.ng-binding:nth-child(2)");
            await price.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            var priceText = await price.InnerTextAsync();
            var cleanedPriceText = priceText.Replace("$", "").Trim();
            decimal.TryParse(cleanedPriceText, out var cartPagePrice);

            Assert.Equal(shopPagePrice, cartPagePrice);
        }

        public async Task ValidateCartTotal()
        {
            var subtotals = page.Locator("td.ng-binding:nth-child(4)");
            await subtotals.First.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            var allSubtotals = await subtotals.AllTextContentsAsync();
            decimal countedSubtotalsSum = 0;
            
            foreach (var subtotalText in allSubtotals)
            {
                var cleanedSubtotalText = subtotalText.Replace("$", "").Trim();
                decimal.TryParse(cleanedSubtotalText, out var subtotal);
                countedSubtotalsSum += subtotal;
            }
            var total = page.Locator(".total.ng-binding");
            await total.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            var totalText = await total.InnerTextAsync();
            var cleanedTotalText = totalText.Replace("Total: ", "").Trim();
            decimal.TryParse(cleanedTotalText, out var displayedTotal);

            Assert.Equal(displayedTotal, countedSubtotalsSum);
        }
    }
}
