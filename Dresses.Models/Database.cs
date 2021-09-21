using System.Collections.Generic;
using System.Linq;

namespace Dresses.Models
{
    public class Database
    {
        private ICollection<Product> products;

        public Database()
        {
            products = new List<Product>();
            Seed();
        }

        private void Seed()
        {
            products.Add(new Product
            {
                Id = "product_2_7_0_0",
                Name = "Blouse",
                Model = "demo_2",
                Description = "Short sleeved blouse with feminine draped sleeve detail.",
                Price = 27.00m,
                BaseImageUrl = "http://automationpractice.com/img/p/7/7",
                Color = "Black",
                Size = "S",
                Availability = "In stock",
                HasDiscount = false,
                PercentageDiscount = 0,
                Quantity = 1
            });
            products.Add(new Product()
            {
                //different size different id
                Id = "product_2_8_0_0",
                Name = "Blouse",
                Model = "demo_2",
                Description = "Short sleeved blouse with feminine draped sleeve detail.",
                Price = 27.00m,
                BaseImageUrl = "http://automationpractice.com/img/p/5/5",
                Color = "White",
                Size = "M",
                Availability = "In stock",
                HasDiscount = false,
                PercentageDiscount = 0,
                Quantity = 1
            });
            products.Add(new Product()
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
            products.Add(new Product()
            {
                Id = "product_7_37_0_0",
                Name = "Printed Chiffon Dress",
                Model = "demo_7",
                Description = "Printed chiffon knee length dress with tank straps. Deep v-neckline.",
                Price = 20.50m,
                BaseImageUrl = "http://automationpractice.com/img/p/2/2/22",
                Color = "Green",
                Size = "S",
                Availability = "In stock",
                HasDiscount = true,
                PercentageDiscount = 20,
                Quantity = 1
            });
        }

        public Product GetProductById(string Id)
        {
            return products.FirstOrDefault(x => x.Id == Id);
        }
    }
}