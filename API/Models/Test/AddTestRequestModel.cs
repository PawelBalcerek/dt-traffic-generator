using System;

namespace API.Models.Test
{
    public class AddTestRequestModel
    {
        public AddTestRequestModel(int testParametersId, int userId, int endpointId, DateTime databaseTestTime, DateTime applicationTestTime, DateTime apiTestTime)
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
        public DateTime DatabaseTestTime { get; }
        public DateTime ApplicationTestTime { get; }
        public DateTime ApiTestTime { get; }
    }
}
