using Shouldly;

namespace DressWebsiteTests.Pages.PurchaseSummary
{
    public partial class PurchaseSummary
    {
        public void AssertCorrectProductNameIsDislpayed(string expectedProductName)
        {
            string productName = ProductName.Text;
            productName.ShouldBeEquivalentTo(expectedProductName);
        }
    }
}
