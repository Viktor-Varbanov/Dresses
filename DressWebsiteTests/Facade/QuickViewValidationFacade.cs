using DressWebsiteTests.Model;
using DressWebsiteTests.Pages.Main;
using DressWebsiteTests.Pages.QuickView;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DressWebsiteTests.Facade
{
    public class QuickViewValidationFacade
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWait _webDriverWait;
        private readonly Actions _actions;
        private readonly ProductInformation _productInformation;

        public QuickViewValidationFacade(IWebDriver webDriver, WebDriverWait webDriverWait, Actions actions, ProductInformation productInformation)
        {
            _webDriver = webDriver;
            _webDriverWait = webDriverWait;
            _actions = actions;
            _productInformation = productInformation;
        }

        private MainPage _mainPage => new MainPage(_webDriver, _webDriverWait, _actions);
        private QuickViewPage _quickViewPage => new QuickViewPage(_webDriver, _webDriverWait, _actions);

        public void GoToProductQuickView()
        {
            _mainPage.GoTo();
            _mainPage.ChooseDress(_productInformation.Name);
        }

        public void ValidateCorrectProductIsDisplayed()
        {
            _quickViewPage.AssertCorrectProductImageIsDisplayed(_productInformation.BaseImageUrl);
            _quickViewPage.AssertCorrectProductNameIsDisplayed(_productInformation.Name);
            _quickViewPage.AssertCorrectProductModelIsDisplayed(_productInformation.Model);
            _quickViewPage.AssertCorrectProductDescriptionIsDisplayed(_productInformation.Description);
            _quickViewPage.AssertCorrectProductSizeIsDisplayed(_productInformation.Size);
            _quickViewPage.AssertCorrectProductColorIsDisplayed(_productInformation.Color);
            _quickViewPage.AssertCorrectProductPriceIsDisplayed(_productInformation.Price);
            if (_productInformation.HasDiscount)
            {
                _quickViewPage.AssertCorrectProductDiscountPercantageIsDisplayed(_productInformation.PercentageDiscount);
            }
        }

        public void ChangeProductAttributes(string color, string size, int quantity)
        {
            _quickViewPage.ChangeProductColorTo(color);
            _quickViewPage.ChangeProductSizeTo(size);
            _quickViewPage.IncreaseProductQuantityTo(quantity.ToString());
        }
    }
}