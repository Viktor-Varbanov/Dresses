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

        public PurchaseFacade(IWebDriver webDriver, WebDriverWait webDriverWait, Actions actions)
        {
            _webDriver = webDriver;
            _webDriverWait = webDriverWait;
            _actions = actions;
        }

        private MainPage _mainPage => new MainPage(_webDriver, _webDriverWait, _actions);

        private QuickViewPage _quickViewPage => new QuickViewPage(_webDriver, _webDriverWait, _actions);

        private PurchaseSummary _purchaseSummary => new PurchaseSummary(_webDriver, _webDriverWait, _actions);

        private CartPage _cartPage => new CartPage(_webDriver, _webDriverWait, _actions);

        public void PurchaseProduct(Product product, Cart cart)
        {
            NavigateToProduct(product.Name);
            ValidateProductInforationInQuickView(product);
            _quickViewPage.AddToCart();
            ValidateProductInformationInPurchaseSummary(product, cart);
            _purchaseSummary.ProceedToCheckout();
            _cartPage.WaitForPageToLoad();
            ValidateCartInformation(product, cart);
        }

        public void PurchaseProduct(Product product, Cart cart, string color, string size, int quantity)
        {
            NavigateToProduct(product.Name);
            ChangeProductColorSizeAndQuantity(color, size, quantity);
            ValidateProductInforationInQuickView(product);
            _quickViewPage.AddToCart();
            ValidateProductInformationInPurchaseSummary(product, cart);
            _purchaseSummary.ProceedToCheckout();
            _cartPage.WaitForPageToLoad();
            ValidateCartInformation(product, cart);
        }

        private void NavigateToProduct(string name)
        {
            _mainPage.GoTo();
            _mainPage.ChooseDress(name);
        }

        private void ChangeProductColorSizeAndQuantity(string color, string size, int quantity)
        {
            _quickViewPage.ChangeProductColorTo(color);
            _quickViewPage.ChangeProductSizeTo(size);
            _quickViewPage.IncreaseProductQuantityTo(quantity.ToString());
        }

        private void ValidateProductInforationInQuickView(Product product)
        {
            _quickViewPage.AssertCorrectProductImageIsDisplayed(product.BaseImageUrl);
            _quickViewPage.AssertCorrectProductNameIsDisplayed(product.Name);
            _quickViewPage.AssertCorrectProductModelIsDisplayed(product.Model);
            _quickViewPage.AssertCorrectProductDescriptionIsDisplayed(product.Description);
            _quickViewPage.AssertCorrectProductSizeIsDisplayed(product.Size);
            _quickViewPage.AssertCorrectProductColorIsDisplayed(product.Color);
            _quickViewPage.AssertCorrectProductPriceIsDisplayed(product.Price);
            if (product.HasDiscount)
            {
                _quickViewPage.AssertCorrectProductDiscountPercantageIsDisplayed(product.PercentageDiscount);
            }
        }

        private void ValidateProductInformationInPurchaseSummary(Product product, Cart cart)
        {
            _purchaseSummary.AssertProductSectionHeaderTextIsCorrect();
            _purchaseSummary.AssertCorrectProductImageIsDisplayed(product.BaseImageUrl);
            _purchaseSummary.AssertCorrectProductNameIsDisplayed(product.Name);
            _purchaseSummary.AssertCorrectProductColorIsDisplayed(product.Color);
            _purchaseSummary.AssertCorrectProductSizeIsDisplayed(product.Size);
            _purchaseSummary.AssertProductQuantityIsDisplayed(product.Quantity);
            _purchaseSummary.AssertCorrectProductTotalCostIsDisplayed((double)product.Price * product.Quantity);
            _purchaseSummary.AssertProductCartText(cart.GetProductsCount());
            _purchaseSummary.AssertTotalProductsCost(cart.GetTotalPrice());
            _purchaseSummary.AssertShippingCost(Cart.SHIPPING_PRICE);
            _purchaseSummary.AssertTotalPrice(cart.GetTotalPrice() + Cart.SHIPPING_PRICE);
        }

        private void ValidateCartInformation(Product product, Cart cart)
        {
            _cartPage.AssertCartPageHeader();
            _cartPage.AssertCorrectProductNameIsDisplayed(product.Id, product.Name);
            _cartPage.AssertCorrectProductColorIsDisplayed(product.Id, product.Color);
            _cartPage.AssertCorrectProductImageIsDisplayed(product.Id, product.BaseImageUrl);
            _cartPage.AssertProductModel(product.Id, product.Model);
            _cartPage.AssertCorrectProductSizeIsDisplayed(product.Id, product.Size);
            _cartPage.AssertProductAvailability(product.Id, product.Availability);
            _cartPage.AssertCorrectProductPriceIsDisplayed(product.Id, product.Price);
            _cartPage.AssertProductQuantity(product.Id, product.Quantity);
            _cartPage.AssertProductCost(product.Id, product.Price * product.Quantity);
            if (product.HasDiscount)
            {
                _cartPage.AssertCorrectProductDiscountIsDisplayed(product.Id, product.PercentageDiscount);
            }
            _cartPage.AssertProductsQuantity(cart.GetProductsCount());
            _cartPage.AssertTotalProductsCost(cart.GetTotalPrice());
            _cartPage.AssertShippingCost(Cart.SHIPPING_PRICE);
            _cartPage.AssertTotalCostIncludingTaxesAndProductCost(cart.GetTotalPrice() + Cart.SHIPPING_PRICE);
        }
    }
}