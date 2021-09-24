using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DressWebsiteTests.Pages.Cart
{
    public partial class CartPage : WebPage
    {
        public CartPage(IWebDriver driver, WebDriverWait webDriverWait, Actions actions) : base(driver, webDriverWait, actions)
        {
        }
    }
}
