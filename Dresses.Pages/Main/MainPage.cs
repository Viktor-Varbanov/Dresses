namespace Dresses.Pages.Main
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;
    using System;

    public partial class MainPage : BasePage
    {


        public void NavigateToPage()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        public void NavigateToDress(string name)
        {
            var dressElement = driver.FindElement(By.XPath(string.Format(ProductXpath, name)));
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", dressElement);

        }

        public void HoverElement(string name)
        {
            Actions actions = new Actions(driver);
            IWebElement dress = driver.FindElement(By.XPath(string.Format(ProductXpath, name)));
            actions.MoveToElement(dress).Perform();

        }

        public void ClickQuickView(string name)
        {
            var dress = driver.FindElement(By.XPath(string.Format(ProductQuickView, name)));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format(ProductQuickView, name))));
            dress.Click();
            SwitchToIframe();
        }

        private void SwitchToIframe()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//iframe[@class='fancybox-iframe']")));
            driver.SwitchTo().Frame(QuickViewIframeWindow);
        }



    }
}
