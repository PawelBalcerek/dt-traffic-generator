
using TestLibrary.Infrastructure.TestInfrastructure.Abstract;

namespace TestLibrary.Providers.Abstract
{
    public interface ITestsProvider
    {
        IGetTestResponse GetTest(long testId);
        IGetTestsResponse GetTests();
    }
}
