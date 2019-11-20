using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.TestParameters.Abstract;

namespace TestLibrary.Infrastructure.TestParameters.Concrete
{
    public class GetTestParametersResponse : IGetTestParametersResponse
    {
        public GetTestParametersResponse()
        {
            ResponseResult = ResponseResultEnum.Exception;
        }

        public GetTestParametersResponse(BusinessObject.TestParameters testParameters)
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
        public BusinessObject.TestParameters TestParameters { get; }
        public ResponseResultEnum ResponseResult { get; }
    }
}
