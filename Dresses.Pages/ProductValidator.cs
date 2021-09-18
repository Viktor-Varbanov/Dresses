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

        public void VerifyProductName(string expectedProductName, string displayedName)
        {
            Assert.AreEqual(expectedProductName, displayedName, FailTestMessage.ActualDifferentFromExpected(expectedProductName, displayedName));
        }

        public void VerifyProductColor(string expectedProductColor, string displayedProductColor)
        {
            Assert.AreEqual(expectedProductColor, displayedProductColor, FailTestMessage.ActualDifferentFromExpected(expectedProductColor, displayedProductColor));
        }

        public void VerifyProductDescription(string expectedProductDescription, string displayedDescription)
        {
            Assert.AreEqual(expectedProductDescription, displayedDescription,
                FailTestMessage.ActualDifferentFromExpected(expectedProductDescription, displayedDescription));
        }
        public void VerifyBaseImageUrl(string expectedBaseProductImageUrl, string displayedProductUrl)
        {
            var displayedProductBaseImageUrl = DataManipulation.ExtractBaseProductUrl(displayedProductUrl);
            Assert.AreEqual(expectedBaseProductImageUrl, displayedProductBaseImageUrl, FailTestMessage.ActualDifferentFromExpected(expectedBaseProductImageUrl, displayedProductBaseImageUrl));
        }
        public void VerifyProductPrice(decimal expectedProductPrice, string displayedProductPrice)
        {
            var actualProductPrice = DataManipulation.ConvertPriceToDecimal(displayedProductPrice);
            Assert.AreEqual(expectedProductPrice, actualProductPrice, FailTestMessage.ActualDifferentFromExpected(expectedProductPrice, actualProductPrice));
        }

        public void VerifyProductSize(string expectedProductSize, string displayedSize)
        {
            Assert.AreEqual(expectedProductSize, displayedSize, FailTestMessage.ActualDifferentFromExpected(expectedProductSize, displayedSize));
        }

    }
}
