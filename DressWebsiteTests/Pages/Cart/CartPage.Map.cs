using OpenQA.Selenium;

namespace DressWebsiteTests.Pages.Cart
{
    public partial class CartPage
    {

        //        public IWebElement CartTitleMessage => driver.FindElement(By.Id("cart_title"));

        public IWebElement ProductName(string productId)
        {
            return Driver.FindElement(By.XPath($"//tr[@id='{productId}']//p"));

        }

        public IWebElement ProductImageUrl(string productId)
        {
            return Driver.FindElement(By.XPath($"//tr[@id='{productId}']//child::td[@class='cart_product']//img"));
        }

        public IWebElement ProductAttributes(string productId)
        {
            return Driver.FindElement(By.XPath($"//tr[@id='{productId}']//small//a"));
        }

        public IWebElement ProductPrice(string productId)
        {

            return Driver.FindElement(By.XPath($"//tr[@id='{productId}']//span[@class='price']"));
        }

        public IWebElement ProductQuantity(string productId)
        {
            return Driver.FindElement(By.XPath($"//tr[@id='{productId}']//input[@type='hidden']"));
        }

        public IWebElement ProductAvailability(string productId)
        {
            return Driver.FindElement(By.XPath($"//tr[@id='{productId}']//span[@class='label label-success']"));
        }


        public IWebElement ProductModel(string productId)
        {
            return Driver.FindElement(By.XPath($"//tr[@id='{productId}']//small[@class='cart_ref']"));
        }

        public IWebElement ProductTotalCost(string productId)
        {
            return Driver.FindElement(By.XPath($"//tr[@id='{productId}']//td[@class='cart_total']"));
        }

        public IWebElement TotalProductsCost => Driver.FindElement(By.Id("total_product"));

        public IWebElement ShippingCost => Driver.FindElement(By.Id("total_shipping"));

        public IWebElement TotalProductsPriceWithShipping => Driver.FindElement(By.XPath("total_price_without_tax"));

        public IWebElement TaxesCosts => Driver.FindElement(By.XPath("'total_tax"));

        public IWebElement TotalProductsCostWithTaxes => Driver.FindElement(By.Id("total_price"));
    }
}
