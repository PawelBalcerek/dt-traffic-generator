namespace API.Models.TestParameters
{
    public class AddTestParametersRequestModel
    {
        public AddTestParametersRequestModel(int numberOfUsers, string testName, int numberOfRequests, double minBuyPrice, double maxBuyPrice, double minSellPrice, double maxSellPrice)
        {
            NumberOfUsers = numberOfUsers;
            TestName = testName;
            NumberOfRequests = numberOfRequests;
            MinBuyPrice = minBuyPrice;
            MaxBuyPrice = maxBuyPrice;
            MinSellPrice = minSellPrice;
            MaxSellPrice = maxSellPrice;
        }

        public int NumberOfUsers { get; }
        public string TestName { get; }
        public int NumberOfRequests { get; }
        public double MinBuyPrice { get; }
        public double MaxBuyPrice { get; }
        public double MinSellPrice { get; }
        public double MaxSellPrice { get; }
    }
}
