namespace Dresses.Common
{

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
            => url.Substring(0, 39);

    }
}
