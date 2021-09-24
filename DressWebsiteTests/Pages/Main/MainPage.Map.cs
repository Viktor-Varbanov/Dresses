using OpenQA.Selenium;

namespace DressWebsiteTests.Pages.Main
{
    public partial class MainPage
    {
        public IWebElement DesiredProduct(string desiredProductName)
        {
            return Driver.FindElement(By.XPath($"//a[@title='{desiredProductName}']"));
        }

        public IWebElement DesiredProductQuickView(string desiredProductName)
        {
            return Driver.FindElement(By.XPath($"//a[@title='{desiredProductName}']//following::a[@class='quick-view']"));
        }

        public IWebElement QuickViewIframeWindow => Driver.FindElement(By.XPath("//iframe[@class='fancybox-iframe']"));

    }
}
