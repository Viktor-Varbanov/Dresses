using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DressWebsiteTests.Pages
{
    public abstract class WebPage
    {
        protected WebPage(IWebDriver driver, WebDriverWait webDriverWait, Actions actions)
        {
            Driver = driver;
            WebDriverWait = webDriverWait;
            Actions = actions;
        }

        protected IWebDriver Driver { get; set; }

        protected WebDriverWait WebDriverWait { get; set; }

        protected Actions Actions { get; set; }

    }
}
