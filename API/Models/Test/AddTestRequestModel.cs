using System;

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

        public int TestParametersId { get; }
        public int UserId { get; }
        public int EndpointId { get; }
        public double DatabaseTestTime { get; }
        public double ApplicationTestTime { get; }
        public double ApiTestTime { get; }
    }
}
