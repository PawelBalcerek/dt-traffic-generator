using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TestLibrary.BusinessObject.Abstract;

namespace Data.Models
{
    [Table("TestParameters")]
    public class TestParameters : ITestParameters
    {
        public TestParameters()
        {
            Tests = new HashSet<Test>();
        }

        public TestParameters(string testName, int numberOfUsers, int numberOfRequests, double minBuyPrice, double maxBuyPrice, double minSellPrice, double maxSellPrice)
        {
            NumberOfUsers = numberOfUsers;
            NumberOfRequests = numberOfRequests;
            MinBuyPrice = minBuyPrice;
            MaxBuyPrice = maxBuyPrice;
            MinSellPrice = minSellPrice;
            MaxSellPrice = maxSellPrice;
            MaxSellPrice = maxSellPrice;
            TestName = testName;
            Tests = new HashSet<Test>();
        }

        public int TestParametersId { get; set; }
        public string TestName { get; set; }
        public int NumberOfUsers { get; set; }
        public int NumberOfRequests { get; set; }
        public double MinBuyPrice { get; set; }
        public double MaxBuyPrice { get; set; }
        public double MinSellPrice { get; set; }
        public double MaxSellPrice { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
