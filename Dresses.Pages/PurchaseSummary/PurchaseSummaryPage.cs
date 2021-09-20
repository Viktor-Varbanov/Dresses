namespace Dresses.Pages.PurchaseSummary
{
    using AbstractionPageComponents;
    using OpenQA.Selenium;
    using SeleniumExtras.WaitHelpers;

    public class PurchaseSummaryPage : AbstractPageWithValidator<PurchaseSummaryElementMap, PurchaseSummaryValidator>
    {
        public void ProceedToCheckout()
        {
            WaitToBeClickable();
            Map.ProceedToCheckout.Click();
            SwitchToCartPage();
        }

        private void WaitToBeClickable()
        {
            Driver.BrowserWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(
                "//div[@class='button-container']//a[@href='http://automationpractice.com/index.php?controller=order']")));
        }

        private void SwitchToCartPage()
        {
            Driver.BrowserWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div#center_column")));
        }
    }
}