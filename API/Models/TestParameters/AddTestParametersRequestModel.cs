using System.ComponentModel.DataAnnotations;

namespace API.Models.TestParameters
{
    public class AddTestParametersRequestModel
    {
        [Required]
        public int NumberOfUsers { get; set; }
        public string TestName { get; set; }

        [Required]
        public int NumberOfRequests { get; set; }

        [Required]
        public double MinBuyPrice { get; set; }

        [Required]
        public double MaxBuyPrice { get; set; }

        [Required]
        public double MinSellPrice { get; set; }

        [Required]
        public double MaxSellPrice { get; set; }
    }
}
