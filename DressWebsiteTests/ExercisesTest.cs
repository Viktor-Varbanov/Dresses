using DressWebsiteTests.Facade;
using DressWebsiteTests.Model;
using DressWebsiteTests.Pages.Main;
using DressWebsiteTests.Pages.PurchaseSummary;
using DressWebsiteTests.Pages.QuickView;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace DressWebsiteTests
{
    [TestFixture]
    public class ExercisesTest : IDisposable
    {
        private readonly MainPage _mainPage;
        private readonly QuickViewPage _quickViewPage;
        private readonly PurchaseSummary _purchaseSummary;
        private readonly IWebDriver _webDriver;
        private readonly Actions _actions;
        private readonly WebDriverWait _webDriverWait;

        public ExercisesTest()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");

            _webDriver = new ChromeDriver(chromeOptions);
            _actions = new Actions(_webDriver);
            _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            _mainPage = new MainPage(_webDriver, _webDriverWait, _actions);
            _quickViewPage = new QuickViewPage(_webDriver, _webDriverWait, _actions);
            _purchaseSummary = new PurchaseSummary(_webDriver, _webDriverWait, _actions);
        }

        public void Dispose()
        {
            _webDriver.Quit();
        }

        [Test]
        public void CorrectProductIsDisplayed_When_QuickViewIsClicked()
        {
            // --Arrange
            ProductInformation productInformation = new ProductInformation()
            {
                Id = "product_7_34_0_0",
                Name = "Printed Chiffon Dress",
                Model = "demo_7",
                Description = "Printed chiffon knee length dress with tank straps. Deep v-neckline.",
                Price = 20.50m,
                BaseImageUrl = "http://automationpractice.com/img/p/2/0/20",
                Color = "Yellow",
                Size = "S",
                Availability = "In stock",
                HasDiscount = true,
                PercentageDiscount = 20,
                Quantity = 1
            };
            QuickViewValidationFacade quickViewValidationFacade = new QuickViewValidationFacade(_webDriver, _webDriverWait, _actions, productInformation);

            // --Act
            quickViewValidationFacade.GoToProductQuickView();

            // --Assert
            quickViewValidationFacade.ValidateCorrectProductIsDisplayed();
        }

        [Test]
        public void CorrectProductIsAddedToCart()
        {
            // --Arrange
            ProductInformation productInformation = new ProductInformation()
            {
                Id = "product_7_38_0_572888",
                Name = "Printed Chiffon Dress",
                Model = "demo_7",
                Description = "Printed chiffon knee length dress with tank straps. Deep v-neckline.",
                Price = 20.50m,
                BaseImageUrl = "http://automationpractice.com/img/p/2/2/22",
                Color = "Green",
                Size = "M",
                Availability = "In stock",
                HasDiscount = true,
                PercentageDiscount = 20,
                Quantity = 20
            };
            string productColor = "Green";
            string productSize = "M";
            int productQuantity = 20;
            PurchaseProductFacade purchaseProductFacade = new PurchaseProductFacade(_webDriver, _webDriverWait, _actions, productInformation);

            // --Act
            purchaseProductFacade.GoToProductQuickView();
            purchaseProductFacade.ChangeProductAttributes(productColor, productSize, productQuantity);
            purchaseProductFacade.AddProductToCart();

            purchaseProductFacade.ValidateCorrectProductIsDisplayedOnPurchaseSummary();
            purchaseProductFacade.ProceedToCheckout();

            // --Assert
        }
    }
}