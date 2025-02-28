using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using PlanitTechnicalAssessment.Pages;
using Xunit;

namespace PlanitTechnicalAssessment.Tests
{
    public class CartPageTests : TestBase
    {
        private static ExtentReports _extent = ExtentReportManager.GetInstance();
        private ExtentTest _test;

        [Fact]
        public async Task ValidateCartTotalsAndPrices()
        {
            _test = _extent.CreateTest("ValidateCartTotalsAndPrices");

            _test.Log(Status.Info, "Test started");

            await LaunchBrowser();

            await homePage.OpenShopPage();
            _test.Log(Status.Info, "Opened Shop Page");

            await shopPage.AddProductToCart("Stuffed Frog", 2);
            await shopPage.AddProductToCart("Fluffy Bunny", 5);
            await shopPage.AddProductToCart("Valentine Bear", 3);

            await homePage.OpenCartPage();
            _test.Log(Status.Info, "Opened Cart Page");

            await cartPage.ValidateCartSubtotals("Stuffed Frog");
            await cartPage.ValidateCartSubtotals("Fluffy Bunny");
            await cartPage.ValidateCartSubtotals("Valentine Bear");

            await cartPage.ValidateCartPrices("Stuffed Frog");
            await cartPage.ValidateCartPrices("Fluffy Bunny");
            await cartPage.ValidateCartPrices("Valentine Bear");

            await cartPage.ValidateCartTotal();

            _test.Log(Status.Pass, "Cart totals and prices validated successfully");
            _extent.Flush();
        }
    }
}
