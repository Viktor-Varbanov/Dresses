using OpenQA.Selenium;
using DressWebsiteTests.Extensions;
namespace DressWebsiteTests.Pages.Main
{
    public partial class MainPage
    {
        public IWebElement DesiredProduct(string desiredProductName)
        {
            return Driver.FindElementByXpath($"//a[@title='{desiredProductName}']");
        }

        public IWebElement DesiredProductQuickView(string desiredProductName)
        {
            return Driver.FindElementByXpath($"//a[@title='{desiredProductName}']//following::a[@class='quick-view']");
        }

        public IWebElement QuickViewIframeWindow => Driver.FindElementByClassName("fancybox-iframe");

    }
}
