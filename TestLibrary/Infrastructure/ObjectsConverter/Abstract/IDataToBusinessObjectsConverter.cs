using TestLibrary.BusinessObject;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Concrete;

namespace TestLibrary.Infrastructure.ObjectsConverter.Abstract
{
    public interface IDataToBusinessObjectsConverter
    {
        TestParameters ConvertTestParameters(ITestParameters testParameters);
        Test ConvertTest(ITest test);
        Endpoint ConvertEndpoint(IEndpoint endpoint);
        AverageEndpointsExecutionTimes ConvertAverageEndpointsExecutionTimes(IAverageEndpointsExecutionTimes data);
    }
}
