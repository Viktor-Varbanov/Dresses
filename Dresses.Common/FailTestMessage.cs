namespace Dresses.Common
{
    public static class FailTestMessage
    {
        public static string ActualDifferentFromExpected(object expectedValue, object actualValue)
            => $"Expected value: {expectedValue}, Actual value: {actualValue}";
    }
}