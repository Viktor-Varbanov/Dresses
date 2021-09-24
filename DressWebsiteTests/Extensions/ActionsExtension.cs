using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DressWebsiteTests.Extensions
{
    public static class ActionsExtension
    {
        public static void HoverElement(this Actions action, IWebElement element)
        {
            action.MoveToElement(element).Perform();
        }
    }
}