namespace Dresses.Pages.Main
{
    using static Driver;
    using AbstractionPageComponents;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using SeleniumExtras.WaitHelpers;

    public class MainPage : AbstractPage<MainPageElementMap>
    {


        public void NavigateToPage()
        {
            Browser.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        public void ScrollDownToDress(string productName, string productImageUrl)
        {
            ((IJavaScriptExecutor)Browser)
                .ExecuteScript("arguments[0].scrollIntoView(true);", Map.GetDress(productName, productImageUrl));
        }

        public void HoverDress(string productName, string productImageUrl)
        {
            var actions = new Actions(Browser);
            actions.MoveToElement(Map.GetDress(productName, productImageUrl)).Perform();
        }

        //extract at quick view
        public void ClickQuickViewButton(string productName, string productImageUrl)
        {
            var dress = Map.GetDressQuickView(productName, productImageUrl);
            BrowserWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Map.GetDressQuickViewLocator(productName, productImageUrl))));
            dress.Click();
            SwitchToIframe();
        }

        private void SwitchToIframe()
        {
            BrowserWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Map.QuickViewIframeWindowLocator)));
            Browser.SwitchTo().Frame(Map.QuickViewIframeWindow);
        }
    }
}
