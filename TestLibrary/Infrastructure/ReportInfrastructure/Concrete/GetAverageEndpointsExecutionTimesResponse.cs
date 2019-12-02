using System.Collections.Generic;
using System.Linq;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;

namespace TestLibrary.Infrastructure.ReportInfrastructure.Concrete
{
    public class GetAverageEndpointsExecutionTimesResponse : IGetAverageEndpointsExecutionTimesResponse
    {
        public GetAverageEndpointsExecutionTimesResponse()
        {
            ResponseResult = ResponseResultEnum.Exception;
        }

        public GetAverageEndpointsExecutionTimesResponse(IEnumerable<AverageEndpointsExecutionTimes> averageEndpointExecutionsTimes)
        {
            IEnumerable<AverageEndpointsExecutionTimes> localResponse = averageEndpointExecutionsTimes.ToList();
            if (localResponse.ToList().Count == 0)
            {
                ResponseResult = ResponseResultEnum.NotFound;
            }
            else
            {
                AverageEndpointExecutionsTimes = localResponse;
                ResponseResult = ResponseResultEnum.Success;
            }
        }
        public IEnumerable<AverageEndpointsExecutionTimes> AverageEndpointExecutionsTimes { get; }
        public ResponseResultEnum ResponseResult { get; }
    }
}
