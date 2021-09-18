namespace Dresses.Tests
{
    using Pages.Main;
    using NUnit.Framework;
    using Models;
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
            //product.BaseImageUrl = "http://automationpractice.com/img/p/2/2/22";
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
        public void testNewClassImplementation()
        {
            var product = _database.GetProductByName("Printed Chiffon Dress");
            var mainPage = new MainPage(product);
            mainPage.NavigateToPage();
            mainPage.ScrollDownToDress();
            mainPage.HoverDress();
            mainPage.ClickQuickViewButton();
            QuickViewPage quickViewPage = new QuickViewPage(product);
            quickViewPage.Validate.VerifyCorrectProductIsSelected();

        }


        [TearDown]
        public void TearDown()
        {
            Driver.StopBrowser();
        }
    }
}
