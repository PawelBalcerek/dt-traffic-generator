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
            return new TestParameters(testParameters.TestParametersId, testParameters.NumberOfUsers, testParameters.NumberOfRequests, testParameters.MinBuyPrice,
                testParameters.MaxBuyPrice, testParameters.MinSellPrice, testParameters.MaxSellPrice);
        }
    }
}
