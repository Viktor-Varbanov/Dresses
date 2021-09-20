namespace Dresses.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Cart
    {
        private static List<Product> _products = new List<Product>();
        private const decimal ShippingCost = 2.00m;

        public static void AddProductToCart(Product product)
        {
            var productInCart =
                _products.FirstOrDefault(x => x.Color == product.Color && x.Name == product.Name);
            if (productInCart != null)
            {
                productInCart.Quantity += product.Quantity;
            }
            else
            {
                _products.Add(product);
            }
        }

        public static decimal CalculateSum()
        {
            decimal sum = 0;

            foreach (var product in _products)
            {
                sum += product.Quantity * product.Price;
            }
            return sum + ShippingCost;
        }

        public static decimal GetProductTotalPriceById(string productId)
        {
            var targetProduct = _products.FirstOrDefault(x => x.Id == productId);
            if (targetProduct == null)
                throw new ArgumentException($"Product with Id: {productId} doesn't exist in the cart.");

            return targetProduct.Quantity * targetProduct.Price;
        }
    }
}