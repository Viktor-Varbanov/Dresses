namespace Dresses.Models
{
    using System;
    using System.Text.RegularExpressions;

    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
        //Is it better to extract it as an enumeration
        public string Size { get; set; } = "S";

        public string Color { get; set; }

        public int Quantity { get; set; } = 1;


        public string BaseImageUrl { get; set; }

        public void ApplyDiscount(decimal percentage)
            => Price = Math.Round(Price - Price * (decimal)(percentage / 100), 2);

    }
}
