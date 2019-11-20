namespace TestLibrary.Infrastructure.RunTest.Abstract
{
    public interface ITestRunner
    {
        IRunTestResponse RunTest(int testParametersId);
    }
}
