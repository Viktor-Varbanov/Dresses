using DressWebsiteTests.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DressWebsiteTests.Pages.PurchaseSummary
{
    public partial class PurchaseSummary : WebPage
    {
        public PurchaseSummary(IWebDriver driver, WebDriverWait webDriverWait, Actions actions) : base(driver, webDriverWait, actions)
        {
        }

        public void ProceedToCHeckout()
        {
            WaitForPageToLoad();
            ProceedToCheckout.Click();
        }

        protected override void WaitForPageToLoad()
        {
            Driver.SwitchTo().ParentFrame();
            WebDriverWait.UntilElementIsVisible(By.CssSelector("div[class='layer_cart_product col-xs-12 col-md-6']"));
        }
    }
}