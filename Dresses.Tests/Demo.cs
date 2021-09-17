namespace Dresses.Tests
{
    using Common;
    using Pages.Main;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Models;
    using OpenQA.Selenium.Chrome;
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
            var product = _database.GetProductByName("Printed Chiffon Dress");
            var navigatingProductFacade = new MainPageNavigatingProductFacade(product);
            navigatingProductFacade.NavigateToProductQuickView();
            var quickViewVerificationFacade = new QuickViewVerificationFacade(product);
            quickViewVerificationFacade.VerifyCorrectItemIsSelected();
        }
        [Test]
        public void ClickProductQuickViewVerifyTheInformationAndAddToCart()
        {
            var product = _database.GetProductByName("Printed Chiffon Dress");
            product.BaseImageUrl = "http://automationpractice.com/img/p/2/2/22";
            product.Color = "Green";
            product.Size = "L";
            product.Quantity = 2;

            var navigatingProductFacade = new MainPageNavigatingProductFacade(product);
            navigatingProductFacade.NavigateToProductQuickView();

            var quickViewVerificationFacade = new QuickViewVerificationFacade(product);
            quickViewVerificationFacade.ChangeProductInformation();
            quickViewVerificationFacade.VerifyCorrectItemIsSelected();
        }



        [TearDown]
        public void TearDown()
        {
            Driver.StopBrowser();
        }
    }
}
