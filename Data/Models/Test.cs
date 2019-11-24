using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestLibrary.BusinessObject.Abstract;

namespace Data.Models
{
    [Table("Tests")]
    public class Test : ITest
    {
        public Test(int testId, int testParametersId, int userId, int endpointId, DateTime databaseTestTime, DateTime applicationTestTime, DateTime apiTestTime) 
            : this(testParametersId, userId, endpointId, databaseTestTime, applicationTestTime, apiTestTime)
        {
            TestId = testId;
        }

        public Test(int testParametersId, int userId, int endpointId, DateTime databaseTestTime, DateTime applicationTestTime, DateTime apiTestTime)
        {
            TestParametersId = testParametersId;
            UserId = userId;
            EndpointId = endpointId;
            DatabaseTestTime = databaseTestTime;
            ApplicationTestTime = applicationTestTime;
            ApiTestTime = apiTestTime;
        }

        public int TestId { get; set; }
        public int TestParametersId { get; set; }
        public int UserId { get; set; }
        public int EndpointId { get; set; }
        public DateTime DatabaseTestTime { get; set; }
        public DateTime ApplicationTestTime { get; set; }
        public DateTime ApiTestTime { get; set; }

        public virtual TestParameters TestParameters { get; set; }
        public virtual Endpoint Endpoint { get; set; }
    }
}
