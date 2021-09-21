namespace Dresses.Pages.Cart
{
    using Common;
    using FluentAssertions;
    using Models;
    using OpenQA.Selenium;

    public class CartValidator : ProductValidator<CartElementMap>
    {
        private string _productId => Cart.GetFirstProductId();

        private string _productAttributes => Map.ProductAttributes(_productId).GetAttribute("href");

        private string _productModel => Map.ProductModel(_productId).Text;
        //public void Navigated()
        //{
        //    Assert.AreEqual("Order - My Store", driver.Browser.Title);
        //}

        //public void VerifyInformation(Product product)
        //{
        //    VerifyProductName(product.Name, Map.Name(product.Id).Text);
        //    VerifyBaseImageUrl(product.BaseImageUrl, DataManipulation.ExtractBaseProductUrl(Map.ProductImageUrl(product.Id).GetAttribute("src")));
        //    VerifyProductPrice(product.Price, Map.Price(product.Id).Text);
        //    VerifyProductQuantity(product.Quantity, GetProductQuantity(product.Id));
        //    VerifyProductTotalPrice(Cart.GetProductTotalPriceById(product.Id), DataManipulation.ConvertPriceToDecimal(Map.TotalPriceForProduct(product.Id).Text));
        //    VerifyProductAvailability(product.Availability, Map.ProductAvailability(product.Id).Text);
        //}

        //private int GetProductQuantity(string id) => int.Parse(Map.QuantityInputField(id).GetAttribute("value"));

        //public void VerifyProductQuantity(int expected, int actual)
        //{
        //    Assert.AreEqual(expected, actual, FailTestMessage.ActualDifferentFromExpected(expected, actual));
        //}

        //public void VerifyProductTotalPrice(decimal expectedPrice, decimal actualPrice)
        //{
        //    Assert.AreEqual(expectedPrice, actualPrice, FailTestMessage.ActualDifferentFromExpected(expectedPrice, actualPrice));
        //}

        //public void VerifyProductAvailability(string expectedAvailability, string actualAvailability)
        //{
        //    Assert.AreEqual(expectedAvailability, actualAvailability, FailTestMessage.ActualDifferentFromExpected(expectedAvailability, actualAvailability));
        //}
        public override void CorrectProductNameIsDisplayed(string expectedProductName)
        {
            IWebElement productName = Map.ProductName(_productId);
            string displayedProductName = productName.Text;

            displayedProductName.Should().BeEquivalentTo(expectedProductName);
        }

        public override void CorrectProductImageUrlIsDisplayed(string expectedBaseProductImageUrl)
        {
            IWebElement productImageUrl = Map.ProductImageUrl(_productId);
            string displayedProductImageUrl = DataManipulation.ExtractBaseProductUrl(productImageUrl.GetAttribute("src"));
            displayedProductImageUrl.Should().BeEquivalentTo(expectedBaseProductImageUrl);
        }

        public override void CorrectProductColorIsDisplayed(string expectedProductColor)
        {
            string displayedProductColor = DataManipulation.GetProductColorByRegex(_productAttributes);
            displayedProductColor.Should().BeEquivalentTo(expectedProductColor);
        }

        public override void CorrectProductPriceIsDisplayed(decimal expectedProductPrice)
        {
            IWebElement displayedProductPrice = Map.ProductPrice(_productId);
            decimal displayedProductPriceAsDecimal = DataManipulation.ConvertPriceToDecimal(displayedProductPrice.Text);
            displayedProductPriceAsDecimal.Should().BeApproximately(expectedProductPrice, 2);
        }

        public override void CorrectProductSizeIsDisplayed(string expectedProductSize)
        {
            string displayedProductSize = DataManipulation.GetProductSizeByRegex(_productAttributes);
            displayedProductSize.Should().BeEquivalentTo(expectedProductSize);
        }

        public void CorrectProductQuantityIsDisplayed(int expectedProductQuantity)
        {
            IWebElement productQuantityElement = Map.ProductQuantity(_productId);
            string productQuantityString = productQuantityElement.GetAttribute("value");
            int displayedProductQuantity = int.Parse(productQuantityString);
            displayedProductQuantity.Should().Be(expectedProductQuantity);
        }

        public void CorrectProductTotalPriceDisplayed(decimal expectedTotalPrice)
        {
            string displayedProductTotalPrice = Map.TotalPriceForProduct(_productId).Text;
            decimal totalPrice = DataManipulation.ConvertPriceToDecimal(displayedProductTotalPrice);
            totalPrice.Should().BeApproximately(expectedTotalPrice, 2);
        }

        public void CorrectProductAvailabilityIsDisplayed(string expectedProductAvailability)
        {
            string displayedProductAvailability = Map.ProductAvailability(_productId).Text;
            displayedProductAvailability.Should().BeEquivalentTo(expectedProductAvailability);
        }

        public void CorrectProductModelIsDisplayed(string expectedProductModel)
        {
            int length = _productModel.Length;
            int startIndex = _productModel.IndexOf('d');
            string model = _productModel.Remove(0, startIndex);
            model.Should().BeEquivalentTo(expectedProductModel);
        }
    }
}