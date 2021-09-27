using System;
using System.Collections.Generic;
using System.Linq;

namespace DressWebsiteTests.Model
{
    public class Cart
    {
        public const decimal SHIPPING_PRICE = 2.00M;
        private readonly ICollection<Product> _products;

        public Cart()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            var targetProduct = _products.FirstOrDefault(x => x.Id == product.Id);
            if (targetProduct != null)
            {
                targetProduct.Quantity += product.Quantity;
            }

            _products.Add(product);
        }

        public int GetProductsCount()
        {
            var productsCount = 0;
            foreach (var item in _products)
            {
                productsCount += item.Quantity;
            }

            return productsCount;
        }

        public decimal GetProductPriceById(string productId)
        {
            var product = _products.FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                throw new ArgumentException($"Product with id: {productId} doesn't exist in the cart");
            }
            return product.Quantity * product.Price;
        }

        public decimal GetTotalPrice()
        {
            decimal sum = 0.00m;

            foreach (var item in _products)
            {
                sum += item.Quantity * item.Price;
            }

            return sum;
        }
    }
}
