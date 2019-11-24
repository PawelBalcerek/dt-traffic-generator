using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Infrastructure.ObjectsConverter.Abstract;
using TestLibrary.Infrastructure.TestInfrastructure.Abstract;
using TestLibrary.Infrastructure.TestInfrastructure.Concrete;
using TestLibrary.Providers.Abstract;
using TestLibrary.Repositories.Abstract;

namespace TestLibrary.Providers.Concrete
{
    public class TestsProvider : ITestsProvider
    {
        private readonly ITestRepository _testRepository;
        private readonly IDataToBusinessObjectsConverter _converter;
        public TestsProvider(ITestRepository testRepository, IDataToBusinessObjectsConverter converter)
        {
            _testRepository = testRepository;
            _converter = converter;
        }

        public IGetTestResponse GetTest(long testId)
        {
            try
            {
                ITest test = _testRepository.GetTest(testId);
                return new GetTestResponse(_converter.ConvertTest(test));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "GetTestById(EXCEPTION)");
                return new GetTestResponse();
            }
        }

        public IGetTestsResponse GetTests()
        {
            try
            {
                IEnumerable<ITest> tests = _testRepository.GetTests();
                return new GetTestsResponse(tests.Select(p => _converter.ConvertTest(p)));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "GetTests(EXCEPTION)");
                return new GetTestsResponse();
            }
        }
    }
}
