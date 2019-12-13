using System.Collections.Generic;
using System.Threading.Tasks;
using TestLibrary.BusinessObject;

namespace TestLibrary.Infrastructure.TestLogic
{
    public interface ITestRun
    {
        List<Test> TestMain(TestParameters testParameters);
        
    }
}
