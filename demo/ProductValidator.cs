namespace demo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;

    public class ProductValidator<M> : AbstractPageValidator<M>
        where M : AbstractPageMap, new()


    {

        
        public void AssertProductName(string productName, IWebElement element)
        {

        }
    }
}
