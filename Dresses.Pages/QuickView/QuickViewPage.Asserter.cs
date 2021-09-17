namespace Dresses.Pages.QuickView
{
    using System.Threading;
    using Common;
    using Models;
    using NUnit.Framework;
    using OpenQA.Selenium;

    public partial class QuickViewPage
    {

        public void AssertCorrectProductIsSelected()
        {
            AssertProductName(_product.Name, _productName);
            AssertProductDescription(_product.Description);
            AssertBaseImageUrl(_product.BaseImageUrl);
            AssertCorrectColorIsSelected(_product.Color);
            var hasDiscount = CheckForDiscount();
            if (hasDiscount)
            {
                _product.ApplyDiscount(20);
            }
            AssertProductPrice(_product.Price);
            AssertProductSize(_product.Size);

        }

        private void AssertProductName(string expectedProductName, IWebElement productNameLocator)
        {
            var actualProductName = _productName.Text;
            Assert.AreEqual(expectedProductName, actualProductName, FailTestMessage.ActualDifferentFromExpected(expectedProductName, actualProductName));
        }

        private void AssertProductDescription(string expectedProductDescription)
        {
            var actualProductDescription = _productDescription.Text;
            Assert.AreEqual(expectedProductDescription, actualProductDescription, FailTestMessage.ActualDifferentFromExpected(expectedProductDescription, actualProductDescription));
        }

        private void AssertBaseImageUrl(string expectedBaseProductImageUrl)
        {
            var productUrl = _productImage.GetAttribute("src");
            var baseProductImageUrl = DataManipulation.ExtractBaseUrl(productUrl);
            Assert.AreEqual(expectedBaseProductImageUrl, baseProductImageUrl, FailTestMessage.ActualDifferentFromExpected(expectedBaseProductImageUrl, baseProductImageUrl));
        }

        private void AssertProductPrice(decimal expectedProductPrice)
        {

            var actualProductPrice = DataManipulation.ConvertPriceToDecimal(_productPrice.Text);
            Assert.AreEqual(expectedProductPrice, actualProductPrice, FailTestMessage.ActualDifferentFromExpected(expectedProductPrice.ToString(), actualProductPrice.ToString()));
        }

        private void AssertProductSize(string expectedProductSize)
        {
            var actualProductSize = _productSizeValue.Text;
            Assert.AreEqual(expectedProductSize, actualProductSize, FailTestMessage.ActualDifferentFromExpected(expectedProductSize, actualProductSize));
        }


        private void AssertCorrectColorIsSelected(string expectedProductColor)
        {
            Thread.Sleep(2000);
            var x = driver.FindElement(By.CssSelector(SelectedColor));
            var selectedColor = x.GetAttribute("name");

            Assert.AreEqual(expectedProductColor, selectedColor, FailTestMessage.ActualDifferentFromExpected(expectedProductColor, selectedColor));
        }


    }
}
