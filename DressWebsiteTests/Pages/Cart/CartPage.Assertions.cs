using Shouldly;

namespace DressWebsiteTests.Pages.Cart
{
    public partial class CartPage
    {
        public void AssertCartPageHeader()
        {
            CartPageHeader.Text.ShouldBe("Shopping-cart summary");
        }

        public void AssertCorrectProductColorIsDisplayed(string productId, string expectedProductColor)
        {
            ProductAttributes(productId).Text.StartsWith(expectedProductColor);
        }

        public void AssertCorrectProductImageIsDisplayed(string productId, string expectedProductImage)
        {
            ProductImageUrl(productId).GetAttribute("src").ShouldStartWith(expectedProductImage);
        }

        public void AssertCorrectProductNameIsDisplayed(string productId, string expectedProductName)
        {
            ProductName(productId).ShouldBeEquivalentTo(expectedProductName);
        }

        public void AssertCorrectProductPriceIsDisplayed(string productId, decimal expectedProductPrice)
        {
            ProductPrice(productId).Text.ShouldEndWith(expectedProductPrice.ToString());
        }

        public void AssertCorrectProductSizeIsDisplayed(string productId, string expectedProductSize)
        {
            ProductAttributes(productId).Text.ShouldEndWith(expectedProductSize);
        }

        public void AssertCorrectProductDiscountIsDisplayed(string productId, double expectedProductDiscount)
        {
            ProductDiscount(productId).Text.ShouldContain(expectedProductDiscount.ToString());
        }

        public void AssertProductAvailability(string productId, string expectedProductAvailability)
        {
            ProductAvailability(productId).Text.ShouldBe(expectedProductAvailability);
        }

        public void AssertProductCost(string productId, decimal expectedProductTotalCost)
        {
            ProductTotalCost(productId).Text.ShouldContain(expectedProductTotalCost.ToString());
        }

        public void AssertProductModel(string productId, string expectedProductModel)
        {
            ProductModel(productId).Text.ShouldEndWith(expectedProductModel);
        }

        public void AssertProductQuantity(string productId, int expectedProductQuantity)
        {
            ProductQuantity(productId).GetAttribute("value").ShouldBe(expectedProductQuantity.ToString());
        }
    }
}