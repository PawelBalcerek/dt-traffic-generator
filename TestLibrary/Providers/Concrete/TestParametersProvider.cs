using Serilog;
using System;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Infrastructure.TestParameters.Abstract;
using TestLibrary.Infrastructure.TestParameters.Concrete;
using TestLibrary.Providers.Abstract;
using TestLibrary.Repositories.Abstract;

namespace TestLibrary.Providers.Concrete
{
    public class TestParametersProvider : ITestParametersProvider
    {
        private readonly ITestParametersRepository _testParametersRepository;
        public TestParametersProvider(ITestParametersRepository testParametersRepository)
        {
            _testParametersRepository = testParametersRepository;
        }

        public IGetTestParametersResponse GetTestParameters(long testParametersId)
        {
            try
            {
                ITestParameters testParameters = _testParametersRepository.GetTestParameters(testParametersId);
                return new GetTestParametersResponse((BusinessObject.TestParameters)testParameters);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "GetTestParametersById(EXCEPTION)");
                return new GetTestParametersResponse();
            }

        }
    }
}
