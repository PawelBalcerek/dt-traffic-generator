using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestLibrary.BusinessObject.Abstract;

namespace Data.Models
{
    [Table("Tests")]
    public class Test : ITest
    {
        public Test(long testId, long testParametersId, long userId, long endpointId, double databaseTestTime, double applicationTestTime, double apiTestTime, DateTime timeStamp) 
            : this(testParametersId, userId, endpointId, databaseTestTime, applicationTestTime, apiTestTime, timeStamp)
        {
            TestId = testId;
        }

        public Test(long testParametersId, long userId, long endpointId, double databaseTestTime, double applicationTestTime, double apiTestTime, DateTime timeStamp)
        {
            TestParametersId = testParametersId;
            UserId = userId;
            EndpointId = endpointId;
            DatabaseTestTime = databaseTestTime;
            ApplicationTestTime = applicationTestTime;
            ApiTestTime = apiTestTime;
            TimeStamp = timeStamp;
        }

        public long TestId { get; set; }
        public long TestParametersId { get; set; }
        public long UserId { get; set; }
        public long EndpointId { get; set; }
        public double DatabaseTestTime { get; set; }
        public double ApplicationTestTime { get; set; }
        public double ApiTestTime { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual TestParameters TestParameters { get; set; }
        public virtual Endpoint Endpoint { get; set; }
    }
}
