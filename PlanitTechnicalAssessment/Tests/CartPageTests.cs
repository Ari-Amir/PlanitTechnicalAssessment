using AventStack.ExtentReports;
using PlanitTechnicalAssessment.Pages;
using Xunit;

namespace PlanitTechnicalAssessment.Tests
{
    /* 
        ValidateCartTotalsAndPrices: Adds products to cart and validates subtotals, prices, and total.
        Uses ExtentReports logs for test reporting.
    */

    public class CartPageTests : TestBase
    {
        private static readonly ExtentReports reports = ExtentReportManager.GetInstance();
        private ExtentTest testLogger;

        [Fact]
        public async Task ValidateCartTotalsAndPrices()
        {

            testLogger = reports.CreateTest("ValidateCartTotalsAndPrices");
            testLogger.Log(Status.Info, "Test started");

            try
            {
                await homePage.OpenShopPage();
                testLogger.Log(Status.Info, "Opened Shop Page");

                await shopPage.AddProductToCart("Stuffed Frog", 2);
                await shopPage.AddProductToCart("Fluffy Bunny", 5);
                await shopPage.AddProductToCart("Valentine Bear", 3);

                await homePage.OpenCartPage();
                testLogger.Log(Status.Info, "Opened Cart Page");

                await cartPage.ValidateCartSubtotals("Stuffed Frog");
                await cartPage.ValidateCartSubtotals("Fluffy Bunny");
                await cartPage.ValidateCartSubtotals("Valentine Bear");

                await cartPage.ValidateCartPrices("Stuffed Frog");
                await cartPage.ValidateCartPrices("Fluffy Bunny");
                await cartPage.ValidateCartPrices("Valentine Bear");

                await cartPage.ValidateCartTotal();

                testLogger.Log(Status.Pass, "Cart totals and prices validated successfully");
            }
            catch (Exception ex)
            {
                testLogger.Log(Status.Fail, $"Test failed: {ex.ToString()}");
                throw;
            }
            finally
            {
                reports.Flush();
            }            
        }
    }
}
