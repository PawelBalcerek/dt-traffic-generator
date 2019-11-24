using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.TestParametersInfrastructure.Abstract;

namespace TestLibrary.Infrastructure.TestParametersInfrastructure.Concrete
{
    public class AddTestParametersResponse : IAddTestParametersResponse
    {
        public AddTestParametersResponse()
        {
            ResponseResult = ResponseResultEnum.Exception;
        }

        public AddTestParametersResponse(TestParameters addedTestParameters)
        {
            if (addedTestParameters == null)
            {
                ResponseResult = ResponseResultEnum.NotFound;
            }
            else
            {
                AddedTestParameters = addedTestParameters;
                ResponseResult = ResponseResultEnum.Success;
            }
        }
        public TestParameters AddedTestParameters { get; }
        public ResponseResultEnum ResponseResult { get; }
    }
}
