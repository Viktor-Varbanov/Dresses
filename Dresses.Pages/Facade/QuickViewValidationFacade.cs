namespace Dresses.Pages.Facade
{
    using Models;
    using QuickView;

    public class QuickViewValidationFacade
    {
        private QuickViewPage _quickViewPage => new QuickViewPage();

        public void ValidateCorrectProductIsSelected(Product product)
        {
            _quickViewPage.Validate.CorrectProductIsDisplayed(product);
        }

        public void ChangeProductAttributes(string colorName, string size, string quantity)
        {
            _quickViewPage.ChangeColor(colorName);
            _quickViewPage.ChangeSize(size);
            _quickViewPage.ChangeQuantity(quantity);
        }
    }
}