namespace Dresses.Pages.QuickView
{
    using System.Threading;
    using AbstractionPageComponents;
    using OpenQA.Selenium.Support.UI;

    public class QuickViewPage : AbstractPageWithValidator<QuickViewPageElementMap, QuickViewValidator>
    {

        public void AddToCart()
        {
            Map.AddToCartButton.Click();
        }

        public void ChangeColor(string name)
        {
            Thread.Sleep(3000);
            var colorToChoose = Map.ColorPickerXpath(name);
            colorToChoose.Click();
        }

        public void ChangeSize(string size)
        {
            var dropdown = new SelectElement(Map.ProductSizeDropdown);
            dropdown.SelectByText(size);
        }

        public void ChangeQuantity(string quantity)
        {
            Map.ProductQuantity.Clear();
            Map.ProductQuantity.SendKeys(quantity);
        }

    }
}
