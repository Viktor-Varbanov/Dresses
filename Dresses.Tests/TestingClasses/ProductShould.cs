namespace Dresses.Tests.TestingClasses
{
    using FluentAssertions;
    using Models;
    using NUnit.Framework;

    [TestFixture]
    public class ProductShould
    {
        [Test]
        public void GetCorrectPrice_When_DiscountIsApplied()
        {
            Product product = new Product()
            {
                Name = "Blouse",
                Description = "Short sleeved blouse with feminine draped sleeve detail.",
                BaseImageUrl = "http://automationpractice.com/img/p/7/7",
                Price = 100m,
                Color = "Black",
                Size = "S",
                Id = "product_2_7_0_0",
                Availability = "In stock",
                HasDiscount = true,
                PercentageDiscount = 20
            };

            decimal actualPrice = product.Price;
            decimal newPrice = product.Price;
            decimal expectedPrice = 80.00m;
            newPrice.Should().BeApproximately(expectedPrice, 2);
        }
    }
}