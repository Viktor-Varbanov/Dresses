namespace Dresses.Tests.TestingClasses.Cart
{
    using Models;
    using NUnit.Framework;
    using Shouldly;

    [TestFixture]
    public class AddNewProductShould
    {
        private Database _database;

        [OneTimeSetUp]
        public void SetUp()
        {
            _database = new Database();
        }

        [Test]
        public void AddNewProduct_When_ItDoesNotExist()
        {
            // --Arrange
            var expectedSum = 29.00m;
            var product = _database.GetProductById("product_2_7_0_0");

            // --Act
            Cart.AddProductToCart(product);
            var actualSum = Cart.CalculateSum();

            // --Assert
            actualSum.ShouldBe(expectedSum);
        }

        [Test]
        public void IncreaseTheQuantityOfTheProduct_When_ItAlreadyExists()
        {
            // --Arrange
            var expectedSum = 56.00m;
            var product = _database.GetProductById("product_2_7_0_0");
            // --Act
            Cart.AddProductToCart(product);
            Cart.AddProductToCart(product);
            var actualSum = Cart.CalculateSum();

            // --Assert
            actualSum.ShouldBe(expectedSum);
        }
    }
}