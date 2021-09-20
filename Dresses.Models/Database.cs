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
                Name = "Blouse",
                Description = "Short sleeved blouse with feminine draped sleeve detail.",
                BaseImageUrl = "http://automationpractice.com/img/p/7/7",
                Price = 27.00m,
                Color = "Black",
                Size = "S",
                Id = "product_2_7_0_0"
            });
            products.Add(new Product()
            {
                Name = "Printed Chiffon Dress",
                Description = "Printed chiffon knee length dress with tank straps. Deep v-neckline.",
                BaseImageUrl = "http://automationpractice.com/img/p/2/0/20",
                Price = 20.50m,
                Color = "Yellow",
                Size = "S"
            });
            products.Add(new Product()
            {
                Name = "Faded Short Sleeve T-shirts",
                Color = "Blue"
            });
        }

        public Product GetProductByName(string name)
        {
            return products.FirstOrDefault(x => x.Name == name);
        }
    }
}
