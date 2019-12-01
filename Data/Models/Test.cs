using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestLibrary.BusinessObject.Abstract;

namespace Data.Models
{
    [Table("Tests")]
    public class Test : ITest
    {
        public Test(int testId, int testParametersId, int userId, int endpointId, DateTime databaseTestTime, DateTime applicationTestTime, DateTime apiTestTime, DateTime timeStamp) 
            : this(testParametersId, userId, endpointId, databaseTestTime, applicationTestTime, apiTestTime, timeStamp)
        {
            TestId = testId;
        }

        public Test(int testParametersId, int userId, int endpointId, DateTime databaseTestTime, DateTime applicationTestTime, DateTime apiTestTime, DateTime timeStamp)
        {
            TestParametersId = testParametersId;
            UserId = userId;
            EndpointId = endpointId;
            DatabaseTestTime = databaseTestTime;
            ApplicationTestTime = applicationTestTime;
            ApiTestTime = apiTestTime;
            TimeStamp = timeStamp;
        }

        public int TestId { get; set; }
        public int TestParametersId { get; set; }
        public int UserId { get; set; }
        public int EndpointId { get; set; }
        public DateTime DatabaseTestTime { get; set; }
        public DateTime ApplicationTestTime { get; set; }
        public DateTime ApiTestTime { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual TestParameters TestParameters { get; set; }
        public virtual Endpoint Endpoint { get; set; }
    }
}
