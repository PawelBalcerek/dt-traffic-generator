using System.Collections.Generic;
using System.Linq;
using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.TestParametersInfrastructure.Abstract;

namespace TestLibrary.Infrastructure.TestParametersInfrastructure.Concrete
{ 
    public class GetTestsParametersResponse : IGetTestsParametersResponse
    {
        public GetTestsParametersResponse()
        {
            ResponseResult = ResponseResultEnum.Exception;
        }

        public GetTestsParametersResponse(IEnumerable<TestParameters> testsParameters)
        {
            IEnumerable<TestParameters> localTestParameters = testsParameters.ToList();
            if (localTestParameters.ToList().Count == 0)
            {
                ResponseResult = ResponseResultEnum.NotFound;
            }
            else
            {
                TestsParameters = localTestParameters;
                ResponseResult = ResponseResultEnum.Success;
            }
        }
        public IEnumerable<TestParameters> TestsParameters { get; }
        public ResponseResultEnum ResponseResult { get; }
    }
}
