using System;
using System.Collections.Generic;
using System.Text;
using TestLibrary.BusinessObject;
using TestLibrary.Creators.Abstract;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.RunTest.Abstract;
using TestLibrary.Infrastructure.TestInfrastructure.Abstract;
using TestLibrary.Infrastructure.TestParametersInfrastructure.Abstract;
using TestLibrary.Providers.Abstract;

namespace TestLibrary.Infrastructure.TestLogic.DBMethods
{
    class Data : IData
    {

        private readonly ITestsCreator _testsCreator;

        private readonly ITestParametersProvider _testParametersProvider;


        public Data(ITestsCreator testsCreator, ITestParametersProvider testParametersProvider)
        {

            _testsCreator = testsCreator;

            _testParametersProvider = testParametersProvider;

        }

        public void AddTests(List<Test> tests)
        {
            try
            {
                // IList < Test > testy = tests; //TODO jak w bazie nie bedzie podanych "testParametersId" lub "endpointId" to narazie wraca status "Exception"
                //tests.Add(new Test(1, 1, 1, 20, 50, 100));
                //tests.Add(new Test(9, 1, 13, 20.6, 21.6, 34));
                IAddTestsResponse addTestsResponse = _testsCreator.AddTests(tests);
                ResponseResultEnum result = addTestsResponse.ResponseResult;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        public TestParameters GetTestParameters(long paramId)
        {
            //long testParameterId = 1;
            IGetTestParametersResponse getTestParametersResponse = _testParametersProvider.GetTestParameters(paramId);

            if (getTestParametersResponse.ResponseResult == ResponseResultEnum.Success)
            {
                 TestParameters testParameters = getTestParametersResponse.TestParameters;
            }

            return getTestParametersResponse.TestParameters;
        }
    }
}
