namespace Dresses.Pages.Main
{
    using OpenQA.Selenium;

    public partial class MainPage
    {
        private const string ProductXpath = "//div[@id='center_column']//div[@class='tab-content']//ul[@id='homefeatured']//li//div[@class='product-container']//div[@class='left-block']//div[@class='product-image-container']//a[@title='{0}']";

        private const string ProductQuickView = "//div[@id='center_column']//div[@class='tab-content']//ul[@id='homefeatured']//li//div[@class='product-container']//div[@class='left-block']//div[@class='product-image-container']//a[@title='{0}']//parent::div//child::a[@class='quick-view']//span";

        private const string ProductWithSameTitle = "//div[@id='center_column']//div[@class='tab-content']//ul[@id='homefeatured']//li//div[@class='product-container']//div[@class='left-block']//div[@class='product-image-container']//a[@title='Printed Summer Dress']//img[@src='http://automationpractice.com/img/p/1/6/16-home_default.jpg']";

        private IWebElement QuickViewIframeWindow => driver.FindElement(By.XPath("//iframe[@class='fancybox-iframe']"));
    }
}
