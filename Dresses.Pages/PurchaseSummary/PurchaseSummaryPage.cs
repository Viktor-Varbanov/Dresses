namespace Dresses.Pages.PurchaseSummary
{
    using AbstractionPageComponents;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;

    public class PurchaseSummaryPage : AbstractPageWithValidator<PurchaseSummaryElementMap, PurchaseSummaryValidator>
    {
        public void ProceedToCheckout()
        {
            WaitToBeClickable();
            Map.ProceedToCheckout.Click();
        }

        private void WaitToBeClickable()
        {
            Driver.BrowserWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(
                "//div[@class='button-container']//a[@href='http://automationpractice.com/index.php?controller=order']")));

        }
    }
}
