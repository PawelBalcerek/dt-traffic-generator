using Serilog;
using System;
using System.Collections.Generic;
using TestLibrary.BusinessObject;
using TestLibrary.Creators.Abstract;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.RunTest.Abstract;
using TestLibrary.Infrastructure.TestInfrastructure.Abstract;
using TestLibrary.Infrastructure.TestLogic;
using TestLibrary.Infrastructure.TestParametersInfrastructure.Abstract;
using TestLibrary.Providers.Abstract;

namespace TestLibrary.Infrastructure.RunTest.Concrete
{
    public class TestRunner : ITestRunner
    {
        private readonly ITestParametersProvider _testParametersProvider;
        private readonly ITestRun _testRun;
        private readonly ITestsCreator _testsCreator;
        public TestRunner(ITestParametersProvider testParametersProvider, ITestRun testRun, ITestsCreator testsCreator)
        {
            _testParametersProvider = testParametersProvider;
            _testRun = testRun;
            _testsCreator = testsCreator;
        }
        public IRunTestResponse RunTest(long testParametersId)
        {
            try
            {
                IGetTestParametersResponse getTestParametersResponse = _testParametersProvider.GetTestParameters(testParametersId);
                if (getTestParametersResponse.ResponseResult != ResponseResultEnum.Success)
                {
                    Log.Error($"TestRunner(RunTest)(ERROR): Something went wrong while call GetTestParameters method with id {testParametersId}, response: {getTestParametersResponse.ResponseResult}");
                    return new RunTestResponse(getTestParametersResponse.ResponseResult);
                }

                IList<Test> tests = _testRun.TestMain(getTestParametersResponse.TestParameters);

                IAddTestsResponse addTestsResponse = _testsCreator.AddTests(tests);
                if (addTestsResponse.ResponseResult != ResponseResultEnum.Success)
                {
                    Log.Error($"TestRunner(RunTest)(ERROR): Something went wrong while call AddTests method, response: {addTestsResponse.ResponseResult}");
                    return new RunTestResponse(getTestParametersResponse.ResponseResult);
                }

                return new RunTestResponse(ResponseResultEnum.Success);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"TestRunner(RunTest)(EXCEPTION): Something went wrong while trying to run test by id = {testParametersId}");
                return new RunTestResponse(ResponseResultEnum.Exception);
            }

        }
    }
}
