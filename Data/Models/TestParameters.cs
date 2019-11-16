using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("TestParameters")]
    public class TestParameters
    {
        public TestParameters()
        {
            Tests = new HashSet<Test>();
        }

        public int TestParametersId { get; set; }
        public int NumberOfUsers { get; set; }
        public int NumberOfRequests { get; set; }
        public double MinBuyPrice { get; set; }
        public double MaxBuyPrice { get; set; }
        public double MinSellPrice { get; set; }
        public double MaxSellPrice { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
