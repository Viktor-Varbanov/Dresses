namespace DressWebsiteTests.Pages.QuickView
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    public partial class QuickViewPage : WebPage
    {

        public QuickViewPage(IWebDriver driver, WebDriverWait webDriverWait, Actions actions) : base(driver, webDriverWait, actions)
        {
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
    }
}
