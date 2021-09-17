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
        public void ClickProductQuickViewAndVerifyTheInFormation()
        {
            var product = _database.GetProductByName("Blouse");
            var navigatingProductFacade = new MainPageNavigatingProductFacade(product);
            navigatingProductFacade.NavigateToProductQuickView();
            var quickViewVerificationFacade = new QuickViewVerificationFacade(product);
            quickViewVerificationFacade.VerifyCorrectItemIsSelected();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.StopBrowser();
        }
    }
}
