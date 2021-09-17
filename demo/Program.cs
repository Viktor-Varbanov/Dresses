namespace demo
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Page map = new Page();
            map.Validate().AssertProductName();
        }
    }
}
