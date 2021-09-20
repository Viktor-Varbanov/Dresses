namespace Dresses.Common
{
    using System.Text;

    public static class XPathBuilder
    {
        public static string BuildXpath(string basePath, string extensionPath, string firstArgument)
        {
            var sb = new StringBuilder(basePath);
            sb.Append(extensionPath);
            var GenericPath = sb.ToString();
            return string.Format(GenericPath, firstArgument);
        }

        public static string BuildXpath(string basePath, string extensionPath, string firstArgument, string secondArgument)
        {
            var sb = new StringBuilder(basePath);
            sb.Append(extensionPath);
            var GenericPath = sb.ToString();
            return string.Format(GenericPath, firstArgument, secondArgument);
        }
    }
}