namespace Dresses.Pages.QuickView
{
    using System.Threading;
    using Common;
    using Models;
    using OpenQA.Selenium;
    public partial class QuickViewPage : BasePage
    {
        private readonly Product _product;


        public QuickViewPage(Product product)
        {
            _product = product;
        }

        public void ClickAddToCart()
        {
            _addToCartButton.Click();
        }

        public void ChangeColor(string name)
        {
            Thread.Sleep(3000);
            var element = driver.FindElement(By.XPath(string.Format(ColorPickerXpath, name)));
            element.Click();

            AssertCorrectColorIsSelected(_product.Color);

        }

        public void ChangeSize(string size)
        {

        }

        public void ChangeQuantity(string quantity)
        {

        }

        private bool CheckForDiscount()
            => _productDiscount.Displayed;

    }
}
