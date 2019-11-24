using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.RunTest.Abstract;

namespace TestLibrary.Infrastructure.RunTest.Concrete
{
    public class TestRunner : ITestRunner
    {
        public IRunTestResponse RunTest(int testParametersId)
        {
            //TODO
            //get TestParams model from database by "testParametersId"
            
            //TODO
            //run test with got parameters
            return new RunTestResponse(ResponseResultEnum.NotFound);
        }
    }
}
