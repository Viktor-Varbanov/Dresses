﻿namespace Dresses.Pages.PurchaseSummary
{
    using System.Linq;
    using Common;
    using Models;
    using NUnit.Framework;

    public class PurchaseSummaryValidator : ProductValidator<PurchaseSummaryElementMap>
    {
        public void ItemSuccessfullyAddedToCart()
        {
            var headingText = Map.SuccessfulMessage.Text;
            Assert.AreEqual("Product successfully added to your shopping cart", headingText);
        }
        public void CorrectProductIsAddedToCart(Product product)
        {
            VerifyProductName(product.Name, Map.ProductName.Text);
            VerifyBaseImageUrl(product.BaseImageUrl, DataManipulation.ExtractBaseProductUrl(Map.ProductImageUrl(product.BaseImageUrl).GetAttribute("src")));
            VerifyProductQuantity(product.Quantity, int.Parse(Map.ProductQuantity.Text));
            VerifyProductTotalPrice(product.Quantity * product.Price, DataManipulation.ConvertPriceToDecimal(Map.Total.Text));
            VerifyProductColor(product.Color, SplitAttributes[0]);
            VerifyProductSize(product.Size, SplitAttributes[1]);

        }

        public void VerifyProductQuantity(int expectedProductQuantity, int actualProductQuantity)
        {
            Assert.AreEqual(expectedProductQuantity, actualProductQuantity, FailTestMessage.ActualDifferentFromExpected(expectedProductQuantity, actualProductQuantity));
        }

        public void VerifyProductTotalPrice(decimal expectedTotalPrice, decimal actualTotalPrice)
        {
            Assert.AreEqual(expectedTotalPrice, actualTotalPrice, FailTestMessage.ActualDifferentFromExpected(expectedTotalPrice, actualTotalPrice));
        }


        //0 for color, 1 for size
        private string[] SplitAttributes => Map.ProductColorAndSize.Text.Split(", ").ToArray();

    }
}
