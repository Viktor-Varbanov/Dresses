using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using DressWebsiteTests.Extensions;

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
        }

        public void ChooseDress(string desiredProductName)
        {
            IWebElement desiredProduct = DesiredProduct(desiredProductName);
            Driver.ScrollToElement(desiredProduct);
            Actions.HoverElement(desiredProduct);
            IWebElement desiredProductQuickView = DesiredProductQuickView(desiredProductName);
            desiredProductQuickView.Click();
            Driver.SwitchToIFrame("//iframe[@class='fancybox-iframe']", QuickViewIframeWindow);
        }

    }
}
