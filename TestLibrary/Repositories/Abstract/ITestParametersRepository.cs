using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.Repositories.Abstract
{
    public interface ITestParametersRepository
    {
        ITestParameters GetTestParameters(long testParametersId);
        ITestParameters AddTestParameters(ITestParameters testParameters);
    }
}
