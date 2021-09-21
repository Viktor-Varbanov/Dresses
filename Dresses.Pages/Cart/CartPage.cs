namespace Dresses.Pages.Cart
{
    using AbstractionPageComponents;
    using OpenQA.Selenium;
    using SeleniumExtras.WaitHelpers;

    public class CartPage : AbstractPageWithValidator<CartElementMap, CartValidator>
    {
        public void WaitForPageToLoad()
        {
            Driver.BrowserWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='center_column']")));
        }
    }
}