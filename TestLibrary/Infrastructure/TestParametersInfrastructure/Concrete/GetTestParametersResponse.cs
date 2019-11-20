using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.TestParametersInfrastructure.Abstract;

namespace TestLibrary.Infrastructure.TestParametersInfrastructure.Concrete
{
    public class GetTestParametersResponse : IGetTestParametersResponse
    {
        public GetTestParametersResponse()
        {
            ResponseResult = ResponseResultEnum.Exception;
        }

        public GetTestParametersResponse(TestParameters testParameters)
        {
            if (testParameters == null)
            {
                ResponseResult = ResponseResultEnum.NotFound;
            }
            else
            {
                TestParameters = testParameters;
                ResponseResult = ResponseResultEnum.Success;
            }
        }
        public TestParameters TestParameters { get; }
        public ResponseResultEnum ResponseResult { get; }
    }
}
