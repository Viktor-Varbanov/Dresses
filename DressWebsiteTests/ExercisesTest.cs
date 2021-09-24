using DressWebsiteTests.Pages.Main;
using DressWebsiteTests.Pages.PurchaseSummary;
using DressWebsiteTests.Pages.QuickView;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
        public void TestRun()
        {
            _mainPage.GoTo();
            _mainPage.ChooseDress("Printed Chiffon Dress");
            _quickViewPage.AssertCorrectProductDiscountPercantageIsDisplayed(20);
            _quickViewPage.AddToCart();
            _purchaseSummary.ProceedToCHeckout();


        }


    }
}
