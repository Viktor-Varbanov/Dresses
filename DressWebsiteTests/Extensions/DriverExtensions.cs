using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

        public static IWebElement FindElementByXpath(this IWebDriver webDriver, string xpathToFind)
        {
            return webDriver.FindElement(By.XPath(xpathToFind));
        }

        public static IWebElement FindElementById(this IWebDriver webDriver, string idToFind)
        {
            return webDriver.FindElement(By.Id(idToFind));
        }

        public static IWebElement FindElementByClassName(this IWebDriver webDriver, string classNameToFind)
        {
            return webDriver.FindElement(By.ClassName(classNameToFind));
        }

        public static IWebElement FindElementByTagName(this IWebDriver webDriver, string tagNameToFind)
        {
            return webDriver.FindElement(By.TagName(tagNameToFind));
        }

        public static IWebElement FindElementByCssSelector(this IWebDriver webDriver, string cssSelectorToFind)
        {
            return webDriver.FindElement(By.CssSelector(cssSelectorToFind));
        }

        public static IWebElement FindElementByName(this IWebDriver webDriver, string nameToFind)
        {
            return webDriver.FindElement(By.Name(nameToFind));
        }
    }
}