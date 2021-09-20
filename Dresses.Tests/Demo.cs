namespace Dresses.Tests
{
    using Models;
    using NUnit.Framework;
    using Pages.Cart;
    using Pages.Facade;
    using Pages.PurchaseSummary;
    using Pages.QuickView;

    [TestFixture]
    public class Demo
    {
        private Database _database;

        [SetUp]
        public void SetUp()
        {
            Driver.StartBrowser();

            _database = new Database();
        }

        [Test]
        public void ClickProductQuickViewAndVerifyTheInformationAboutProduct()
        {
            //var product = _database.GetProductByName("Printed Chiffon Dress");
            //var navigatingProductFacade = new MainPageNavigatingProductFacade(product);
            //navigatingProductFacade.NavigateToProductQuickView();
            //var quickViewVerificationFacade = new QuickViewVerificationFacade(product);
            //quickViewVerificationFacade.VerifyCorrectItemIsSelected();
        }

        [Test]
        public void ClickProductQuickViewVerifyTheInformationAndAddToCart()
        {
            //var product = _database.GetProductByName("Printed Chiffon Dress");
            //product.VerifyBaseImageUrl = "http://automationpractice.com/img/p/2/2/22";
            //product.Color = "Green";
            //product.Size = "L";
            //product.Quantity = 2;

            //var navigatingProductFacade = new MainPageNavigatingProductFacade(product);
            //navigatingProductFacade.NavigateToProductQuickView();

            //var quickViewVerificationFacade = new QuickViewVerificationFacade(product);
            //quickViewVerificationFacade.ChangeProductInformation();
            //quickViewVerificationFacade.VerifyCorrectItemIsSelected();
        }

        [Test]
        public void NavigateToProduct_ClickQuickView_AndValidateInformationThere()
        {
            // --Arrange
            var product = _database.GetProductByName("Blouse");
            var mainPageNavigationToProductFacade =
                new MainPageNavigationToProductQuickViewFacade(product.Name, product.BaseImageUrl);
            var quickViewValidationFacade = new QuickViewValidationFacade();

            // --Act
            mainPageNavigationToProductFacade.GoToProduct();

            // --Assert
            quickViewValidationFacade.ValidateCorrectProductIsSelected(product);
        }

        [Test]
        public void NavigateToProduct_ClickQuickView_ChangeInformation_AddToCard_ValidateCorrectProductIsAdded()
        {
            var product = _database.GetProductByName("Printed Chiffon Dress");
            var quickViewPage = new QuickViewPage();
            var mainPageNavigationToProductFacade =
                new MainPageNavigationToProductQuickViewFacade(product.Name, product.BaseImageUrl);

            // --Act
            mainPageNavigationToProductFacade.GoToProduct();
            quickViewPage.Validate.CorrectProductIsDisplayed(product);
            var productNewValues = product;
            productNewValues.BaseImageUrl = "http://automationpractice.com/img/p/2/2/22";
            productNewValues.Color = "Green";
            productNewValues.Size = "L";
            productNewValues.Quantity = 2;
            var quickViewValidationFacade = new QuickViewValidationFacade();
            quickViewValidationFacade.ChangeProductAttributes("Green", "L", "2");
            //quickViewPage.ChangeSize("L");
            //quickViewPage.ChangeQuantity("2");
            //quickViewPage.ChangeColor("Green");
            //Applies discount to product two times
            quickViewValidationFacade.ValidateCorrectProductIsSelected(productNewValues);
            //   quickViewPage.Validate.CorrectChangesAreMade(productNewValues);
            quickViewPage.AddToCart(productNewValues);
            var purchaseSummaryPage = new PurchaseSummaryPage();
            purchaseSummaryPage.Validate.ItemSuccessfullyAddedToCart();
            purchaseSummaryPage.Validate.CorrectProductIsAddedToCart(productNewValues);
            purchaseSummaryPage.ProceedToCheckout();
        }


        [Test]
        public void NavigateToProduct_ClickQuickView_AddToCart_VerifyCorrectProductIsAddToCart()
        {
            var product = _database.GetProductByName("Blouse");
            var quickViewPage = new QuickViewPage();
            var mainPageNavigationToProductFacade =
                new MainPageNavigationToProductQuickViewFacade(product.Name, product.BaseImageUrl);
            var quickViewValidationFacade = new QuickViewValidationFacade();
            var cartPage = new CartPage();
            // --Act
            mainPageNavigationToProductFacade.GoToProduct();
            quickViewValidationFacade.ValidateCorrectProductIsSelected(product);
            quickViewPage.AddToCart(product);
            var purchaseSummaryPage = new PurchaseSummaryPage();
            purchaseSummaryPage.Validate.ItemSuccessfullyAddedToCart();
            purchaseSummaryPage.Validate.CorrectProductIsAddedToCart(product);
            purchaseSummaryPage.ProceedToCheckout();
            cartPage.Validate.VerifyInformation(product);

        }

        [TearDown]
        public void TearDown()
        {
            Driver.StopBrowser();
        }
    }
}