namespace TestLibrary.Infrastructure.RunTest.Abstract
{
    public interface ITestRunner
    {
        IRunTestResponse RunTest(long testParametersId);
    }
}
