namespace Dresses.Common
{
    using System.Text.RegularExpressions;

    public static class DataManipulation
    {
        private const string DiscountRegexPattern = "[0-9]{1,2}(.[0-9]{1,2})?";

        private const string BaseImageUrlRegexPattern = "[^-]*";

        private const string ColorAndSizeRegexPattern = "-([a-z]*)";

        private static string GetPriceMatchedByRegex(string value)
        {
            var x = Regex.Match(value, DiscountRegexPattern);
            return x.ToString();
        }

        public static decimal ConvertPriceToDecimal(string value)
        {
            var formattedPrice = GetPriceMatchedByRegex(value);
            return decimal.Parse(formattedPrice);
        }

        public static string ExtractBaseProductUrl(string url)
        {
            var x = Regex.Match(url, BaseImageUrlRegexPattern);
            return x.ToString();
        }

        public static string GetProductColorByRegex(string input)
        {
            var x = Regex.Matches(input, ColorAndSizeRegexPattern);
            return x[1].ToString().Remove(0, 1);
        }

        public static string GetProductSizeByRegex(string input)
        {
            var x = Regex.Matches(input, ColorAndSizeRegexPattern);
            return x[0].ToString().Remove(0, 1);
        }
    }
}