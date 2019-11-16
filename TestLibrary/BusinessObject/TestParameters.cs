using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.BusinessObject
{
    public class TestParameters : ITestParameters
    {
        public TestParameters(int testParametersId, int numberOfUsers, int numberOfRequests, double minBuyPrice, double maxBuyPrice, double minSellPrice, double maxSellPrice)
        {
            TestParametersId = testParametersId;
            NumberOfUsers = numberOfUsers;
            NumberOfRequests = numberOfRequests;
            MinBuyPrice = minBuyPrice;
            MaxBuyPrice = maxBuyPrice;
            MinSellPrice = minSellPrice;
            MaxSellPrice = maxSellPrice;
        }

        public int TestParametersId { get; }
        public int NumberOfUsers { get; }
        public int NumberOfRequests { get; }
        public double MinBuyPrice { get; }
        public double MaxBuyPrice { get; }
        public double MinSellPrice { get; }
        public double MaxSellPrice { get; }
    }
}
