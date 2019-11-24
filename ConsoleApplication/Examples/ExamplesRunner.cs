using System;
using System.Collections.Generic;
using System.Linq;
using TestLibrary.BusinessObject;
using TestLibrary.Creators.Abstract;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.RunTest.Abstract;
using TestLibrary.Infrastructure.TestInfrastructure.Abstract;
using TestLibrary.Infrastructure.TestParametersInfrastructure.Abstract;
using TestLibrary.Providers.Abstract;

namespace ConsoleApplication.Examples
{
    public class ExamplesRunner : IExamplesRunner
    {
        private readonly ITestRunner _testRunner;
        private readonly ITestsCreator _testsCreator;
        private readonly ITestsProvider _testsProvider;
        private readonly ITestParametersProvider _testParametersProvider;
        private readonly ITestParametersCreator _testParametersCreator;

        public ExamplesRunner(ITestRunner testRunner, ITestsCreator testsCreator, ITestsProvider testsProvider, ITestParametersProvider testParametersProvider, ITestParametersCreator testParametersCreator)
        {
            _testRunner = testRunner;
            _testsCreator = testsCreator;
            _testsProvider = testsProvider;
            _testParametersProvider = testParametersProvider;
            _testParametersCreator = testParametersCreator;
        }

        public void RunTest()
        {
            long testParametersId = 1;
            IRunTestResponse runTestResponse = _testRunner.RunTest(testParametersId);
            ResponseResultEnum result = runTestResponse.ResponseResult;
        }

        public void AddTests()
        {
            IList<Test> tests = new List<Test>();
            tests.Add(new Test(1, 1, 1, new DateTime(), new DateTime(), new DateTime()));
            tests.Add(new Test(2, 2, 2, new DateTime(), new DateTime(), new DateTime()));
            IAddTestsResponse addTestsResponse = _testsCreator.AddTests(tests);
            ResponseResultEnum result = addTestsResponse.ResponseResult;
        }

        public void GetTests()
        {
            IGetTestsResponse getTestsResponse = _testsProvider.GetTests();
            if (getTestsResponse.ResponseResult == ResponseResultEnum.Success)
            {
                IList<Test> tests = getTestsResponse.Tests.ToList();
            }
        }

        public void GetTest()
        {
            long testId = 1;
            IGetTestResponse getTestResponse = _testsProvider.GetTest(testId);
            if (getTestResponse.ResponseResult == ResponseResultEnum.Success)
            {
                Test test = getTestResponse.Test;
            }
        }

        public void GetTestsParameters()
        {
            IGetTestsParametersResponse getTestsParametersResponse = _testParametersProvider.GetTestsParameters();
            if (getTestsParametersResponse.ResponseResult == ResponseResultEnum.Success)
            {
                IList<TestParameters> testsParameters = getTestsParametersResponse.TestsParameters.ToList();
            }
        }

        public void GetTestParameters()
        {
            long testParameterId = 1;
            IGetTestParametersResponse getTestParametersResponse = _testParametersProvider.GetTestParameters(testParameterId);
            if (getTestParametersResponse.ResponseResult == ResponseResultEnum.Success)
            {
                TestParameters testParameters = getTestParametersResponse.TestParameters;
            }
        }

        public void AddTestParameters()
        {
            TestParameters testParameters = new TestParameters(20, "nazwa testu", 50, 10.50, 100, 1.50, 200);
            IAddTestParametersResponse addTestParametersResponse = _testParametersCreator.AddTestParameters(testParameters);
            if (addTestParametersResponse.ResponseResult == ResponseResultEnum.Success)
            {
                TestParameters addedTestParameters = addTestParametersResponse.AddedTestParameters; //TODO parametry zapisane w bazie, razem z testParametersId
            }
        }
    }
}
