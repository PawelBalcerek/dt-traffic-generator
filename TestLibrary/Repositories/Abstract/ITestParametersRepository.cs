using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.Repositories.Abstract
{
    public interface ITestParametersRepository
    {
        ITestParameters GetTestParameters(int testParametersId);
        long AddTestParameters();
    }
}
