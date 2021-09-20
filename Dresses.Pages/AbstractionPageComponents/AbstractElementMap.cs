namespace Dresses.Pages.AbstractionPageComponents
{
    using OpenQA.Selenium;

    public abstract class AbstractElementMap
    {
        protected readonly IWebDriver driver;

        protected AbstractElementMap()
        {
            driver = Driver.Browser;
        }
    }
}