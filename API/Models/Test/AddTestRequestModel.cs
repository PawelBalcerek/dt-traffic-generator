using System.ComponentModel.DataAnnotations;

namespace API.Models.Test
{
    public class AddTestRequestModel
    {
        [Required]
        public int TestParametersId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int EndpointId { get; set; }

        [Required]
        public double DatabaseTestTime { get; set; }

        [Required]
        public double ApplicationTestTime { get; set; }

        [Required]
        public double ApiTestTime { get; set; }
    }
}
