namespace Dresses.Tests
{
    using Models;
    using NUnit.Framework;
    using Pages.Cart;
    using Pages.Main;
    using Pages.PurchaseSummary;
    using Pages.QuickView;

    [TestFixture]
    public class DressesTests
    {
        private Database _database;
        private MainPage _mainPage;
        private QuickViewPage _quickViewPage;
        private PurchaseSummaryPage _purchaseSummaryPage;
        private CartPage _cartPage;

        [SetUp]
        public void SetUp()
        {
            Driver.StartBrowser();
            _mainPage = new MainPage();
            _database = new Database();
            _quickViewPage = new QuickViewPage();
            _purchaseSummaryPage = new PurchaseSummaryPage();
            _cartPage = new CartPage();
        }

        [Test]
        public void CorrectProductIsDisplayedOnQuickView_When_ProductQuickViewButtonIsClicked()
        {
            // --Arrange
            Product product = _database.GetProductById("product_7_34_0_0");
            _mainPage.NavigateToPage();
            _mainPage.ScrollDownToDress("Printed Chiffon Dress", "http://automationpractice.com/img/p/2/0/20");
            _mainPage.HoverDress();

            // --Act
            _mainPage.ClickQuickViewButton();

            // --Assert
            _quickViewPage.Validate.CorrectProductNameIsDisplayed(product.Name);
            _quickViewPage.Validate.CorrectProductImageUrlIsDisplayed(product.BaseImageUrl);
            _quickViewPage.Validate.CorrectProductDescriptionIsDisplayed(product.Description);
            _quickViewPage.Validate.CorrectProductPriceIsDisplayed(product.Price);
            _quickViewPage.Validate.CorrectProductSizeIsDisplayed(product.Size);
            _quickViewPage.Validate.CorrectProductColorIsDisplayed(product.Color);
            _quickViewPage.Validate.CorrectProductModelIsDisplayed(product.Model);
            if (product.HasDiscount)
            {
                _quickViewPage.Validate.CorrectDiscountIsDisplayed(product.PercentageDiscount);
            }
        }

        [Test]
        [TestCase("M", "20")]
        public void CorrectProductIsAddedToCart(string desiredSize, string desiredQuantity)
        {
            // --Arrange
            Product blackBlouse = _database.GetProductById("product_2_7_0_0");
            Product whiteBlouse = _database.GetProductById("product_2_8_0_0");
            whiteBlouse.Size = desiredSize;
            whiteBlouse.Quantity = int.Parse(desiredQuantity);
            whiteBlouse.Id = "product_2_10_0_0";
            Cart.AddProductToCart(whiteBlouse);
            _mainPage.NavigateToPage();
            _mainPage.ScrollDownToDress("Blouse", "http://automationpractice.com/img/p/7/7");
            _mainPage.HoverDress();
            _mainPage.ClickQuickViewButton();

            _quickViewPage.Validate.CorrectProductNameIsDisplayed(blackBlouse.Name);
            _quickViewPage.Validate.CorrectProductImageUrlIsDisplayed(blackBlouse.BaseImageUrl);
            _quickViewPage.Validate.CorrectProductDescriptionIsDisplayed(blackBlouse.Description);
            _quickViewPage.Validate.CorrectProductPriceIsDisplayed(blackBlouse.Price);
            _quickViewPage.Validate.CorrectProductSizeIsDisplayed(blackBlouse.Size);
            _quickViewPage.Validate.CorrectProductColorIsDisplayed(blackBlouse.Color);
            _quickViewPage.Validate.CorrectProductModelIsDisplayed(blackBlouse.Model);
            if (blackBlouse.HasDiscount)
            {
                _quickViewPage.Validate.CorrectDiscountIsDisplayed(blackBlouse.PercentageDiscount);
            }

            _quickViewPage.ChangeColor(whiteBlouse.Color);
            _quickViewPage.ChangeSize(desiredSize);
            _quickViewPage.ChangeQuantity(desiredQuantity);
            _quickViewPage.AddToCart();

            _purchaseSummaryPage.Validate.ItemSuccessfullyAddedToCart();
            _purchaseSummaryPage.Validate.CorrectProductNameIsDisplayed(whiteBlouse.Name);
            _purchaseSummaryPage.Validate.CorrectProductImageUrlIsDisplayed(whiteBlouse.BaseImageUrl);
            _purchaseSummaryPage.Validate.CorrectProductColorIsDisplayed(whiteBlouse.Color);
            _purchaseSummaryPage.Validate.CorrectProductSizeIsDisplayed(whiteBlouse.Size);
            _purchaseSummaryPage.Validate.CorrectProductQuantityIsDisplayed(whiteBlouse.Quantity);
            _purchaseSummaryPage.Validate.CorrectProductPriceIsDisplayed(whiteBlouse.Price);
            _purchaseSummaryPage.Validate.CorrectProductTotalPriceIsDisplayed(Cart.GetProductTotalPriceById(whiteBlouse.Id));
            _purchaseSummaryPage.ProceedToCheckout();

            _cartPage.WaitForPageToLoad();
            _cartPage.Validate.CartPageIsNavigated();
            _cartPage.Validate.CorrectProductImageUrlIsDisplayed(whiteBlouse.BaseImageUrl);
            _cartPage.Validate.CorrectProductNameIsDisplayed(whiteBlouse.Name);
            _cartPage.Validate.CorrectProductModelIsDisplayed(whiteBlouse.Model);
            _cartPage.Validate.CorrectProductColorIsDisplayed(whiteBlouse.Color);
            _cartPage.Validate.CorrectProductSizeIsDisplayed(whiteBlouse.Size);
            _cartPage.Validate.CorrectProductAvailabilityIsDisplayed(whiteBlouse.Availability);
            _cartPage.Validate.CorrectProductPriceIsDisplayed(whiteBlouse.Price);
            _cartPage.Validate.CorrectProductQuantityIsDisplayed(whiteBlouse.Quantity);
            _cartPage.Validate.CorrectProductTotalPriceDisplayed(Cart.GetProductTotalPriceById(whiteBlouse.Id));
            _cartPage.Validate.CorrectProductTotalPriceDisplayed(Cart.CalculateSum());
            _cartPage.Validate.CorrectShippingCostIsDisplayed(Cart.ShippingCost);
            _cartPage.Validate.CorrectCartTotalPriceIsDisplayed(Cart.CalculateSum());
        }

        [TearDown]
        public void TearDown()
        {
            Driver.StopBrowser();
        }
    }
}