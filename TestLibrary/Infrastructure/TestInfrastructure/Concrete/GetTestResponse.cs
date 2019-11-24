using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.TestInfrastructure.Abstract;

namespace TestLibrary.Infrastructure.TestInfrastructure.Concrete
{
    public class GetTestResponse : IGetTestResponse
    {
        public GetTestResponse()
        {
            ResponseResult = ResponseResultEnum.Exception;
        }

        public GetTestResponse(Test test)
        {
            if (test == null)
            {
                ResponseResult = ResponseResultEnum.NotFound;
            }
            else
            {
                Test = test;
                ResponseResult = ResponseResultEnum.Success;
            }
        }
        public Test Test { get; }
        public ResponseResultEnum ResponseResult { get; }
    }
}
