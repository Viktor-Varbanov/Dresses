using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using DressWebsiteTests.Extensions;

namespace DressWebsiteTests.Pages.Cart
{
    public partial class CartPage : WebPage
    {
        public CartPage(IWebDriver driver, WebDriverWait webDriverWait, Actions actions) : base(driver, webDriverWait, actions)
        {
        }
     
        public void WaitForPageToLoad()
        {
            Driver.SwitchTo().ParentFrame();
            WebDriverWait.UntilElementIsVisible(By.Id("columns"));
        }
    }
}