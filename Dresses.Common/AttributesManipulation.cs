namespace Dresses.Common
{
    using OpenQA.Selenium;

    public static class AttributesManipulation
    {
        public static string GetValueByAttribute(IWebElement element, string attributeName) => element.GetAttribute(attributeName);
    }
}
