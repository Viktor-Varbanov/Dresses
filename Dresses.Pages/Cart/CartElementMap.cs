//namespace Dresses.Pages.Cart
//{
//    using AbstractionPageComponents;
//    using Common;
//    using OpenQA.Selenium;

//    public class CartElementMap : AbstractElementMap
//    {
//        private const string BaseProductXpath = "//tbody//tr[@id='{0}']";

//        public IWebElement CartTitleMessage => driver.FindElement(By.Id("cart_title"));

//        public IWebElement ProductName(string productId) => driver.FindElement(By.XPath(XPathBuilder.BuildXpath(BaseProductXpath,
//            "//child::td[@class='cart_description']//p", productId)));

//        public IWebElement ProductImageUrl(string productId) => driver.FindElement(By.XPath(XPathBuilder.BuildXpath(BaseProductXpath, "//child::td[@class='cart_product']//img", productId)));

//        public IWebElement ProductAttributes(string productId) => driver.FindElement(By.XPath(XPathBuilder.BuildXpath(BaseProductXpath, "//child::td[@class='cart_description']//small//a", productId)));

//        public IWebElement ProductPrice(string productId) => driver.FindElement(By.XPath(XPathBuilder.BuildXpath(BaseProductXpath, "//child::td[@class='cart_unit']//span//span", productId)));

//        public IWebElement ProductQuantity(string productId)
//        {
//            string nameId = productId.Replace("product", "quantity");
//            string finalName = nameId + "_hidden";
//            return driver.FindElement(
//                By.XPath(XPathBuilder.BuildXpath(BaseProductXpath, "//child::input[@type='hidden' and @name='{1}']",
//                      productId, finalName)));
//        }

//        public IWebElement ProductAvailability(string productId) => driver.FindElement(
//            By.XPath(XPathBuilder.BuildXpath(BaseProductXpath, "//child::td[@class='cart_avail']//span", productId)));

//        public IWebElement ProductModel(string productId) => driver.FindElement(
//            By.XPath(XPathBuilder.BuildXpath(BaseProductXpath, "//child::small[@class='cart_ref']", productId)));

//        public IWebElement TotalPriceForProduct(string productId) => driver.FindElement(
//            By.XPath(XPathBuilder.BuildXpath(BaseProductXpath, "//child::td[@class='cart_total']//span", productId)));

//        public IWebElement TotalProductsPrice =>
//            driver.FindElement(By.XPath("//div[@id='center_column']//tfoot//td[@id='total_product']"));

//        public IWebElement TotalShipping =>
//            driver.FindElement(By.XPath("//div[@id='center_column']//tfoot//td[@id='total_shipping']"));

//        public IWebElement TotalProductsPriceWithShipping =>
//            driver.FindElement(By.XPath("//div[@id='center_column']//tfoot//td[@id='total_price_without_tax']"));

//        public IWebElement Taxes => driver.FindElement(By.XPath("//div[@id='center_column']//tfoot//td[@id='total_tax']"));
//    }
//}