namespace Dresses.Pages
{
    using FluentAssertions;
    using AbstractionPageComponents;
    using Common;
    using NUnit.Framework;


    public abstract class ProductValidator<TMap> : AbstractValidator<TMap>
        where TMap : AbstractElementMap, new()

    {
        public abstract void CorrectProductNameIsDisplayed(string expectedProductName);

        public abstract void CorrectProductImageUrlIsDisplayed(string expectedBaseProductImageUrl);

        public abstract void CorrectProductColorIsDisplayed(string expectedProductColor);

        public abstract void CorrectProductPriceIsDisplayed(decimal expectedProductPrice);

        public abstract void CorrectProductSizeIsDisplayed(string expectedProductSize);

    }
}