using System;
using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.BusinessObject
{
    public class Test : ITest
    {
        public Test(long testId, long testParametersId, long userId, long endpointId, double databaseTestTime, double applicationTestTime, double apiTestTime, DateTime timeStamp) 
            : this(testParametersId, userId, endpointId, databaseTestTime, applicationTestTime, apiTestTime)
        {
            TestId = testId;
            TimeStamp = timeStamp;
        }

        public Test(long testParametersId, long userId, long endpointId, double databaseTestTime, double applicationTestTime, double apiTestTime)
        {
            TestParametersId = testParametersId;
            UserId = userId;
            EndpointId = endpointId;
            DatabaseTestTime = databaseTestTime;
            ApplicationTestTime = applicationTestTime;
            ApiTestTime = apiTestTime;
            TimeStamp = DateTime.Now;;
        }

        public long TestId { get; }
        public long TestParametersId { get; }
        public long UserId { get; }
        public long EndpointId { get; }
        public double DatabaseTestTime { get; }
        public double ApplicationTestTime { get; }
        public double ApiTestTime { get; }
        public DateTime TimeStamp { get; }
    }
}
