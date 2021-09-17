namespace Dresses.Pages
{
    using AbstractionPageComponents;
    using OpenQA.Selenium;

    public abstract class ProductValidator<TMap> : AbstractValidator<TMap>
        where TMap : AbstractElementMap, new()

    {

        public void ProductName(string expectedProductName, IWebElement nameLocator)
        {

        }

        public void ProductColor()
        {

        }
    }
}
