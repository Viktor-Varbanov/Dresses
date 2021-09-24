using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DressWebsiteTests.Extensions
{
    public static class WebDriverWaitExtensions
    {
        public static void UntilElementIsClickable(this WebDriverWait wait, IWebElement element)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void UntilElementIsVisible(this WebDriverWait wait, By by)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}