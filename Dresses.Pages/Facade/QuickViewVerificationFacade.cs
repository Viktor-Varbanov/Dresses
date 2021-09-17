namespace Dresses.Pages.Facade
{
    using Models;
    using QuickView;

    public class QuickViewVerificationFacade
    {
        private readonly QuickViewPageM _quickViewPage;
        private readonly Product _product;

        public QuickViewVerificationFacade(Product product)
        {
            _product = product;
        }

        public QuickViewPageM QuickViewPage
        {
            get
            {
                if (_quickViewPage == null)
                {
                    return new QuickViewPageM(_product);
                }

                return _quickViewPage;
            }
        }

        public void VerifyCorrectItemIsSelected()
        {
            QuickViewPage.AssertCorrectProductIsSelected();
        }

        public void ChangeProductInformation()
        {
            QuickViewPage.ChangeColor(_product.Color);
            QuickViewPage.ChangeSize(_product.Size);
            QuickViewPage.ChangeQuantity(_product.Quantity.ToString());
        }
    }
}
