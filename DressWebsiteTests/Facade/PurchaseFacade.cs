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

    public class PurchaseFacade
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWait _webDriverWait;
        private readonly Actions _actions;
        private readonly Product _product;

        public PurchaseFacade(IWebDriver webDriver, WebDriverWait webDriverWait, Actions actions, Product product)
        {
            _webDriver = webDriver;
            _webDriverWait = webDriverWait;
            _actions = actions;
            _product = product;
        }

        private MainPage _mainPage => new MainPage(_webDriver, _webDriverWait, _actions);

        private QuickViewPage _quickViewPage => new QuickViewPage(_webDriver, _webDriverWait, _actions);

        private PurchaseSummary _purchaseSummary => new PurchaseSummary(_webDriver, _webDriverWait, _actions);

        private CartPage _cartPage => new CartPage(_webDriver, _webDriverWait, _actions);


        public void PurchaseProduct()
        {
            NavigateToProduct();
            ValidateProductInforationInQuickView();
            _quickViewPage.AddToCart();
            ValidateProductInformationInPurchaseSummary();
            _purchaseSummary.ProceedToCheckout();
            _cartPage.WaitForPageToLoad();
            ValidateCartInformation();
        }

        public void PurchaseProduct(string color, string size, int quantity)
        {
            NavigateToProduct();
            ChangeProductColorSizeAndQuantity(color, size, quantity);
            ValidateProductInforationInQuickView();
            _quickViewPage.AddToCart();
            ValidateProductInformationInPurchaseSummary();
            _purchaseSummary.ProceedToCheckout();
            _cartPage.WaitForPageToLoad();
            ValidateCartInformation();
        }


        private void NavigateToProduct()
        {
            _mainPage.GoTo();
            _mainPage.ChooseDress(_product.Name);
        }

        private void ChangeProductColorSizeAndQuantity(string color, string size, int quantity)
        {
            _quickViewPage.ChangeProductColorTo(color);
            _quickViewPage.ChangeProductSizeTo(size);
            _quickViewPage.IncreaseProductQuantityTo(quantity.ToString());
        }
        private void ValidateProductInforationInQuickView()
        {
            _quickViewPage.AssertCorrectProductImageIsDisplayed(_product.BaseImageUrl);
            _quickViewPage.AssertCorrectProductNameIsDisplayed(_product.Name);
            _quickViewPage.AssertCorrectProductModelIsDisplayed(_product.Model);
            _quickViewPage.AssertCorrectProductDescriptionIsDisplayed(_product.Description);
            _quickViewPage.AssertCorrectProductSizeIsDisplayed(_product.Size);
            _quickViewPage.AssertCorrectProductColorIsDisplayed(_product.Color);
            _quickViewPage.AssertCorrectProductPriceIsDisplayed(_product.Price);
            if (_product.HasDiscount)
            {
                _quickViewPage.AssertCorrectProductDiscountPercantageIsDisplayed(_product.PercentageDiscount);
            }
        }

        private void ValidateProductInformationInPurchaseSummary()
        {
            _purchaseSummary.AssertProductSectionHeaderTextIsCorrect();
            _purchaseSummary.AssertCorrectProductImageIsDisplayed(_product.BaseImageUrl);
            _purchaseSummary.AssertCorrectProductNameIsDisplayed(_product.Name);
            _purchaseSummary.AssertCorrectProductColorIsDisplayed(_product.Color);
            _purchaseSummary.AssertCorrectProductSizeIsDisplayed(_product.Size);
            _purchaseSummary.AssertProductQuantityIsDisplayed(_product.Quantity);
            _purchaseSummary.AssertCorrectProductTotalCostIsDisplayed((double)_product.Price * _product.Quantity);
        }

        private void ValidateCartInformation()
        {
            _cartPage.AssertCartPageHeader();
            _cartPage.AssertCorrectProductNameIsDisplayed(_product.Id, _product.Name);
            _cartPage.AssertCorrectProductColorIsDisplayed(_product.Id, _product.Color);
            _cartPage.AssertCorrectProductImageIsDisplayed(_product.Id, _product.BaseImageUrl);
            _cartPage.AssertProductModel(_product.Id, _product.Model);
            _cartPage.AssertCorrectProductSizeIsDisplayed(_product.Id, _product.Size);
            _cartPage.AssertProductAvailability(_product.Id, _product.Availability);
            _cartPage.AssertCorrectProductPriceIsDisplayed(_product.Id, _product.Price);
            _cartPage.AssertProductQuantity(_product.Id, _product.Quantity);
            _cartPage.AssertProductCost(_product.Id, _product.Price * _product.Quantity);
            if (_product.HasDiscount)
            {
                _cartPage.AssertCorrectProductDiscountIsDisplayed(_product.Id, _product.PercentageDiscount);
            }
        }
    }
}
