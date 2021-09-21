namespace Dresses.Tests
{
    using Common;
    using NUnit.Framework;
    using Shouldly;

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
        public void BuildXpathWithOneArgument()
        {
            // --Arrange
            var basePath = "//tbody//tr[@id='{0}']";
            var extensionPath = "//child::td[@class='cart_product']//img";
            var argument = "product_1_1_0_0";
            var expectedValue = "//tbody//tr[@id='product_1_1_0_0']//child::td[@class='cart_product']//img";
            // --Act
            string actualValue = XPathBuilder.BuildXpath(basePath, extensionPath, argument);

            // --Assert
            actualValue.ShouldBeEquivalentTo(expectedValue);
        }

        [Test]
        public void BuildXpathWithTwoArguments()
        {
            // --Arrange
            var basePath = "//tbody//tr[@id='{0}']";
            var extensionPath = "//child::input[@type='hidden' and @name='{1}']";
            var argument = "product_1_1_0_0";
            var expectedValue = "//tbody//tr[@id='product_1_1_0_0']//child::input[@type='hidden' and @name='product_1_1_0_0']";
            // --Act
            string actualValue = XPathBuilder.BuildXpath(basePath, extensionPath, argument, argument);

            // --Assert
            actualValue.ShouldBeEquivalentTo(expectedValue);
        }

        [Test]
        public void TestingRegexForColorAndSize()
        {
            var x = DataManipulation.GetProductColorByRegex(
                "http://automationpractice.com/index.php?id_product=6&controller=product#/size-s/color-yellow");
        }
    }
}