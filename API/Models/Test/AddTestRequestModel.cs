using System.ComponentModel.DataAnnotations;

namespace API.Models.Test
{
    public class AddTestRequestModel
    {
        public AddTestRequestModel(int testParametersId, int userId, int endpointId, double databaseTestTime, double applicationTestTime, double apiTestTime)
        {
            TestParametersId = testParametersId;
            UserId = userId;
            EndpointId = endpointId;
            DatabaseTestTime = databaseTestTime;
            ApplicationTestTime = applicationTestTime;
            ApiTestTime = apiTestTime;
        }

        [Required]
        public int TestParametersId { get; }

        [Required]
        public int UserId { get; }

        [Required]
        public int EndpointId { get; }

        [Required]
        public double DatabaseTestTime { get; }

        [Required]
        public double ApplicationTestTime { get; }

        [Required]
        public double ApiTestTime { get; }
    }
}
