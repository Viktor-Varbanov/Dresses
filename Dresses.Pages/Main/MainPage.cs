namespace Dresses.Pages.Main
{
    using AbstractionPageComponents;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using SeleniumExtras.WaitHelpers;
    using static Driver;

    public class MainPage : AbstractPage<MainPageElementMap>
    {
        private string _productName;
        private string _productImageUrl;
        private Actions _actions = new Actions(Browser);

        public void NavigateToPage()
        {
            Browser.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        public void ScrollDownToDress(string productName, string productImageUrl)
        {
            _productName = productName;
            _productImageUrl = productImageUrl;
            ((IJavaScriptExecutor)Browser)
                .ExecuteScript("arguments[0].scrollIntoView(true);", Map.DressLocation(_productName, _productImageUrl));
        }

        public void HoverDress()
        {
            _actions.MoveToElement(Map.DressLocation(_productName, _productImageUrl)).Perform();
        }

        public void ClickQuickViewButton()
        {
            IWebElement dressQuickViewButton = Map.GetDressQuickViewButton(_productName, _productImageUrl);
            BrowserWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Map.GetDressQuickViewLocator(_productName, _productImageUrl))));
            dressQuickViewButton.Click();
            SwitchToIframe();
        }

        private void SwitchToIframe()
        {
            BrowserWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Map.QuickViewIframeWindowLocator)));
            Browser.SwitchTo().Frame(Map.QuickViewIframeWindow);
        }
    }
}