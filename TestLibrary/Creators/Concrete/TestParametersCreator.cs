using System;
using Serilog;
using TestLibrary.BusinessObject;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Creators.Abstract;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.ObjectsConverter.Abstract;
using TestLibrary.Infrastructure.TestParametersInfrastructure.Abstract;
using TestLibrary.Infrastructure.TestParametersInfrastructure.Concrete;
using TestLibrary.Repositories.Abstract;

namespace TestLibrary.Creators.Concrete
{
    public class TestParametersCreator : ITestParametersCreator
    {
        private readonly ITestParametersRepository _testParametersRepository;
        private readonly IDataToBusinessObjectsConverter _converter;

        public TestParametersCreator(ITestParametersRepository testParametersRepository, IDataToBusinessObjectsConverter converter)
        {
            _testParametersRepository = testParametersRepository;
            _converter = converter;
        }

        public IAddTestParametersResponse AddTestParameters(TestParameters testParameters)
        {
            try
            {
                ITestParameters addedTestParameters = _testParametersRepository.AddTestParameters(testParameters);
                return new AddTestParametersResponse(_converter.ConvertTestParameters(addedTestParameters));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "AddTestParameters(EXCEPTION)");
                return new AddTestParametersResponse();
            }

        }
    }
}
