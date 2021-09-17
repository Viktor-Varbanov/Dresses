namespace Dresses.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cart
    {
        public List<Product> Products { get; set; }
        private decimal sum;

        public Cart()
        {
            Products = new List<Product>();
        }

        public decimal Total => CalculateSum();


        private decimal CalculateSum()
        {
            foreach (var product in Products)
            {
                sum += product.Quantity * product.Price;
            }

            return sum;
        }
    }
}
