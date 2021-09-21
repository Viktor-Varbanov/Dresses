namespace Dresses.Pages.PurchaseSummary
{
    using Common;
    using FluentAssertions;
    using System.Linq;

    public class PurchaseSummaryValidator : ProductValidator<PurchaseSummaryElementMap>
    {
        // [0] for color, [1] for size
        private string[] _productAttributes => Map.ProductColorAndSize.Text.Split(", ").ToArray();

        public void ItemSuccessfullyAddedToCart()
        {
            string headingText = Map.SuccessfulMessage.Text;
            headingText.Should().BeEquivalentTo("Product successfully added to your shopping cart");
        }

        public override void CorrectProductNameIsDisplayed(string expectedProductName)
        {
            string displayedProductName = Map.ProductName.Text;
            displayedProductName.Should().BeEquivalentTo(expectedProductName);
        }

        public override void CorrectProductImageUrlIsDisplayed(string expectedBaseProductImageUrl)
        {
            string displayedProductFullImageUrl = Map.ProductImageUrl.GetAttribute("src");
            string displayedProductBaseImageUr = DataManipulation.ExtractBaseProductUrl(displayedProductFullImageUrl);
            displayedProductBaseImageUr.Should().BeEquivalentTo(expectedBaseProductImageUrl);
        }

        public override void CorrectProductColorIsDisplayed(string expectedProductColor)
        {
            string displayedProductColor = _productAttributes[0];
            displayedProductColor.Should().BeEquivalentTo(expectedProductColor);
        }

        public override void CorrectProductPriceIsDisplayed(decimal expectedProductPrice)
        {
            decimal displayedProductTotalPrice = DataManipulation.ConvertPriceToDecimal(Map.Total.Text);
            int displayedProductQuantity = int.Parse(Map.ProductQuantity.Text);
            decimal priceOfTheProduct = displayedProductTotalPrice / displayedProductQuantity;
            priceOfTheProduct.Should().BeApproximately(expectedProductPrice, 2);
        }

        public override void CorrectProductSizeIsDisplayed(string expectedProductSize)
        {
            string displayedProductSize = _productAttributes[1];
            displayedProductSize.Should().BeEquivalentTo(expectedProductSize);
        }

        public void CorrectProductQuantityIsDisplayed(int expectedProductQuantity)
        {
            int displayedProductQuantity = int.Parse(Map.ProductQuantity.Text);
            displayedProductQuantity.Should().Be(expectedProductQuantity);
        }

        public void CorrectProductTotalPriceIsDisplayed(decimal expectedProductTotalPrice)
        {
            decimal displayedProductTotalPrice = DataManipulation.ConvertPriceToDecimal(Map.Total.Text);
            displayedProductTotalPrice.Should().BeApproximately(expectedProductTotalPrice, 2);
        }
    }
}