namespace DressWebsiteTests.Pages.QuickView
{
    using OpenQA.Selenium;

    public partial class QuickViewPage
    {
        public IWebElement AddToCartButton => Driver.FindElement(By.Name("Submit"));

        public IWebElement ProductImage => Driver.FindElement(By.Id("bigpic"));

        public IWebElement ProductName => Driver.FindElement(By.XPath("//h1[@itemprop='name']"));

        public IWebElement ProductModel => Driver.FindElement(By.Id("product_reference"));

        public IWebElement ProductDescription => Driver.FindElement(By.Id("short_description_content"));

        public IWebElement ProductSize => Driver.FindElement(By.CssSelector("div#uniform-group_1 > span"));

        public IWebElement SelectedColor => Driver.FindElement(By.CssSelector("li.selected > a"));

        public IWebElement ProductPrice => Driver.FindElement(By.Id("our_price_display"));

        public IWebElement SizeDropdown => Driver.FindElement(By.XPath("//select[@id='group_1']"));

        public IWebElement QuantityInputField => Driver.FindElement(By.XPath("//input[@id='quantity_wanted']"));

        public IWebElement ProductDiscountPercentage => Driver.FindElement(By.Id("reduction_percent_display"));

        public IWebElement DesiredProductColor(string colorName)
        {
            return Driver.FindElement(By.XPath($"//a[@name='{colorName}']"));
        }
    }
}
