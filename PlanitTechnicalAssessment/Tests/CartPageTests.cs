using PlanitTechnicalAssessment.Pages;

namespace PlanitTechnicalAssessment.Tests
{
    public class CartPageTests : TestBase
    {
        [Fact]
        public async Task ValidateCartTotalsAndPrices()
        {
            await LaunchBrowser();

            await homePage.OpenShopPage();

            await shopPage.AddProductToCart("Stuffed Frog", 2);
            await shopPage.AddProductToCart("Fluffy Bunny", 5);
            await shopPage.AddProductToCart("Valentine Bear", 3);

            await homePage.OpenCartPage();

            await cartPage.ValidateCartSubtotals("Stuffed Frog");
            await cartPage.ValidateCartSubtotals("Fluffy Bunny");
            await cartPage.ValidateCartSubtotals("Valentine Bear");

            await cartPage.ValidateCartPrices("Stuffed Frog");
            await cartPage.ValidateCartPrices("Fluffy Bunny");
            await cartPage.ValidateCartPrices("Valentine Bear");

            await cartPage.ValidateCartTotal();
        } 
    }
}
