namespace Dresses.Pages
{
    using FluentAssertions;
    using AbstractionPageComponents;
    using Common;
    using NUnit.Framework;


    public abstract class ProductValidator<TMap> : AbstractValidator<TMap>
        where TMap : AbstractElementMap, new()

    {
        public void VerifyProductName(string expectedProductName, string displayedProductName)
        {

            displayedProductName.Should().BeEquivalentTo(expectedProductName);
        }

        public abstract void CorrectProductNameIsDisplayed(string expectedProductName);

        public abstract void CorrectProductImageUrlIsDisplayed(string expectedBaseProductImageUrl);

        public abstract void CorrectProductColorIsDisplayed(string expectedProductColor);

        public abstract void CorrectProductPriceIsDisplayed(decimal expectedProductPrice);

        public abstract void CorrectProductSizeIsDisplayed(string expectedProductSize);
        //public void VerifyProductColor(string expectedProductColor, string displayedProductColor)
        //{
        //    displayedProductColor.Should().BeEquivalentTo(expectedProductColor);
        //}

        //public void VerifyProductDescription(string expectedProductDescription, string displayedProductDescription)
        //{
        //    displayedProductDescription.Should().BeEquivalentTo(expectedProductDescription);
        //}

        //public void VerifyBaseImageUrl(string expectedBaseProductImageUrl, string displayedProductUrl)
        //{
        //    var displayedProductBaseImageUrl = DataManipulation.ExtractBaseProductUrl(displayedProductUrl);
        //    Assert.AreEqual(expectedBaseProductImageUrl, displayedProductBaseImageUrl, FailTestMessage.ActualDifferentFromExpected(expectedBaseProductImageUrl, displayedProductBaseImageUrl));
        //}

        //////public void VerifyProductPrice(decimal expectedProductPrice, decimal displayedProductPrice)
        //////{
        //////    displayedProductPrice.Should().Be(expectedProductPrice, FailTestMessage.ActualDifferentFromExpected(expectedProductPrice, displayedProductPrice));
        //////}

        ////public void VerifyProductSize(string expectedProductSize, string displayedProductSize)
        ////{
        ////    displayedProductSize.Should().BeEquivalentTo(expectedProductSize, FailTestMessage.ActualDifferentFromExpected(expectedProductSize, displayedProductSize));
        ////}
    }
}