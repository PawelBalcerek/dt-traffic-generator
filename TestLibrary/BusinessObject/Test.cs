using System;
using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.BusinessObject
{
    public class Test : ITest
    {
        public Test(int testId, int testParametersId, int userId, int endpointId, double databaseTestTime, double applicationTestTime, double apiTestTime, DateTime timeStamp) 
            : this(testParametersId, userId, endpointId, databaseTestTime, applicationTestTime, apiTestTime)
        {
            TestId = testId;
            TimeStamp = timeStamp;
        }

        public Test(int testParametersId, int userId, int endpointId, double databaseTestTime, double applicationTestTime, double apiTestTime)
        {
            TestParametersId = testParametersId;
            UserId = userId;
            EndpointId = endpointId;
            DatabaseTestTime = databaseTestTime;
            ApplicationTestTime = applicationTestTime;
            ApiTestTime = apiTestTime;
            TimeStamp = DateTime.Now;;
        }

        public int TestId { get; }
        public int TestParametersId { get; }
        public int UserId { get; }
        public int EndpointId { get; }
        public double DatabaseTestTime { get; }
        public double ApplicationTestTime { get; }
        public double ApiTestTime { get; }
        public DateTime TimeStamp { get; }
    }
}
