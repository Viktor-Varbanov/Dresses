namespace Dresses.Pages
{
    using System.Threading;
    using AbstractionPageComponents;
    using Common;
    using NUnit.Framework;
    using OpenQA.Selenium;

    public abstract class ProductValidator<TMap> : AbstractValidator<TMap>
        where TMap : AbstractElementMap, new()

    {

        public void ProductName(string expectedProductName, IWebElement nameLocator)
        {
            var actualProductName = nameLocator.Text;
            Assert.AreEqual(expectedProductName, actualProductName, FailTestMessage.ActualDifferentFromExpected(expectedProductName, actualProductName));
        }

        public void ProductColor(string expectedProductColor, IWebElement colorLocator)
        {
            var actualProductColor = colorLocator.Text;
            Assert.AreEqual(expectedProductColor, actualProductColor, FailTestMessage.ActualDifferentFromExpected(expectedProductColor, actualProductColor));
        }

        public void ProductDescription(string expectedProductDescription, IWebElement descriptionLocator)
        {
            var actualProductDescription = descriptionLocator.Text;
            Assert.AreEqual(expectedProductDescription, actualProductDescription,
                FailTestMessage.ActualDifferentFromExpected(expectedProductDescription, actualProductDescription));
        }
        public void BaseImageUrl(string expectedBaseProductImageUrl, IWebElement imageUrlLocator)
        {
            var productUrl = imageUrlLocator.GetAttribute("src");
            var actualBaseProductImageUrl = DataManipulation.ExtractBaseUrl(productUrl);
            Assert.AreEqual(expectedBaseProductImageUrl, actualBaseProductImageUrl, FailTestMessage.ActualDifferentFromExpected(expectedBaseProductImageUrl, actualBaseProductImageUrl));
        }
        public void ProductPrice(decimal expectedProductPrice, IWebElement priceLocator)
        {
            var actualProductPrice = DataManipulation.ConvertPriceToDecimal(priceLocator.Text);
            Assert.AreEqual(expectedProductPrice, actualProductPrice, FailTestMessage.ActualDifferentFromExpected(expectedProductPrice.ToString(), actualProductPrice.ToString()));
        }

        public void ProductSize(string expectedProductSize, IWebElement sizeLocator)
        {
            var actualProductSize = sizeLocator.Text;
            Assert.AreEqual(expectedProductSize, actualProductSize, FailTestMessage.ActualDifferentFromExpected(expectedProductSize, actualProductSize));
        }
        public void AssertCorrectColorIsSelected(string expectedProductColor)
        {
           
        }
    }
}
