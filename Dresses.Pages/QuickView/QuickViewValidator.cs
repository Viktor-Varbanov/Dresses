﻿namespace Dresses.Pages.QuickView
{
    using System.Threading;
    using Common;
    using Models;

    public class QuickViewValidator : ProductValidator<QuickViewPageElementMap>
    {
        public void CorrectProductIsDisplayed(Product product)
        {
            VerifyProductName(product.Name, Map.ProductName.Text);
            VerifyProductSize(product.Size, Map.ProductSizeValue.Text);
            VerifyProductDescription(product.Description, Map.ProductDescription.Text);
            VerifyBaseImageUrl(product.BaseImageUrl, Map.ProductImage.GetAttribute("src"));
            if (CheckForDiscount)
            {
                var displayedPercentage = Map.ProductDiscount.Text;
                var actualDiscount = DataManipulation.ConvertPriceToDecimal(displayedPercentage);
                product.ApplyDiscount(actualDiscount);
            }
            VerifyProductPrice(product.Price, Map.ProductPrice.Text);
            VerifyProductColor(product.Color, Map.PickedColor.GetAttribute("name"));
        }

        public void CorrectChangesAreMade(Product product)
        {
            VerifyProductSize(product.Size, Map.ProductSizeValue.Text);
            VerifyBaseImageUrl(product.BaseImageUrl, Map.ProductImage.GetAttribute("src"));
            Thread.Sleep(2000);

            VerifyProductColor(product.Color, Map.PickedColor.GetAttribute("name"));

        }
        private bool CheckForDiscount
            => Map.ProductDiscount.Displayed;
    }
}
