using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.TestInfrastructure.Abstract;

namespace TestLibrary.Infrastructure.TestInfrastructure.Concrete
{
    public class AddTestsResponse : IAddTestsResponse
    {
        public AddTestsResponse(ResponseResultEnum responseResult)
        {
            ResponseResult = responseResult;
        }

        public ResponseResultEnum ResponseResult { get; }
    }
}
