using System.Collections.Generic;
using System.Linq;
using TestLibrary.BusinessObject;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Infrastructure.ObjectsConverter.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Concrete;

namespace TestLibrary.Infrastructure.ObjectsConverter.Concrete
{
    public class DataToBusinessObjectsConverter : IDataToBusinessObjectsConverter
    {
        public TestParameters ConvertTestParameters(ITestParameters testParameters)
        {
            if (testParameters == null)
                return null;
            return new TestParameters(testParameters.TestParametersId, testParameters.TestName, testParameters.NumberOfUsers, testParameters.NumberOfRequests, testParameters.MinBuyPrice,
                testParameters.MaxBuyPrice, testParameters.MinSellPrice, testParameters.MaxSellPrice);
        }

        public Test ConvertTest(ITest test)
        {
            if (test == null)
                return null;
            return new Test(test.TestId, test.TestParametersId, test.UserId, test.EndpointId, test.DatabaseTestTime, test.ApplicationTestTime, test.ApiTestTime, test.TimeStamp);
        }

        public Endpoint ConvertEndpoint(IEndpoint endpoint)
        {
            if (endpoint == null)
                return null;
            return new Endpoint(endpoint.EndpointId, endpoint.EndpointName, endpoint.HttpMethod);
        }

        public AverageEndpointsExecutionTimes ConvertAverageEndpointsExecutionTimes(IAverageEndpointsExecutionTimes data)
        {
            if (data == null)
                return null;
            return new AverageEndpointsExecutionTimes(ConvertEndpoint(data.Endpoint),
                new ExecutionTimes(
                    data.AverageExecutionTimes.DatabaseTestTime,
                    data.AverageExecutionTimes.ApplicationTestTime,
                    data.AverageExecutionTimes.ApiTestTime));
        }


        private ExecutionTimesWithStamp ConvertExecutionTimesWithStamp(IExecutionTimesWithStamp data)
        {
            if (data == null)
                return null;
            return new ExecutionTimesWithStamp(data.DatabaseTestTime, data.ApplicationTestTime, data.ApiTestTime, data.TimeStamp);
        }

        public UserEndpointExecutionTimes ConvertUserEndpointExecutionTimes(IUserEndpointExecutionTimes data)
        {
            if (data == null)
                return null;
            return new UserEndpointExecutionTimes(data.UserId, ConvertEndpoint(data.Endpoint), data.ExecutionTimesWithStamps.Select(p => ConvertExecutionTimesWithStamp(p)));
        }
    }
}
