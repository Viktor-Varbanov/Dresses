namespace Dresses.Pages.Main
{
    using AbstractionPageComponents;
    using OpenQA.Selenium;

    public class MainPageElementMap : AbstractElementMap
    {
        private const string GenericProductXpath = "//div[@id='center_column']//div[@class='tab-content']//ul[@id='homefeatured']//li//div[@class='product-container']//div[@class='left-block']//div[@class='product-image-container']//a[@title='{0}']//img[contains(@src, '{1}')]";

        public const string GenericProductQuickViewXpath = "//div[@id='center_column']//div[@class='tab-content']//ul[@id='homefeatured']//li//div[@class='product-container']//div[@class='left-block']//div[@class='product-image-container']//a[@title='{0}']//img[contains(@src, '{1}')]//ancestor::div[@class='product-image-container']//a[@class='quick-view']//span";

        public IWebElement GetDress(string name, string url) => driver.FindElement(By.XPath(string.Format(GenericProductXpath, name, url)));

        public string GetDressQuickView(string name, string url) => string.Format(GenericProductQuickViewXpath, name, url);
        public IWebElement QuickViewIframeWindow => driver.FindElement(By.XPath("//iframe[@class='fancybox-iframe']"));



    }
}
