using DressWebsiteTests.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DressWebsiteTests.Services
{
    public class ProductService
    {

        private readonly ICollection<Product> _products;

        public ProductService()
        {
            _products = new List<Product>();
            Seed();
        }

        private void Seed()
        {
            _products.Add(new Product
            {
                Id = "product_7_34_0_0",
                Name = "Printed Chiffon Dress",
                Model = "demo_7",
                Description = "Printed chiffon knee length dress with tank straps. Deep v-neckline.",
                Price = 20.50m,
                BaseImageUrl = "http://automationpractice.com/img/p/2/0/20",
                Color = "Yellow",
                Size = "S",
                Availability = "In stock",
                HasDiscount = true,
                PercentageDiscount = 20,
                Quantity = 1
            });
            _products.Add(new Product
            {
                Id = "product_7_38_0_0",
                Name = "Printed Chiffon Dress",
                Model = "demo_7",
                Description = "Printed chiffon knee length dress with tank straps. Deep v-neckline.",
                Price = 20.50m,
                BaseImageUrl = "http://automationpractice.com/img/p/2/2/22",
                Color = "Green",
                Size = "M",
                Availability = "In stock",
                HasDiscount = true,
                PercentageDiscount = 20,
                Quantity = 20
            });
        }

        public Product GetProductById(string id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new ArgumentException($"Product with id:{id} doesn't exist.");
            }

            return product;
        }
    }
}
