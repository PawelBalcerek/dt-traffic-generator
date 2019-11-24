using System.Collections.Generic;
using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.Repositories.Abstract
{
    public interface ITestRepository
    {
        ITest GetTest(long testId);
        IEnumerable<ITest> GetTests();
        void AddTests(IEnumerable<ITest> tests);
    }
}
