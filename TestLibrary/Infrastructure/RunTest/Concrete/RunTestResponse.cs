using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.RunTest.Abstract;

namespace TestLibrary.Infrastructure.RunTest.Concrete
{

    public class RunTestResponse : IRunTestResponse
    {
        public RunTestResponse(ResponseResultEnum responseResult)
        {
            ResponseResult = ResponseResultEnum.Exception;
        }

        public ResponseResultEnum ResponseResult { get; }
    }
}
