using OpenQA.Selenium;

namespace Dresses.Pages.Main
{
    public partial class MainPage
    {
        private const string GenericProductXpath = "//div[@id='center_column']//div[@class='tab-content']//ul[@id='homefeatured']//li//div[@class='product-container']//div[@class='left-block']//div[@class='product-image-container']//a[@title='{0}']//img[contains(@src, '{1}')]";

        //a[@title ={name}]
        private const string GenericProductQuickViewXpath = "//div[@id='center_column']//div[@class='tab-content']//ul[@id='homefeatured']//li//div[@class='product-container']//div[@class='left-block']//div[@class='product-image-container']//a[@title='{0}']//img[contains(@src, '{1}')]//ancestor::div[@class='product-image-container']//a[@class='quick-view']//span";

        //public IWebElement DressLocation(string name, string url) => driver.FindElement(By.XPath(string.Format(GenericProductXpath, name, url)));

        //public string GetDressQuickViewLocator(string name, string url) => string.Format(GenericProductQuickViewXpath, name, url);

        //public IWebElement GetDressQuickViewButton(string name, string url)
        //{
        //    var xpath = string.Format(GenericProductQuickViewXpath, name, url);

        //    return driver.FindElement(By.XPath(xpath));
        //}

        //public IWebElement QuickViewIframeWindow => driver.FindElement(By.XPath("//iframe[@class='fancybox-iframe']"));

        //public string QuickViewIframeWindowLocator => "//iframe[@class='fancybox-iframe']";

        public IWebElement ProductLocation(string desiredProductName)
        {
            return Driver.Browser.FindElement(By.XPath($"//a[@title='{desiredProductName}']"));
        }

        public IWebElement ProductQuickView(string desiredProductName)
        {
            return Driver.Browser.FindElement(By.XPath($"//a[@title='{desiredProductName}']//following::a[@class='quick-view']"));
        }
    }
}
