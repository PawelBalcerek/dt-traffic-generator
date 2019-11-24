using System.Collections.Generic;
using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.Repositories.Abstract
{
    public interface ITestParametersRepository
    {
        ITestParameters GetTestParameters(long testParametersId);
        IEnumerable<ITestParameters> GetTestsParameters();
        ITestParameters AddTestParameters(ITestParameters testParameters);
    }
}
