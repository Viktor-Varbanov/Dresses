namespace Dresses.Pages.QuickView
{
    using OpenQA.Selenium;
    public partial class QuickViewPage
    {
        private IWebElement _addToCartButton => driver.FindElement(By.Id("add_to_cart"));
        private IWebElement _productImage => driver.FindElement(By.Id("bigpic"));
        //private const string ProductImageUrl = "//body[@id='product']//div[@class='primary_block row']//child::img[@id='bigpic']";
        private IWebElement _productName => driver.FindElement(By.XPath("//body[@id='product']//child::div[@class='pb-center-column col-xs-12 col-sm-4']//h1"));
        //private const string ProductName = "//body[@id='product']//child::div[@class='pb-center-column col-xs-12 col-sm-4']//h1";
        private IWebElement _productDescription => driver.FindElement(By.XPath("//div[@id='short_description_block']//child::p"));
        //private const string ProductDescription = "//div[@id='short_description_block']//child::p";

        private IWebElement _productPrice => driver.FindElement(By.Id("our_price_display"));
        private const string ProductPrice = "//span[@id='our_price_display']";

        private IWebElement _productSizeValue => driver.FindElement(By.XPath("//div[@id='uniform-group_1']//span"));

        private IWebElement _productSizeDropdown => driver.FindElement(By.XPath("//select[@id='group_1']"));

        private IWebElement _productDiscount => driver.FindElement(By.Id("reduction_percent_display"));

        private IWebElement _productQuantity => driver.FindElement(By.XPath("//input[@id='quantity_wanted']"));

        //dynamically adding color
        private const string ColorPickerXpath = "//ul[@id='color_to_pick_list']//li//a[@name='{0}']";

        //getting color class check for attribute class should be equals to selected

        private const string SelectedColor = "li.selected > a";
    }
}
