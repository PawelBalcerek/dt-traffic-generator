using TestLibrary.BusinessObject;
using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.Infrastructure.ObjectsConverter.Abstract
{
    public interface IDataToBusinessObjectsConverter
    {
        TestParameters ConvertTestParameters(ITestParameters testParameters);
    }
}
