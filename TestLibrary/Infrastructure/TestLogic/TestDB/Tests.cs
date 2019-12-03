using System;
using System.Collections.Generic;
using System.Text;

namespace TestLibrary.Infrastructure.TestLogic.TestDB
{
    public class Test
    {
        //public Test(int testId, int testParametersId, int userId, int endpointId, DateTime databaseTestTime, DateTime applicationTestTime, DateTime apiTestTime)
        //    : this(testParametersId, userId, endpointId, databaseTestTime, applicationTestTime, apiTestTime)
        //{
        //    TestId = testId;
        //}

        public Test(DateTime testDate, int testParametersId, int userId, int endpointId, long databaseTestTime, long applicationTestTime, long apiTestTime)
        {
            TestTime = testDate;
            TestParametersId = testParametersId;
            UserId = userId;
            EndpointId = endpointId;
            DatabaseTestTime = databaseTestTime;
            ApplicationTestTime = applicationTestTime;
            ApiTestTime = apiTestTime;
        }
        public DateTime TestTime { get; set; }
        public int TestId { get; set; }
        public int TestParametersId { get; set; }
        public int UserId { get; set; }
        public int EndpointId { get; set; }
        public long DatabaseTestTime { get; set; }
        public long ApplicationTestTime { get; set; }
        public long ApiTestTime { get; set; }

        //public virtual TestParameters TestParameters { get; set; }
        //public virtual Endpoint Endpoint { get; set; }
    }
}
