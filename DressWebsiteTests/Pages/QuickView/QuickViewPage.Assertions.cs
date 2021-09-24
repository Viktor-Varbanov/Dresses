using NUnit.Framework;
using Shouldly;

namespace DressWebsiteTests.Pages.QuickView
{
    public partial class QuickViewPage
    {
        public void AssertCorrectProductNameIsDisplayed(string expectedProductName)
        {
            Assert.AreEqual(expectedProductName, ProductName.Text);
        }

        public void AssertCorrectProductImageIsDisplayed(string expectedProductImage)
        {
            ProductImage.GetAttribute("src").StartsWith(expectedProductImage);
        }

        public void AssertCorrectProductModelIsDisplayed(string expectedProductModel)
        {
            ProductModel.Text.ShouldContain(expectedProductModel);
        }

        public void AssertCorrectProductDescriptionIsDisplayed(string expectedProductDescription)
        {
            ProductDescription.Text.ShouldBe(expectedProductDescription);
        }

        public void AssertCorrectProductPriceIsDisplayed(decimal expectedProductPrice)
        {
            ProductPrice.Text.ShouldEndWith(expectedProductPrice.ToString());
        }

        public void AssertCorrectProductSizeIsDisplayed(string expectedProductSize)
        {
            ProductSize.Text.ShouldBe(expectedProductSize);
        }

        public void AssertCorrectProductColorIsDisplayed(string expectedProductColor)
        {
            SelectedColor.GetAttribute("name").ShouldBe(expectedProductColor);
        }

        public void AssertCorrectProductDiscountPercantageIsDisplayed(double expectedProductDiscountPercantage)
        {
            ProductDiscountPercentage.Text.Contains(expectedProductDiscountPercantage.ToString());
        }
    }
}