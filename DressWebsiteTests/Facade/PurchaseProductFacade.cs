using DressWebsiteTests.Model;
using DressWebsiteTests.Pages.Cart;
using DressWebsiteTests.Pages.Main;
using DressWebsiteTests.Pages.PurchaseSummary;
using DressWebsiteTests.Pages.QuickView;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DressWebsiteTests.Facade
{
    public class PurchaseProductFacade
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWait _webDriverWait;

        private readonly Actions _actions;
        private readonly ProductInformation _productInformation;

        public PurchaseProductFacade(IWebDriver webDriver, WebDriverWait webDriverWait, Actions actions, ProductInformation productInformation)
        {
            _webDriver = webDriver;
            _webDriverWait = webDriverWait;
            _actions = actions;
            _productInformation = productInformation;
        }

        private MainPage _mainPage => new MainPage(_webDriver, _webDriverWait, _actions);

        private QuickViewPage _quickViewPage => new QuickViewPage(_webDriver, _webDriverWait, _actions);

        private PurchaseSummary _purchaseSummary => new PurchaseSummary(_webDriver, _webDriverWait, _actions);

        private CartPage _cartPage => new CartPage(_webDriver, _webDriverWait, _actions);

        public void GoToProductQuickView()
        {
            _mainPage.GoTo();
            _mainPage.ChooseDress(_productInformation.Name);
        }

        private void ValidateCorrectProductIsDisplayed()
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

        public void ValidateCorrectProductIsDisplayedOnPurchaseSummary()
        {
            _purchaseSummary.AssertProductSectionHeaderTextIsCorrect();
            _purchaseSummary.AssertCorrectProductImageIsDisplayed(_productInformation.BaseImageUrl);
            _purchaseSummary.AssertCorrectProductNameIsDisplayed(_productInformation.Name);
            _purchaseSummary.AssertCorrectProductColorIsDisplayed(_productInformation.Color);
            _purchaseSummary.AssertCorrectProductSizeIsDisplayed(_productInformation.Size);
            _purchaseSummary.AssertProductQuantityIsDisplayed(_productInformation.Quantity);
            _purchaseSummary.AssertCorrectProductTotalCostIsDisplayed((double)_productInformation.Price * _productInformation.Quantity);

            //ToDo: Add cart validation
        }

        public void ValidateCart()
        {
            _cartPage.AssertCartPageHeader();
            _cartPage.AssertCorrectProductColorIsDisplayed(_productInformation.Id, _productInformation.Color);
            _cartPage.AssertCorrectProductNameIsDisplayed(_productInformation.Id, _productInformation.Name);
            _cartPage.AssertCorrectProductImageIsDisplayed(_productInformation.Id, _productInformation.BaseImageUrl);
            _cartPage.AssertProductModel(_productInformation.Id, _productInformation.Model);
            _cartPage.AssertCorrectProductSizeIsDisplayed(_productInformation.Id, _productInformation.Size);
            _cartPage.AssertProductAvailability(_productInformation.Id, _productInformation.Availability);
            _cartPage.AssertCorrectProductPriceIsDisplayed(_productInformation.Id, _productInformation.Price);
            _cartPage.AssertProductQuantity(_productInformation.Id, _productInformation.Quantity);
            _cartPage.AssertProductCost(_productInformation.Id, _productInformation.Price * _productInformation.Quantity);
            if (_productInformation.HasDiscount)
            {
                _cartPage.AssertCorrectProductDiscountIsDisplayed(_productInformation.Id, _productInformation.PercentageDiscount);
            }
        }

        public void ProceedToCheckout()
        {
            _purchaseSummary.ProceedToCHeckout();
        }

        public void AddProductToCart()
        {
            _quickViewPage.AddToCart();
        }

        public void ChangeProductAttributes(string color, string size, int quantity)
        {
            _quickViewPage.ChangeProductColorTo(color);
            _quickViewPage.ChangeProductSizeTo(size);
            _quickViewPage.IncreaseProductQuantityTo(quantity.ToString());
            ValidateCorrectProductIsDisplayed();
        }
    }
}