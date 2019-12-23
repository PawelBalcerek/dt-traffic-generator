using System.Collections.Generic;
using TestLibrary.BusinessObject;

namespace ConsoleApplication.Examples
{
    public interface IExamplesRunner
    {
        void RunTest(long id);
        void RunTestWithRandomParameter();
        void AddTests(List<Test> tests);
        void GetTests();
        void GetTest();
        List<TestParameters> GetTestsParameters();
        TestParameters GetTestParameters(long id);
        void AddTestParameters();
        void AddEndpoint();
        void GetEndpoint();
        void GetEndpoints();
    }
}
