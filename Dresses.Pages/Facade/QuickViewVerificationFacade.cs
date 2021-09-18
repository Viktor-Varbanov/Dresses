namespace Dresses.Pages.Facade
{
    using Models;
    using QuickView;

    public class QuickViewVerificationFacade
    {

        private readonly Product _product;

        public QuickViewVerificationFacade(Product product)
        {
            _product = product;
        }

        private QuickViewPage _quickViewPage => new QuickViewPage();
        public void VerifyCorrectProductIsSelected()
        {
            _quickViewPage.Validate.ProductName(_product.Name, _quickViewPage.Ma);
        }
    }
}
