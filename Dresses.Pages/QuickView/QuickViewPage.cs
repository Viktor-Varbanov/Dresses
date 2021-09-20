namespace Dresses.Pages.QuickView
{
    using AbstractionPageComponents;
    using Models;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;
    using System;
    using System.Threading;

    public class QuickViewPage : AbstractPageWithValidator<QuickViewPageElementMap, QuickViewValidator>
    {
        public void AddToCart(Product product)
        {
            Cart.AddProductToCart(product);
            Map.AddToCartButton.Click();
            SwitchToCart();
        }

        public void ChangeColor(string name)
        {
            Thread.Sleep(3000);
            var colorToChoose = Map.ColorPickerXpath(name);
            colorToChoose.Click();
        }

        public void ChangeSize(string size)
        {
            var dropdown = new SelectElement(Map.SizeDropdown);
            dropdown.SelectByText(size);
        }

        public void ChangeQuantity(string quantity)
        {
            Map.QuantityInputField.Clear();
            Map.QuantityInputField.SendKeys(quantity);
        }

        private void SwitchToCart()
        {
            WebDriverWait wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("layer_cart")));
        }
    }
}