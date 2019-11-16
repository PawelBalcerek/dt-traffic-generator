using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.Repositories.Abstract
{
    public interface ITestRepository
    {
        ITest GetTest(int id);
        long AddTest();
    }
}
