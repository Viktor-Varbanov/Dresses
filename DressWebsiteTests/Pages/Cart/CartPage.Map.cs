using DressWebsiteTests.Extensions;
using OpenQA.Selenium;

namespace DressWebsiteTests.Pages.Cart
{
    public partial class CartPage
    {
        public IWebElement CartPageHeader => Driver.FindElementById("cart_title");

        public IWebElement ProductName(string productId)
        {
            return Driver.FindElement(By.XPath($"//tr[@id='{productId}']//p"));
        }

        public IWebElement ProductImageUrl(string productId)
        {
            return Driver.FindElementByXpath($"//tr[@id='{productId}']//child::td[@class='cart_product']//img");
        }

        public IWebElement ProductDiscount(string productId)
        {
            return Driver.FindElementByXpath($"//tr[@id='{productId}']//span[@class='price-percent-reduction small']");
        }

        public IWebElement ProductAttributes(string productId)
        {
            return Driver.FindElementByXpath($"//tr[@id='{productId}']//small//a");
        }

        public IWebElement ProductPrice(string productId)
        {
            return Driver.FindElementByXpath($"//tr[@id='{productId}']//span[@class='price']");
        }

        public IWebElement ProductQuantity(string productId)
        {
            return Driver.FindElementByXpath($"//tr[@id='{productId}']//input[@type='hidden']");
        }

        public IWebElement ProductAvailability(string productId)
        {
            return Driver.FindElementByXpath($"//tr[@id='{productId}']//span[@class='label label-success']");
        }

        public IWebElement ProductModel(string productId)
        {
            return Driver.FindElementByXpath($"//tr[@id='{productId}']//small[@class='cart_ref']");
        }

        public IWebElement ProductTotalCost(string productId)
        {
            return Driver.FindElementByXpath($"//tr[@id='{productId}']//td[@class='cart_total']");
        }

        public IWebElement TotalProductsCost => Driver.FindElementById("total_product");

        public IWebElement ShippingCost => Driver.FindElementById("total_shipping");

        public IWebElement TotalProductsPriceWithShipping => Driver.FindElementById("total_price_without_tax");

        public IWebElement TaxesCosts => Driver.FindElementById("'total_tax");

        public IWebElement TotalProductsCostWithTaxes => Driver.FindElementById("total_price");
    }
}