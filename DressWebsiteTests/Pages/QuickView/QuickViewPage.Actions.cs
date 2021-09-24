using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DressWebsiteTests.Pages.QuickView
{
    public partial class QuickViewPage : WebPage
    {
        public QuickViewPage(IWebDriver driver, WebDriverWait webDriverWait, Actions actions) : base(driver, webDriverWait, actions)
        {
        }

        public void AddToCart()
        {
            AddToCartButton.Click();
            SwitchToSummary();
        }

        public void IncreaseProductQuantityTo(string desiredProductQuantity)
        {
            QuantityInputField.Clear();
            QuantityInputField.SendKeys(desiredProductQuantity);
        }

        public void ChangeProductColorTo(string desiredProductColor)
        {
            DesiredProductColor(desiredProductColor).Click();
        }

        public void ChangeProductSizeTo(string desiredProductSize)
        {
            var dropdown = new SelectElement(SizeDropdown);
            dropdown.SelectByText(desiredProductSize);
        }

        private void SwitchToSummary()
        {
            Driver.SwitchTo().ParentFrame();
            WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='layer_cart_product col-xs-12 col-md-6']")));
        }
    }
}