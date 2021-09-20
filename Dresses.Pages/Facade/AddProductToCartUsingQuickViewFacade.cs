namespace Dresses.Pages.Facade
{
    using System;
    using Main;
    using Models;
    using PurchaseSummary;
    using QuickView;

    public class AddProductToCartUsingQuickViewFacade
    {
        private QuickViewPage _quickViewPage;
        private MainPage _mainPage;
        private PurchaseSummaryPage _purchaseSummaryPage;

        public AddProductToCartUsingQuickViewFacade()
        {
            _quickViewPage = new QuickViewPage();
            _mainPage = new MainPage();
            _purchaseSummaryPage = new PurchaseSummaryPage();
        }

        public void PurchaseItem(string productId, string productImageUrl, string productName, Product product)
        {
            _mainPage.NavigateToPage();
            _mainPage.ScrollDownToDress(productName, productImageUrl);
            _mainPage.ClickQuickViewButton(productName, productImageUrl);
            _quickViewPage.Validate.CorrectProductIsDisplayed(product);
        }
    }
}
