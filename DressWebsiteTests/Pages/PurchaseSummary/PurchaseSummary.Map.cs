using DressWebsiteTests.Extensions;
using OpenQA.Selenium;

namespace DressWebsiteTests.Pages.PurchaseSummary
{
    public partial class PurchaseSummary
    {
        //Product Information
        public IWebElement ProductSectionHeaderText => Driver.FindElementByTagName("h2");

        public IWebElement ProductName => Driver.FindElementById("layer_cart_product_title");

        public IWebElement ProductImageUrl(string productName)
        {
            return Driver.FindElementByCssSelector($"img[title='{productName}']");
        }

        public IWebElement ProductQuantity => Driver.FindElementById("layer_cart_product_quantity");

        public IWebElement CurrentlyAddedProductTotalPrice => Driver.FindElementById("layer_cart_product_price");

        public IWebElement ProductAttributes => Driver.FindElementById("layer_cart_product_attributes");

        public IWebElement CurrentlyAddedProductCost => Driver.FindElementById("layer_cart_product_price");

        public IWebElement CartSectionHeaderTextWithOneProduct => Driver.FindElementByCssSelector("h2 > span[class='ajax_cart_product_txt ']");

        public IWebElement CartSectionHeaderWithMoreThanOneProduct => Driver.FindElementByCssSelector("h2 > span[class='ajax_cart_product_txt_s  unvisible']");

        public IWebElement ProductsCost => Driver.FindElementByClassName("ajax_block_products_total");

        public IWebElement ShippingCost => Driver.FindElementByCssSelector("span[class='ajax_cart_shipping_cost']");

        public IWebElement TotalCost => Driver.FindElementByCssSelector("span[class='ajax_block_cart_total']");

        public IWebElement ProceedToCheckoutButton => Driver.FindElementByCssSelector("a[title='Proceed to checkout']");
    }
}