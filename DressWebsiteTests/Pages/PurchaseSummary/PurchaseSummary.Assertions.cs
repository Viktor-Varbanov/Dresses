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
            ProductImageUrl("").GetAttribute("src").StartsWith(expectedProductImageUrl);
        }

        public void AssertCorrectProductNameIsDisplayed(string expectedProductName)
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

        public void AssertShippingCost(decimal expectedShippingCost)
        {

            ShippingCost.Text.ShouldContain(expectedShippingCost.ToString());
        }

        public void AssertTotalPrice(decimal expectedTotalCost)
        {
            TotalCost.Text.ShouldContain(expectedTotalCost.ToString());
        }

        public void AssertProductCartText(int productCount)
        {
            if (productCount == 1)
            {
                CartSectionHeaderTextWithOneProduct.Text.ShouldBe("There is 1 item in your cart.");
            }
            else
            {
                CartSectionHeaderWithMoreThanOneProduct.Text.Contains($"There are {productCount} items in your cart.");
            }
        }

        public void AssertTotalProductsCost(decimal ProductCost)
        {
            ProductsCost.Text.ShouldContain(ProductCost.ToString());
        }

        public void AssertProductShippingCost(decimal shipping)
        {
            ShippingCost.Text.ShouldContain(shipping.ToString());
        }

        public void AssertTotalCost(int totalCost)
        {
            TotalCost.Text.ShouldContain(totalCost.ToString());
        }
    }
}