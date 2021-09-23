//namespace Dresses.Pages.PurchaseSummary
//{
//    using AbstractionPageComponents;
//    using OpenQA.Selenium;

//    public class PurchaseSummaryElementMap : AbstractElementMap
//    {
//        //Product Information
//        public IWebElement SuccessfulMessage =>
//            driver.FindElement(By.XPath("//div[@class='layer_cart_product col-xs-12 col-md-6']//h2"));

//        public IWebElement ProductName => driver.FindElement(By.Id("layer_cart_product_title"));

//        public IWebElement ProductImageUrl =>
//            driver.FindElement(By.XPath("//div[@id='layer_cart']//child::div//img"));

//        public IWebElement ProductQuantity => driver.FindElement(By.Id("layer_cart_product_quantity"));

//        public IWebElement Total => driver.FindElement(By.Id("layer_cart_product_price"));

//        public IWebElement ProductColorAndSize => driver.FindElement(By.Id("layer_cart_product_attributes"));

//        //Cart state

//        public IWebElement ProductsInCartQuantity => driver.FindElement(
//            By.XPath("//div[@class='layer_cart_cart col-xs-12 col-md-6']//h2//span[@class='ajax_cart_quantity']"));

//        public IWebElement CartProductPrice => driver.FindElement(By.ClassName("ajax_block_products_total"));

//        // if driver don't find it because it is focused in current screen but first element is in the backgroudn page

//        public IWebElement ShippingPrice => driver.FindElement(By.ClassName("ajax_cart_shipping_cost"));

//        public IWebElement TotalPrice => driver.FindElement(By.ClassName("ajax_block_cart_total"));

//        //That doesnt work by first lets make assertions
//        public IWebElement ProceedToCheckout =>
//            driver.FindElement(By.XPath("//div[@class='button-container']//a[@href='http://automationpractice.com/index.php?controller=order']"));
//    }
//}