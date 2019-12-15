using System.Collections.Generic;
using System.Linq;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;

namespace TestLibrary.Infrastructure.ReportInfrastructure.Concrete
{
    public class GetUsersEndpointExecutionTimesResponse : IGetUsersEndpointExecutionTimesResponse
    {
        public GetUsersEndpointExecutionTimesResponse()
        {
            ResponseResult = ResponseResultEnum.Exception;
        }

        public GetUsersEndpointExecutionTimesResponse(IEnumerable<UserEndpointExecutionTimes> userEndpointExecuteTimes)
        {
            IEnumerable<UserEndpointExecutionTimes> localResponse = userEndpointExecuteTimes.ToList();
            if (localResponse.ToList().Count == 0)
            {
                ResponseResult = ResponseResultEnum.NotFound;
            }
            else
            {
                UserEndpointExecuteTimes = localResponse;
                ResponseResult = ResponseResultEnum.Success;
            }
        }
        public IEnumerable<UserEndpointExecutionTimes> UserEndpointExecuteTimes { get; }
        public ResponseResultEnum ResponseResult { get; }
    }
}
