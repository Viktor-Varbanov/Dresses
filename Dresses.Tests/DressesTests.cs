namespace Dresses.Tests
{
    using Models;
    using NUnit.Framework;
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

        [SetUp]
        public void SetUp()
        {
            Driver.StartBrowser();
            _mainPage = new MainPage();
            _database = new Database();
            _quickViewPage = new QuickViewPage();
            _purchaseSummaryPage = new PurchaseSummaryPage();
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
            // 1. Get BlackBlouse from database
            // 2. Take Whiteblouse from database and modify the quantity size and color

            // --Arrange
            Product blackBlouse = _database.GetProductById("product_2_7_0_0");
            Product whiteBlouse = _database.GetProductById("product_2_8_0_0");
            whiteBlouse.Size = desiredSize;
            whiteBlouse.Quantity = int.Parse(desiredQuantity);
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

        }

        [Test]
        public void NavigateToProduct_ClickQuickView_AndValidateInformationThere()
        {
            //// --Arrange
            //var product = _database.GetProductByName("Blouse");
            //var mainPageNavigationToProductFacade =
            //    new MainPageNavigationToProductQuickViewFacade(product.Name, product.BaseImageUrl);
            //var quickViewValidationFacade = new QuickViewValidationFacade();

            //// --Act
            //mainPageNavigationToProductFacade.GoToProduct();

            //// --Assert
            //quickViewValidationFacade.ValidateCorrectProductIsSelected(product);
        }

        [Test]
        public void NavigateToProduct_ClickQuickView_ChangeInformation_AddToCard_ValidateCorrectProductIsAdded()
        {
            //var product = _database.GetProductByName("Printed Chiffon Dress");
            //var quickViewPage = new QuickViewPage();
            //var mainPageNavigationToProductFacade =
            //    new MainPageNavigationToProductQuickViewFacade(product.Name, product.BaseImageUrl);

            //// --Act
            //mainPageNavigationToProductFacade.GoToProduct();
            //quickViewPage.Validate.CorrectProductIsDisplayed(product);
            //var productNewValues = product;
            //productNewValues.BaseImageUrl = "http://automationpractice.com/img/p/2/2/22";
            //productNewValues.Color = "Green";
            //productNewValues.Size = "L";
            //productNewValues.Quantity = 2;
            //var quickViewValidationFacade = new QuickViewValidationFacade();
            //quickViewValidationFacade.ChangeProductAttributes("Green", "L", "2");
            ////quickViewPage.ChangeSize("L");
            ////quickViewPage.ChangeQuantity("2");
            ////quickViewPage.ChangeColor("Green");
            ////Applies discount to product two times
            //quickViewValidationFacade.ValidateCorrectProductIsSelected(productNewValues);
            ////   quickViewPage.Validate.CorrectChangesAreMade(productNewValues);
            //quickViewPage.AddToCart(productNewValues);
            //var purchaseSummaryPage = new PurchaseSummaryPage();
            //purchaseSummaryPage.Validate.ItemSuccessfullyAddedToCart();
            //purchaseSummaryPage.Validate.CorrectProductIsAddedToCart(productNewValues);
            //purchaseSummaryPage.ProceedToCheckout();
        }


        [Test]
        public void NavigateToProduct_ClickQuickView_AddToCart_VerifyCorrectProductIsAddToCart()
        {
            //var product = _database.GetProductByName("Blouse");
            //var quickViewPage = new QuickViewPage();
            //var mainPageNavigationToProductFacade =
            //    new MainPageNavigationToProductQuickViewFacade(product.Name, product.BaseImageUrl);
            //var quickViewValidationFacade = new QuickViewValidationFacade();
            //var cartPage = new CartPage();
            //// --Act
            //mainPageNavigationToProductFacade.GoToProduct();
            //quickViewValidationFacade.ValidateCorrectProductIsSelected(product);
            //quickViewPage.AddToCart(product);
            //var purchaseSummaryPage = new PurchaseSummaryPage();
            //purchaseSummaryPage.Validate.ItemSuccessfullyAddedToCart();
            //purchaseSummaryPage.Validate.CorrectProductIsAddedToCart(product);
            //purchaseSummaryPage.ProceedToCheckout();
            //cartPage.Validate.VerifyInformation(product);

        }

        [TearDown]
        public void TearDown()
        {
            Driver.StopBrowser();
        }
    }
}