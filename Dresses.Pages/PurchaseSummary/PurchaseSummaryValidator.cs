namespace Dresses.Pages.PurchaseSummary
{
    using System.Linq;
    using Common;
    using FluentAssertions;

    public class PurchaseSummaryValidator : ProductValidator<PurchaseSummaryElementMap>
    {
        // [0] for color, [1] for size
        private string[] _productAttributes => Map.ProductColorAndSize.Text.Split(", ").ToArray();
        //public void ItemSuccessfullyAddedToCart()
        //{
        //    var headingText = Map.SuccessfulMessage.Text;
        //    Assert.AreEqual("Product successfully added to your shopping cart", headingText);
        //}

        //public void CorrectProductIsAddedToCart(Product product)
        //{
        //    VerifyProductName(product.Name, Map.Name.Text);
        //    VerifyBaseImageUrl(product.BaseImageUrl, DataManipulation.ExtractBaseProductUrl(Map.ProductImageUrl(product.BaseImageUrl).GetAttribute("src")));
        //    VerifyProductQuantity(product.Quantity, int.Parse(Map.QuantityInputField.Text));
        //    VerifyProductTotalPrice(product.Quantity * product.Price, DataManipulation.ConvertPriceToDecimal(Map.Total.Text));
        //    VerifyProductColor(product.Color, SplitAttributes[0]);
        //    VerifyProductSize(product.Size, SplitAttributes[1]);
        //}

        //public void VerifyProductQuantity(int expectedProductQuantity, int actualProductQuantity)
        //{
        //    Assert.AreEqual(expectedProductQuantity, actualProductQuantity, FailTestMessage.ActualDifferentFromExpected(expectedProductQuantity, actualProductQuantity));
        //}

        //public void VerifyProductTotalPrice(decimal expectedTotalPrice, decimal actualTotalPrice)
        //{
        //    Assert.AreEqual(expectedTotalPrice, actualTotalPrice, FailTestMessage.ActualDifferentFromExpected(expectedTotalPrice, actualTotalPrice));
        //}

        ////0 for color, 1 for size
        //private string[] SplitAttributes => Map.ProductColorAndSize.Text.Split(", ").ToArray();
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
            throw new System.NotImplementedException();
        }

        public override void CorrectProductSizeIsDisplayed(string expectedProductSize)
        {
            throw new System.NotImplementedException();
        }

        public void CorrectProductQuantityIsDisplayed(int productQuantity)
        {

        }
    }
}