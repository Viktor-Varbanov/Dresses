namespace Dresses.Tests
{
    using Common;
    using Models;
    using NUnit.Framework;

    [TestFixture]
    public class TestingInfrastructure
    {
        [Test]
        [TestCase(20, "-20%")]
        [TestCase(5, "-5%")]
        [TestCase(16.40, "$16.40")]
        public void TestRegexPattern(decimal expectedPrice, string productPrice)
        {
            // --Arrange
            var expectedValue = expectedPrice;
            // --Act
            var actualValue = DataManipulation.ConvertPriceToDecimal(productPrice);

            // --Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TestUrlRegexPatter()
        {
            // --Arrange
            var expectedUrl = "http://automationpractice.com/img/p/7/7";
            var urlGetFromTextProperty = "http://automationpractice.com/img/p/7/7-small_default.jpg";
            // --Act
            var cuttedUrl = DataManipulation.ExtractBaseProductUrl(urlGetFromTextProperty);

            // --Assert
            Assert.AreEqual(expectedUrl, cuttedUrl);
        }

        [Test]
        public void AddCartShouldAddNewProduct_When_ItDoesNotExistInTheCart()
        {
            // --Arrange
            var database = new Database();
            var product = database.GetProductByName("Blouse");

            // --Act
            Cart.AddProductToCart(product);

            // --Assert
            Assert.AreEqual(27.00m, Cart.CalculateSum());
        }

        
    }

}
