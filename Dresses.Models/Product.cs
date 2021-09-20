namespace Dresses.Models
{
    using System;

    public class Product
    {
        private decimal _price;

        public string Id { get; set; }
        public bool HasDiscount { get; set; }

        public string Model { get; set; }
        public double PercentageDiscount { get; set; }
        public string Name { get; set; }

        public decimal Price
        {
            get
            {
                if (HasDiscount)
                {
                    ApplyDiscount(PercentageDiscount);
                    HasDiscount = false;
                    return _price;

                }

                return _price;
            }
            set => _price = value;
        }

        public string Description { get; set; }

        //Is it better to extract it as an enumeration
        public string Size { get; set; } = "S";

        public string Color { get; set; }

        public int Quantity { get; set; } = 1;

        public string BaseImageUrl { get; set; }
        public string Availability { get; set; }

        private void ApplyDiscount(double percentage)
        {
            _price = Math.Round(_price - _price * (decimal)(percentage / 100), 2);

        }

    }
}