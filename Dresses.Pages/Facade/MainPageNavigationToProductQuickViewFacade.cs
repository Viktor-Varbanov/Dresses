namespace Dresses.Pages.Facade
{
    using Main;
    using Models;

    public class MainPageNavigationToProductQuickViewFacade
    {
        private string _productName;
        private string _productImageUrl;

        public MainPageNavigationToProductQuickViewFacade(string productName, string productImageUrl)
        {
            _productName = productName;
            _productImageUrl = productImageUrl;
        }

        private MainPage _mainPage => new MainPage();

        public void GoToProduct()
        {
            _mainPage.NavigateToPage();
            _mainPage.ScrollDownToDress(_productName, _productImageUrl);
            _mainPage.HoverDress(_productName, _productImageUrl);
            _mainPage.ClickQuickViewButton(_productName, _productImageUrl);
        }
    }
}
