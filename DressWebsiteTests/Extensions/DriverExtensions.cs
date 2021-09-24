using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
namespace DressWebsiteTests.Extensions
{
    public static class DriverExtensions
    {
        public static void ScrollToElement(this IWebDriver webDriver, IWebElement webElement)
        {
            ((IJavaScriptExecutor)webDriver)
             .ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
        }
        public static void SwitchToIFrame(this IWebDriver webDriver, WebDriverWait wait, By iframe, IWebElement iframeElement)
        {
            wait.UntilElementIsVisible(iframe);
            webDriver.SwitchTo().Frame(iframeElement);
        }
    }
}
