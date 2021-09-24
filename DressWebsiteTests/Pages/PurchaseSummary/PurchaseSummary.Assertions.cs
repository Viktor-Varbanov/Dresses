using Shouldly;

namespace DressWebsiteTests.Pages.PurchaseSummary
{
    public partial class PurchaseSummary
    {
        public void AssertProductSectionHeaderTextIsCorrect()
        {
            string expectedHeaderText = "Product successfully added to your shopping cart";
            ProductSectionHeaderText.Text.ShouldBeEquivalentTo(expectedHeaderText);
        }

        public void AssertCorrectProductImageIsDisplayed(string expectedProductImageUrl)
        {
            ProductImageUrl.GetAttribute("src").StartsWith(expectedProductImageUrl);
        }

        public void AssertCorrectProductNameIsDislpayed(string expectedProductName)
        {
            string productName = ProductName.Text;
            productName.ShouldBeEquivalentTo(expectedProductName);
        }

        public void AssertCorrectProductColorIsDisplayed(string expectedProductColor)
        {
            ProductAttributes.Text.ShouldStartWith(expectedProductColor);
        }

        public void AssertCorrectProductSizeIsDisplayed(string expectedProductSize)
        {
            ProductAttributes.Text.ShouldEndWith(expectedProductSize);
        }

        public void AssertProductQuantityIsDisplayed(int expectedProductQuantity)
        {
            ProductQuantity.Text.ShouldContain(expectedProductQuantity.ToString());
        }

        public void AssertCorrectProductTotalCostIsDisplayed(double expectedProductCost)
        {
            CurrentlyAddedProductCost.Text.ShouldContain(expectedProductCost.ToString());
        }

        public void AssertProductsCost(double expectedProductsCost)
        {
            ProductsCost.Text.ShouldContain(expectedProductsCost.ToString());
        }

        public void AssertShippingCost(double expectedShippingCost)
        {
            ShippingCost.Text.ShouldContain(expectedShippingCost.ToString());
        }

        public void AssertTotalPrice(double expectedTotalCost)
        {
            TotalCost.Text.ShouldContain(expectedTotalCost.ToString());
        }
    }
}
