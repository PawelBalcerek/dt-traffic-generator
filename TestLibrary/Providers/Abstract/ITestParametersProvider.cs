using TestLibrary.Infrastructure.TestParametersInfrastructure.Abstract;

namespace TestLibrary.Providers.Abstract
{
    public interface ITestParametersProvider
    {
        IGetTestParametersResponse GetTestParameters(long testParametersId);
    }
}
