using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.BusinessObject
{
    public class TestParameters : ITestParameters
    {
        public TestParameters(int testParametersId, string testName, int numberOfUsers, int numberOfRequests, double minBuyPrice, double maxBuyPrice, double minSellPrice, double maxSellPrice) 
            : this(numberOfUsers, testName, numberOfRequests, minBuyPrice, maxBuyPrice, minSellPrice, maxSellPrice)
        {
            TestParametersId = testParametersId;
        }

        public TestParameters(int numberOfUsers, string testName, int numberOfRequests, double minBuyPrice, double maxBuyPrice, double minSellPrice, double maxSellPrice)
        {
            NumberOfUsers = numberOfUsers;
            TestName = testName;
            NumberOfRequests = numberOfRequests;
            MinBuyPrice = minBuyPrice;
            MaxBuyPrice = maxBuyPrice;
            MinSellPrice = minSellPrice;
            MaxSellPrice = maxSellPrice;
        }

        public int TestParametersId { get; }
        public string TestName { get; }
        public int NumberOfUsers { get; }
        public int NumberOfRequests { get; }
        public double MinBuyPrice { get; }
        public double MaxBuyPrice { get; }
        public double MinSellPrice { get; }
        public double MaxSellPrice { get; }
    }
}
