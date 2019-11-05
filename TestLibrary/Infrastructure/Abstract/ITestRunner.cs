using TestLibrary.Infrastructure.Const;

namespace TestLibrary.Infrastructure.Abstract
{
    interface ITestRunner
    {
        void RunTest(TestType testType);
    }
}
