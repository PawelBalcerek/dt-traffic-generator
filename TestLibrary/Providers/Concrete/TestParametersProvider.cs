using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Infrastructure.ObjectsConverter.Abstract;
using TestLibrary.Infrastructure.TestParametersInfrastructure.Abstract;
using TestLibrary.Infrastructure.TestParametersInfrastructure.Concrete;
using TestLibrary.Providers.Abstract;
using TestLibrary.Repositories.Abstract;

namespace TestLibrary.Providers.Concrete
{
    public class TestParametersProvider : ITestParametersProvider
    {
        private readonly ITestParametersRepository _testParametersRepository;
        private readonly IDataToBusinessObjectsConverter _converter;
        public TestParametersProvider(ITestParametersRepository testParametersRepository, IDataToBusinessObjectsConverter converter)
        {
            _testParametersRepository = testParametersRepository;
            _converter = converter;
        }

        public IGetTestParametersResponse GetTestParameters(long testParametersId)
        {
            try
            {
                ITestParameters testParameters = _testParametersRepository.GetTestParameters(testParametersId);
                return new GetTestParametersResponse(_converter.ConvertTestParameters(testParameters));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "GetTestParameters(EXCEPTION)");
                return new GetTestParametersResponse();
            }
        }

        public IGetTestsParametersResponse GetTestsParameters()
        {
            try
            {
                IEnumerable<ITestParameters> testsParameters = _testParametersRepository.GetTestsParameters();
                return new GetTestsParametersResponse(testsParameters.Select(p=> _converter.ConvertTestParameters(p)));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "GetTestsParameters(EXCEPTION)");
                return new GetTestsParametersResponse();
            }
        }
    }
}
