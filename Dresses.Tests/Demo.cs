namespace Dresses.Tests
{
    using Pages.Main;
    using NUnit.Framework;
    using Models;
    using Pages.Facade;
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
            var quickViewPage = new QuickViewPage();
            var mainPageNavigationToProductFacade =
                new MainPageNavigationToProductQuickViewFacade(product.Name, product.BaseImageUrl);

            // --Act
            mainPageNavigationToProductFacade.GoToProduct();

            // --Assert
            quickViewPage.Validate.CorrectProductIsDisplayed(product);
        }

        [Test]
        public void NavigateToProduct_ClickQuickView_ChangeInformation_AddToCard_ValidateCorrectProductIsAdded()
        {
            var product = _database.GetProductByName("Printed Chiffon Dress");
            //var product = _database.GetProductByName("Printed Chiffon Dress");
            //product.VerifyBaseImageUrl = "http://automationpractice.com/img/p/2/2/22";
            //product.Color = "Green";
            //product.Size = "L";
            //product.Quantity = 2;
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
            quickViewPage.ChangeSize("L");
            quickViewPage.ChangeQuantity("2");
            quickViewPage.ChangeColor("Green");
            quickViewPage.Validate.CorrectChangesAreMade(productNewValues);
            quickViewPage.AddToCart();



        }


        [TearDown]
        public void TearDown()
        {
            Driver.StopBrowser();
        }
    }
}
