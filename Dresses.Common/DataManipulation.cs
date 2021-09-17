namespace Dresses.Common
{
    using System;

    public static class DataManipulation
    {
        private static string FormatPrice(string value)
            => value.Remove(0, 1);

        public static decimal ConvertPriceToDecimal(string value)
        {
            string formattedPrice = FormatPrice(value);
            return decimal.Parse(formattedPrice);
        }

        public static string ExtractBaseUrl(string url)
        {
            if (url.Length == DataConstants.LongUrl)
            {
                return url.Substring(0, 42);
            }
            if (url.Length == DataConstants.ShortUrl)
            {

                return url.Substring(0, 39);
            }

            throw new ArgumentException("Provided url is invalid");
        }

    }
}
