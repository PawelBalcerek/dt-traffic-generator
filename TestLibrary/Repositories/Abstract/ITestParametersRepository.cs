using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.Repositories.Abstract
{
    public interface ITestParametersRepository
    {
        ITestParameters GetTestParameters(long testParametersId);
        long AddTestParameters();
    }
}
