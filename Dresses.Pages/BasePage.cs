namespace Dresses.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public abstract class BasePage
    {
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;

        protected BasePage()
        {
            driver = Driver.Browser;
            wait = Driver.BrowserWait;
        }
    }
}
