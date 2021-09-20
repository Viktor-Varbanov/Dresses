namespace Dresses.Pages.Section.ProductSection
{
    public partial class ProductSection
    {
        private const string ProductElement = "//ul[@class='product_list row list']//li//div[@class='product-container']//div[@class='center-block col-xs-4 col-xs-7 col-md-4']//h5//a[@title='@name']";

        private const string DuplicateProducts = "//ul[@class='product_list row list']//li//div[@class='left-block col-xs-4 col-xs-5 col-md-4']//div[@class='product-image-container']//a[@title = 'Printed Summer Dress']//img[@src = 'http://automationpractice.com/img/p/1/2/12-home_default.jpg']";
    }
}