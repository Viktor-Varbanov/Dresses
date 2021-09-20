namespace Dresses.Pages.QuickView
{
    using Common;
    using FluentAssertions;


    public class QuickViewValidator : ProductValidator<QuickViewPageElementMap>
    {

        public override void CorrectProductNameIsDisplayed(string expectedProductName)
        {
            string displayedProductName = Map.Name.Text;
            displayedProductName.Should().BeEquivalentTo(expectedProductName);
        }

        public override void CorrectProductImageUrlIsDisplayed(string expectedBaseProductImageUrl)
        {
            string displayedProductFullImageUrl = Map.Image.GetAttribute("src");
            string displayedProductBaseImageUr = DataManipulation.ExtractBaseProductUrl(displayedProductFullImageUrl);
            displayedProductBaseImageUr.Should().BeEquivalentTo(expectedBaseProductImageUrl);
        }

        public override void CorrectProductColorIsDisplayed(string expectedProductColor)
        {
            string displayedProductColor = Map.PickedColor.GetAttribute("name");
            displayedProductColor.Should().BeEquivalentTo(expectedProductColor);
        }

        public override void CorrectProductPriceIsDisplayed(decimal expectedProductPrice)
        {
            string displayedProductPrice = Map.Price.Text;
            decimal convertedProductPrice = DataManipulation.ConvertPriceToDecimal(displayedProductPrice);
            convertedProductPrice.Should().BeApproximately(expectedProductPrice, 2);
        }

        public override void CorrectProductSizeIsDisplayed(string expectedProductSize)
        {
            string displayedProductSize = Map.Size.Text;
            displayedProductSize.Should().BeEquivalentTo(expectedProductSize);
        }

        public void CorrectProductDescriptionIsDisplayed(string expectedProductDescription)
        {
            string displayedProductDescription = Map.Description.Text;
            displayedProductDescription.Should().BeEquivalentTo(expectedProductDescription);
        }

        public void CorrectProductModelIsDisplayed(string expectedProductModel)
        {
            string displayedProductModel = Map.Model.Text;
            displayedProductModel.Should().BeEquivalentTo(expectedProductModel);
        }

        public void CorrectDiscountIsDisplayed(double expectedDiscount)
        {
            string displayedProductDiscount = Map.Discount.Text;
            double actualDiscount = (double)DataManipulation.ConvertPriceToDecimal(displayedProductDiscount);
            expectedDiscount.Should().BeApproximately(actualDiscount, 2);
        }

    }
}