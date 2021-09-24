using OpenQA.Selenium;

namespace DressWebsiteTests.Pages.PurchaseSummary
{
    public partial class PurchaseSummary
    {

        //Product Information
        public IWebElement ProductSectionHeaderText => Driver.FindElement(By.TagName("h2"));

        public IWebElement ProductName => Driver.FindElement(By.Id("layer_cart_product_title"));

        public IWebElement ProductImageUrl => Driver.FindElement(By.ClassName("//div[@id='layer_cart']//child::img"));

        public IWebElement ProductQuantity => Driver.FindElement(By.Id("layer_cart_product_quantity"));

        public IWebElement CurrentlyAddedProductTotalPrice => Driver.FindElement(By.Id("layer_cart_product_price"));

        public IWebElement ProductAttributes => Driver.FindElement(By.Id("layer_cart_product_attributes"));

        public IWebElement CurrentlyAddedProductCost => Driver.FindElement(By.Id("layer_cart_product_price"));

        //        //Cart state
        public IWebElement CartSectionHeaderText => Driver.FindElement(By.CssSelector("h2 > span"));
        //        public IWebElement ProductsInCartQuantity => driver.FindElement(
        //            By.XPath("//div[@class='layer_cart_cart col-xs-12 col-md-6']//h2//span[@class='ajax_cart_quantity']"));

        public IWebElement ProductsCost => Driver.FindElement(By.ClassName("ajax_block_products_total"));

        //        // if driver don't find it because it is focused in current screen but first element is in the backgroudn page

        public IWebElement ShippingCost => Driver.FindElement(By.ClassName("ajax_cart_shipping_cost"));

        public IWebElement TotalCost => Driver.FindElement(By.ClassName("ajax_block_cart_total"));


        public IWebElement ProceedToCheckout =>
            Driver.FindElement(By.XPath("//a[@title='Proceed to checkout']"));
    }
}
