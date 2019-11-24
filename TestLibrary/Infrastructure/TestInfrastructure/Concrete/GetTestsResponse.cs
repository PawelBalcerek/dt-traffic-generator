using System.Collections.Generic;
using System.Linq;
using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.TestInfrastructure.Abstract;

namespace TestLibrary.Infrastructure.TestInfrastructure.Concrete
{
    public class GetTestsResponse : IGetTestsResponse
    {
        public GetTestsResponse()
        {
            ResponseResult = ResponseResultEnum.Exception;
        }

        public GetTestsResponse(IEnumerable<Test> tests)
        {
            IEnumerable<Test> localTests= tests.ToList();
            if (localTests.ToList().Count == 0)
            {
                ResponseResult = ResponseResultEnum.NotFound;
            }
            else
            {
                Tests = localTests;
                ResponseResult = ResponseResultEnum.Success;
            }
        }
        public IEnumerable<Test> Tests { get; }
        public ResponseResultEnum ResponseResult { get; }
    }
}
