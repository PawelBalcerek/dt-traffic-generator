using System;
using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.BusinessObject
{
    public class Test : ITest
    {
        public Test(int testId, int testParametersId, int userId, int endpointId, DateTime databaseTestTime, DateTime applicationTestTime, DateTime apiTestTime)
        {
            TestId = testId;
            TestParametersId = testParametersId;
            UserId = userId;
            EndpointId = endpointId;
            DatabaseTestTime = databaseTestTime;
            ApplicationTestTime = applicationTestTime;
            ApiTestTime = apiTestTime;
        }

        public int TestId { get; }
        public int TestParametersId { get; }
        public int UserId { get; }
        public int EndpointId { get; }
        public DateTime DatabaseTestTime { get; }
        public DateTime ApplicationTestTime { get; }
        public DateTime ApiTestTime { get; }
    }
}
