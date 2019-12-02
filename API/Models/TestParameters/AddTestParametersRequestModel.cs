using System.ComponentModel.DataAnnotations;

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

        [Required]
        public int NumberOfUsers { get; }
        public string TestName { get; }

        [Required]
        public int NumberOfRequests { get; }

        [Required]
        public double MinBuyPrice { get; }

        [Required]
        public double MaxBuyPrice { get; }

        [Required]
        public double MinSellPrice { get; }

        [Required]
        public double MaxSellPrice { get; }
    }
}
