using TestLibrary.BusinessObject;
using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.Infrastructure.ObjectsConverter.Abstract
{
    public interface IDataToBusinessObjectsConverter
    {
        TestParameters ConvertTestParameters(ITestParameters testParameters);
        Test ConvertTest(ITest test);
        Endpoint ConvertEndpoint(IEndpoint endpoint);
    }
}
