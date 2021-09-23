//namespace Dresses.Pages.QuickView
//{
//    using 
//    using OpenQA.Selenium;

//    public class QuickViewPageElementMap 
//    {
//        public IWebElement AddToCartButton => driver.FindElement(By.XPath("//p[@id='add_to_cart']//button"));

//        public IWebElement Image => driver.FindElement(By.Id("bigpic"));

//        public IWebElement Name =>
//            driver.FindElement(
//                By.XPath("//body[@id='product']//child::div[@class='pb-center-column col-xs-12 col-sm-4']//h1"));

//        public IWebElement Description => driver.FindElement(By.XPath("//div[@id='short_description_block']//child::p"));
//        //private const string VerifyProductDescription = "//div[@id='short_description_block']//child::p";

//        public IWebElement Price => driver.FindElement(By.Id("our_price_display"));

//        public IWebElement Size => driver.FindElement(By.XPath("//div[@id='uniform-group_1']//span"));

//        public IWebElement SizeDropdown => driver.FindElement(By.XPath("//select[@id='group_1']"));

//        public IWebElement Model => driver.FindElement(By.XPath("//p[@id='product_reference']//span"));

//        public IWebElement Discount => driver.FindElement(By.Id("reduction_percent_display"));

//        public IWebElement QuantityInputField => driver.FindElement(By.XPath("//input[@id='quantity_wanted']"));

//        //dynamically adding color
//        public IWebElement ColorPickerXpath(string name) => driver.FindElement(By.XPath($"//ul[@id='color_to_pick_list']//li//a[@name='{name}']"));

//        public IWebElement PickedColor => driver.FindElement(By.CssSelector("li.selected > a"));

//        public IWebElement LayerCart => driver.FindElement(By.Id("layer_cart"));
//    }
//}