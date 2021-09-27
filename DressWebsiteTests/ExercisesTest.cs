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
        }

        public void Dispose()
        {
            _webDriver.Quit();
        }

        [Test]
        public void CorrectProductIsDisplayed_When_QuickViewIsClicked()
        {
            // --Arrange
            Product product = new Product()
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
            PurchaseFacade purchaseFacade = new PurchaseFacade(_webDriver, _webDriverWait, _actions, product);

            //Act && Assert
            purchaseFacade.PurchaseProduct();
        }

        [Test]
        public void CorrectProductIsAddedToCart()
        {
            // --Arrange
            Product productInformation = new Product()
            {
                Id = "product_7_38_0_0",
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
            PurchaseFacade purchaseFacade = new PurchaseFacade(_webDriver, _webDriverWait, _actions, productInformation); ;


            //Act && Assert
            purchaseFacade.PurchaseProduct(productColor, productSize, productQuantity);
        }
    }
}