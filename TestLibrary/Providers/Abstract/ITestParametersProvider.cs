using TestLibrary.Infrastructure.TestParameters.Abstract;

namespace TestLibrary.Providers.Abstract
{
    public interface ITestParametersProvider
    {
        IGetTestParametersResponse GetTestParameters(long testParametersId);
    }
}
