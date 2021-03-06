﻿using System;
using System.Collections.Generic;
using System.Linq;
using TestLibrary.BusinessObject;
using TestLibrary.Creators.Abstract;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.EndpointInfrastructure.Abstract;
using TestLibrary.Infrastructure.RunTest.Abstract;
using TestLibrary.Infrastructure.TestInfrastructure.Abstract;
using TestLibrary.Infrastructure.TestLogic;
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
        private readonly IEndpointsCreator _endpointsCreator;
        private readonly IEndpointsProvider _endpointsProvider;
        private readonly ITestRun _testRun;


        public ExamplesRunner(ITestRunner testRunner, ITestsCreator testsCreator, ITestsProvider testsProvider, ITestParametersProvider testParametersProvider, ITestParametersCreator testParametersCreator, IEndpointsCreator endpointsCreator, IEndpointsProvider endpointsProvider, ITestRun testRun)
        {
            _testRunner = testRunner;
            _testsCreator = testsCreator;
            _testsProvider = testsProvider;
            _testParametersProvider = testParametersProvider;
            _testParametersCreator = testParametersCreator;
            _endpointsCreator = endpointsCreator;
            _endpointsProvider = endpointsProvider;
            _testRun = testRun;
        }

        public void RunTest(long id)
        {
            //long testParametersId = 1;
            TestParameters testParam = GetTestParameters(id);
            List<Test> testy = _testRun.TestMain(testParam);
            AddTests(testy);

            
            //IRunTestResponse runTestResponse = _testRunner.RunTest(testParametersId);
            //ResponseResultEnum result = runTestResponse.ResponseResult;
        }

        public void RunTestWithRandomParameter()
        {
            List<TestParameters> testParameters = GetTestsParameters();
            Random rnd = new Random();
            long paramId = testParameters[rnd.Next(0, testParameters.Capacity)].TestParametersId;
            RunTest(paramId);
        }

        public void AddTests(List<Test> testsList)
        {
            IList<Test> tests = testsList;
            //foreach (var test in testsList)
            //{
            //    tests.Add(new Test(test.TestParametersId, test.UserId, test.EndpointId, test.DatabaseTestTime, test.ApplicationTestTime, test.ApiTestTime));
            //}

            IAddTestsResponse addTestsResponse = _testsCreator.AddTests(tests);
            ResponseResultEnum result = addTestsResponse.ResponseResult;

            //IList<Test> tests = new List<Test>(); //TODO jak w bazie nie bedzie podanych "testParametersId" lub "endpointId" to narazie wraca status "Exception"
            //tests.Add(new Test(1, 1, 1, 20, 50, 100));
            //tests.Add(new Test(2, 1, 13, 20.6, 21.6, 34));
            //IAddTestsResponse addTestsResponse = _testsCreator.AddTests(tests);
            //ResponseResultEnum result = addTestsResponse.ResponseResult;
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

        public List<TestParameters> GetTestsParameters()
        {
            IGetTestsParametersResponse getTestsParametersResponse = _testParametersProvider.GetTestsParameters();
            List<TestParameters> tp = new List<TestParameters>();
            if (getTestsParametersResponse.ResponseResult == ResponseResultEnum.Success)
            {
                tp = getTestsParametersResponse.TestsParameters.ToList();
            }

            return tp;
        }

        public TestParameters GetTestParameters(long id)
        {
            //long testParameterId = 1;
            IGetTestParametersResponse getTestParametersResponse = _testParametersProvider.GetTestParameters(id);
            if (getTestParametersResponse.ResponseResult == ResponseResultEnum.Success)
            {
                TestParameters testParameters = getTestParametersResponse.TestParameters;
            }

            return getTestParametersResponse.TestParameters;
        }

        public void AddTestParameters()
        {
            TestParameters testParameters = new TestParameters(30, "pierwszy", 5, 10.50, 100, 1.50, 200);
            IAddTestParametersResponse addTestParametersResponse = _testParametersCreator.AddTestParameters(testParameters);
            if (addTestParametersResponse.ResponseResult == ResponseResultEnum.Success)
            {
                TestParameters addedTestParameters = addTestParametersResponse.AddedTestParameters; //TODO parametry zapisane w bazie, razem z testParametersId
            }
        }

        public void AddEndpoint()
        {
            Endpoint endpoint = new Endpoint("nazwa endpointa", "POST");
            IAddEndpointResponse addEndpointResponse = _endpointsCreator.AddEndpoint(endpoint);
            ResponseResultEnum result = addEndpointResponse.ResponseResult;
        }

        public void GetEndpoint()
        {
            long endpointId = 1;
            IGetEndpointResponse getEndpointResponse = _endpointsProvider.GetEndpoint(endpointId);
            if (getEndpointResponse.ResponseResult == ResponseResultEnum.Success)
            {
                Endpoint endpoint = getEndpointResponse.Endpoint;
            }
        }

        public void GetEndpoints()
        {
            IGetEndpointsResponse getEndpointsResponse = _endpointsProvider.GetEndpoints();
            if (getEndpointsResponse.ResponseResult == ResponseResultEnum.Success)
            {
                IList<Endpoint> endpoints = getEndpointsResponse.Endpoints.ToList();
            }
        }
    }
}
