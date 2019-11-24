using TestLibrary.BusinessObject;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Infrastructure.ObjectsConverter.Abstract;

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
            return new Test(test.TestId, test.TestParametersId, test.UserId, test.EndpointId, test.DatabaseTestTime, test.ApplicationTestTime, test.ApiTestTime);
        }

        public Endpoint ConvertEndpoint(IEndpoint endpoint)
        {
            if (endpoint == null)
                return null;
            return new Endpoint(endpoint.EndpointId, endpoint.EndpointName, endpoint.HttpMethod);
        }
    }
}
