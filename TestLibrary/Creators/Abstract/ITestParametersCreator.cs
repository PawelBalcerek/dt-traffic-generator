using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.TestParametersInfrastructure.Abstract;

namespace TestLibrary.Creators.Abstract
{
    public interface ITestParametersCreator
    {
        IAddTestParametersResponse AddTestParameters(TestParameters testParameters);

    }
}
