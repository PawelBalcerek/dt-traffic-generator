using System.Collections.Generic;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;

namespace API.Models.Report
{
    public class GetAverageEndpointsExecutionTimesResponseModel
    {
        public GetAverageEndpointsExecutionTimesResponseModel(IEnumerable<IAverageEndpointsExecutionTimes> averageEndpointsExecutionTimes)
        {
            AverageEndpointsExecutionTimes = averageEndpointsExecutionTimes;
        }

        public IEnumerable<IAverageEndpointsExecutionTimes> AverageEndpointsExecutionTimes;
    }
}
