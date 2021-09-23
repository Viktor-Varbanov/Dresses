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
        public static void SwitchToIFrame(this IWebDriver webDriver, string iframe, IWebElement iframeElement)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(iframe)));

            webDriver.SwitchTo().Frame(iframeElement);
        }
    }
}
