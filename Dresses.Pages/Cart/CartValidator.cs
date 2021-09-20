namespace Dresses.Pages.Cart
{
    using Common;
    using Models;
    using NUnit.Framework;

    public class CartValidator : ProductValidator<CartElementMap>
    {

        public void Navigated()
        {
            Assert.AreEqual("Order - My Store", Driver.Browser.Title);
        }

        public void VerifyInformation(Product product)
        {
            VerifyProductName(product.Name, Map.ProductName(product.Id).Text);
            VerifyBaseImageUrl(product.BaseImageUrl, DataManipulation.ExtractBaseProductUrl(Map.ProductImageUrl(product.Id).GetAttribute("src")));
            VerifyProductPrice(product.Price, Map.ProductPrice(product.Id).Text);
            VerifyProductQuantity(product.Quantity, GetProductQuantity(product.Id));
            VerifyProductTotalPrice(Cart.GetProductTotalPriceById(product.Id), DataManipulation.ConvertPriceToDecimal(Map.TotalPriceForProduct(product.Id).Text));
            VerifyProductAvailability(product.Availability, Map.ProductAvailability(product.Id).Text);
        }

        private int GetProductQuantity(string id) => int.Parse(Map.ProductQuantity(id).GetAttribute("value"));


        public void VerifyProductQuantity(int expected, int actual)
        {
            Assert.AreEqual(expected, actual, FailTestMessage.ActualDifferentFromExpected(expected, actual));
        }

        public void VerifyProductTotalPrice(decimal expectedPrice, decimal actualPrice)
        {
            Assert.AreEqual(expectedPrice, actualPrice, FailTestMessage.ActualDifferentFromExpected(expectedPrice, actualPrice));
        }

        public void VerifyProductAvailability(string expectedAvailability, string actualAvailability)
        {
            Assert.AreEqual(expectedAvailability, actualAvailability, FailTestMessage.ActualDifferentFromExpected(expectedAvailability, actualAvailability));
        }
    }
}