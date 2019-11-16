using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Repositories.Abstract;

namespace Data.Repositories.Concrete
{
    public class TestParametersRepository : ITestParametersRepository
    {
        public ITestParameters GetTestParameters(int testParametersId)
        {
            throw new System.NotImplementedException();
        }

        public long AddTestParameters()
        {
            throw new System.NotImplementedException();
        }
    }
}
