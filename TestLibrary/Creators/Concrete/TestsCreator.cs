using System;
using System.Collections.Generic;
using Serilog;
using TestLibrary.BusinessObject;
using TestLibrary.Creators.Abstract;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.TestInfrastructure.Abstract;
using TestLibrary.Infrastructure.TestInfrastructure.Concrete;
using TestLibrary.Repositories.Abstract;

namespace TestLibrary.Creators.Concrete
{
    public class TestsCreator : ITestsCreator
    {
        private readonly ITestRepository _testRepository;

        public TestsCreator(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public IAddTestsResponse AddTests(IEnumerable<Test> tests)
        {
            try
            {
                _testRepository.AddTests(tests);
                return new AddTestsResponse(ResponseResultEnum.Success);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "AddTests(EXCEPTION)");
                return new AddTestsResponse(ResponseResultEnum.Exception);
            }

        }
    }
}
