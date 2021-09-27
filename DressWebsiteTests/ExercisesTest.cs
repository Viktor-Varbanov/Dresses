using DressWebsiteTests.Facade;
using DressWebsiteTests.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using DressWebsiteTests.Services;

namespace DressWebsiteTests
{
    [TestFixture]
    public class ExercisesTest : IDisposable
    {

        private readonly IWebDriver _webDriver;
        private readonly Actions _actions;
        private readonly WebDriverWait _webDriverWait;
        private readonly ProductService _productService;
        private readonly PurchaseFacade _purchaseFacade;
        private readonly Cart _cart;

        public ExercisesTest()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            _webDriver = new ChromeDriver(chromeOptions);
            _actions = new Actions(_webDriver);
            _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            _productService = new ProductService();
            _purchaseFacade = new PurchaseFacade(_webDriver, _webDriverWait, _actions);
            _cart = new Cart();

        }

        public void Dispose()
        {
            _webDriver.Quit();
        }

        [Test]
        public void CorrectProductIsDisplayed_When_QuickViewIsClicked()
        {
            // --Arrange
            var product = _productService.GetProductById("product_7_34_0_0");
            _cart.AddProduct(product);

            //Act && Assert
            _purchaseFacade.PurchaseProduct(product, _cart);
        }

        [Test]
        public void CorrectProductIsAddedToCart()
        {
            // --Arrange
            var product = _productService.GetProductById("product_7_38_0_0");
            _cart.AddProduct(product);
            var productColor = "Green";
            var productSize = "M";
            var productQuantity = 20;


            //Act && Assert
            _purchaseFacade.PurchaseProduct(product, _cart, productColor, productSize, productQuantity);
        }
    }
}