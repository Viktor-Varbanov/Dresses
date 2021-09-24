using System;

namespace DressWebsiteTests.Model
{
    public class ProductInformation
    {
        private decimal _price;

        public string Id { get; set; }

        public string Model { get; set; }

        public string Name { get; set; }

        public decimal Price
        {
            get
            {
                if (HasDiscount)
                {
                    HasDiscount = false;
                    return _price = ApplyDiscount(PercentageDiscount);
                }

                return _price;
            }
            set => _price = value;
        }

        public string Description { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public bool HasDiscount { get; set; }

        public double PercentageDiscount { get; set; }

        public int Quantity { get; set; }

        public string BaseImageUrl { get; set; }

        public string Availability { get; set; }

        private decimal ApplyDiscount(double percentage) => Math.Round(_price - _price * (decimal)(percentage / 100), 2);
    }
}