namespace Dresses.Common
{
    public static class FailTestMessage
    {
        public static string ActualDifferentFromExpected(string expectedValue, string actualValue)
            => $"Expected value: {expectedValue}, Actual value: {actualValue}";


    }
}
