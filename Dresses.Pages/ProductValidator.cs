namespace Dresses.Pages
{
    using FluentAssertions;
    using AbstractionPageComponents;
    using Common;
    using NUnit.Framework;
    using Shouldly;

    public abstract class ProductValidator<TMap> : AbstractValidator<TMap>
        where TMap : AbstractElementMap, new()

    {
        public void VerifyProductName(string expectedProductName, string displayedProductName)
        {

            displayedProductName.Should().BeEquivalentTo(expectedProductName);
        }

        public abstract void VerifyCorrectProductNameIsDisplayed(string expectedProductName);
        public void VerifyProductColor(string expectedProductColor, string displayedProductColor)
        {
            displayedProductColor.Should().BeEquivalentTo(expectedProductColor);
        }

        public void VerifyProductDescription(string expectedProductDescription, string displayedProductDescription)
        {
            displayedProductDescription.Should().BeEquivalentTo(expectedProductDescription);
        }

        public void VerifyBaseImageUrl(string expectedBaseProductImageUrl, string displayedProductUrl)
        {
            var displayedProductBaseImageUrl = DataManipulation.ExtractBaseProductUrl(displayedProductUrl);
            Assert.AreEqual(expectedBaseProductImageUrl, displayedProductBaseImageUrl, FailTestMessage.ActualDifferentFromExpected(expectedBaseProductImageUrl, displayedProductBaseImageUrl));
        }

        public void VerifyProductPrice(decimal expectedProductPrice, decimal displayedProductPrice)
        {
            displayedProductPrice.Should().ShouldBeEquivalentTo(expectedProductPrice, FailTestMessage.ActualDifferentFromExpected(expectedProductPrice, displayedProductPrice));
        }

        public void VerifyProductSize(string expectedProductSize, string displayedProductSize)
        {
            displayedProductSize.Should().BeEquivalentTo(expectedProductSize, FailTestMessage.ActualDifferentFromExpected(expectedProductSize, displayedProductSize));
        }
    }
}