//namespace Dresses.Pages.Cart
//{
//    using Common;
//    using FluentAssertions;
//    using Models;
//    using OpenQA.Selenium;

//    public class CartValidator : ProductValidator<CartElementMap>
//    {
//        private string _productId => Cart.GetFirstProductId();

//        private string _productAttributes => Map.ProductAttributes(_productId).GetAttribute("href");


//        public void CartPageIsNavigated()
//        {
//            string expectedTitle = "Order - My Store";
//            string actualTitle = Driver.Browser.Title;

//            actualTitle.Should().BeEquivalentTo(expectedTitle);
//        }


//        public override void CorrectProductNameIsDisplayed(string expectedProductName)
//        {
//            IWebElement productName = Map.ProductName(_productId);
//            string displayedProductName = productName.Text;

//            displayedProductName.Should().BeEquivalentTo(expectedProductName);
//        }

//        public override void CorrectProductImageUrlIsDisplayed(string expectedBaseProductImageUrl)
//        {
//            IWebElement productImageUrl = Map.ProductImageUrl(_productId);
//            string displayedProductImageUrl = DataManipulation.ExtractBaseProductUrl(productImageUrl.GetAttribute("src"));
//            displayedProductImageUrl.Should().BeEquivalentTo(expectedBaseProductImageUrl);
//        }

//        public override void CorrectProductColorIsDisplayed(string expectedProductColor)
//        {
//            string displayedProductColor = DataManipulation.GetProductColorByRegex(_productAttributes);
//            displayedProductColor.Should().BeEquivalentTo(expectedProductColor);
//        }

//        public override void CorrectProductPriceIsDisplayed(decimal expectedProductPrice)
//        {
//            IWebElement displayedProductPrice = Map.ProductPrice(_productId);
//            decimal displayedProductPriceAsDecimal = DataManipulation.ConvertPriceToDecimal(displayedProductPrice.Text);
//            displayedProductPriceAsDecimal.Should().BeApproximately(expectedProductPrice, 2);
//        }

//        public override void CorrectProductSizeIsDisplayed(string expectedProductSize)
//        {
//            string displayedProductSize = DataManipulation.GetProductSizeByRegex(_productAttributes);
//            displayedProductSize.Should().BeEquivalentTo(expectedProductSize);
//        }

//        public void CorrectProductQuantityIsDisplayed(int expectedProductQuantity)
//        {
//            IWebElement productQuantityElement = Map.ProductQuantity(_productId);
//            string productQuantityString = productQuantityElement.GetAttribute("value");
//            int displayedProductQuantity = int.Parse(productQuantityString);
//            displayedProductQuantity.Should().Be(expectedProductQuantity);
//        }

//        public void CorrectProductTotalPriceDisplayed(decimal expectedTotalPrice)
//        {
//            string displayedProductTotalPrice = Map.TotalPriceForProduct(_productId).Text;
//            decimal totalPrice = DataManipulation.ConvertPriceToDecimal(displayedProductTotalPrice);
//            totalPrice.Should().BeApproximately(expectedTotalPrice, 2);
//        }

//        public void CorrectProductAvailabilityIsDisplayed(string expectedProductAvailability)
//        {
//            string displayedProductAvailability = Map.ProductAvailability(_productId).Text;
//            displayedProductAvailability.Should().BeEquivalentTo(expectedProductAvailability);
//        }

//        public void CorrectProductModelIsDisplayed(string expectedProductModel)
//        {
//            string rawProductModel = Map.ProductModel(_productId).Text;
//            int startIndexOfModel = rawProductModel.IndexOf('d');
//            string model = rawProductModel.Remove(0, startIndexOfModel);
//            model.Should().BeEquivalentTo(expectedProductModel);
//        }

//        public void CorrectCartTotalPriceIsDisplayed(decimal expectedTotalProductPrice)
//        {
//            string displayedTotalProductPrice = Map.TotalProductsPrice.Text;
//            decimal totalPrice = DataManipulation.ConvertPriceToDecimal(displayedTotalProductPrice);

//            totalPrice.Should().BeApproximately(expectedTotalProductPrice - 2, 2);
//        }

//        public void CorrectShippingCostIsDisplayed(decimal expectedShippingPrice)
//        {
//            string displayedProductShipping = Map.TotalShipping.Text;
//            decimal shippingPrice = DataManipulation.ConvertPriceToDecimal(displayedProductShipping);
//            shippingPrice.Should().BeApproximately(expectedShippingPrice, 2);
//        }

//        public void CorrectFinalPriceIsDisplayed(decimal expectedFinalPrice)
//        {
//            string displayedFinalPrice = Map.TotalProductsPriceWithShipping.Text;
//            decimal finalPrice = DataManipulation.ConvertPriceToDecimal(displayedFinalPrice);
//            finalPrice.Should().BeApproximately(expectedFinalPrice, 2);
//        }
//    }
//}