using DressWebsiteTests.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DressWebsiteTests.Pages.Main
{
    public partial class MainPage : WebPage
    {
        public MainPage(IWebDriver driver, WebDriverWait webDriverWait, Actions actions) : base(driver, webDriverWait, actions)
        {
        }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            WaitForPageToLoad();
        }

        public void ChooseDress(string desiredProductName)
        {
            var desiredProduct = DesiredProduct(desiredProductName);
            Driver.ScrollToElement(desiredProduct);
            Actions.HoverElement(desiredProduct);
            var desiredProductQuickView = DesiredProductQuickView(desiredProductName);
            desiredProductQuickView.Click();
            Driver.SwitchToIFrame(WebDriverWait, By.ClassName("fancybox-iframe"), QuickViewIframeWindow);
        }

        protected override void WaitForPageToLoad()
        {
            WebDriverWait.UntilElementIsVisible(By.Id("page"));
        }
    }
}