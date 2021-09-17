namespace Dresses.Pages.QuickView
{
    using System.Threading;
    using AbstractionPageComponents;
    using Models;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class QuickViewPage : AbstractPageWithValidator<QuickViewPageElementMap, QuickViewValidator>
    {
        private readonly Product _product;

        public QuickViewPage(Product product)
        {
            _product = product;
        }


        //public void ClickAddToCart()
        //{
        //    _addToCartButton.Click();
        //}

        //public void ChangeColor(string name)
        //{
        //    Thread.Sleep(3000);
        //    var element = driver.FindElement(By.XPath(string.Format(ColorPickerXpath, name)));
        //    element.Click();


        //}

        //public void ChangeSize(string size)
        //{
        //    var dropdown = new SelectElement(_productSizeDropdown);
        //    dropdown.SelectByText(size);
        //}

        //public void ChangeQuantity(string quantity)
        //{
        //    _productQuantity.Clear();
        //    _productQuantity.SendKeys(quantity);
        //}

        //private bool CheckForDiscount()
        //    => _productDiscount.Displayed;
    }
}
