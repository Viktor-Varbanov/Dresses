namespace Dresses.Pages.Main
{
    using static Driver;
    using AbstractionPageComponents;
    using Models;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using SeleniumExtras.WaitHelpers;

    public class MainPage : AbstractPage<MainPageElementMap>
    {
        private readonly Product _product;

        public MainPage(Product product)
        {
            _product = product;
        }

        public void NavigateToPage()
        {
            Browser.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        public void ScrollDownToDress()
        {
            ((IJavaScriptExecutor)Browser)
                .ExecuteScript("arguments[0].scrollIntoView(true);", Map().GetDress(_product.Name, _product.BaseImageUrl));
        }

        public void HoverDress()
        {
            var actions = new Actions(Browser);
            actions.MoveToElement(Map().GetDress(_product.Name, _product.BaseImageUrl)).Perform();
        }

        public void ClickQuickViewButton()
        {
            var dress = Driver.Browser.FindElement(By.XPath(Map().GetDressQuickView(_product.Name, _product.BaseImageUrl)));
            BrowserWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Map().GetDressQuickView(_product.Name, _product.BaseImageUrl))));
            dress.Click();
            SwitchToIframe();
        }

        private void SwitchToIframe()
        {
            BrowserWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//iframe[@class='fancybox-iframe']")));
            Browser.SwitchTo().Frame(Map().QuickViewIframeWindow);
        }
    }
}
