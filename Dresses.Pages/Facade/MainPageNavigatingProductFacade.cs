namespace Dresses.Pages.Facade
{
    using Main;
    using Models;

    public class MainPageNavigatingProductFacade
    {
        private readonly Product _product;
        private MainPage _mainPage;

        public MainPageNavigatingProductFacade(Product product)
        {
            _product = product;
        }

        public MainPage MainPage
        {
            get
            {
                if (_mainPage == null)
                {
                    return new MainPage();
                }

                return _mainPage;
            }
        }

        public void NavigateToProductQuickView()
        {
            MainPage.NavigateToPage();
            MainPage.NavigateToDress(_product.Name);
            MainPage.HoverElement(_product.Name);
            MainPage.ClickQuickView(_product.Name);

        }

    }
}
