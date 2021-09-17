namespace demo
{
    using OpenQA.Selenium;

    public class AbstractPageMap
    {
        protected readonly IWebDriver driver;

        public AbstractPageMap()
        {
            driver = null;
        }
    }
}
