using DressWebsiteTests.Extensions;
using OpenQA.Selenium;

namespace DressWebsiteTests.Pages.QuickView
{
    public partial class QuickViewPage
    {
        public IWebElement AddToCartButton => Driver.FindElementByName("Submit");

        public IWebElement ProductImage => Driver.FindElementById("bigpic");

        public IWebElement ProductName => Driver.FindElementByCssSelector("h1[itemprop]");

        public IWebElement ProductModel => Driver.FindElementById("product_reference");

        public IWebElement ProductDescription => Driver.FindElementById("short_description_content");

        public IWebElement ProductSize => Driver.FindElementByCssSelector("div#uniform-group_1 > span");

        public IWebElement SelectedColor => Driver.FindElementByCssSelector("li.selected > a");

        public IWebElement ProductPrice => Driver.FindElementById("our_price_display");

        public IWebElement SizeDropdown => Driver.FindElementById("group_1");

        public IWebElement QuantityInputField => Driver.FindElementById("quantity_wanted");

        public IWebElement ProductDiscountPercentage => Driver.FindElementById("reduction_percent_display");

        public IWebElement DesiredProductColor(string colorName)
        {
            return Driver.FindElementByXpath($"//a[@name='{colorName}']");
        }
    }
}