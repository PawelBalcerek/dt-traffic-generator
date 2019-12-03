using System.Collections.Generic;
using TestLibrary.Infrastructure.Common.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Concrete;

namespace TestLibrary.Infrastructure.ReportInfrastructure.Abstract
{
    public interface IGetAverageEndpointsExecutionTimesResponse : IResponseResult
    {
        IEnumerable<AverageEndpointsExecutionTimes> AverageEndpointExecutionsTimes { get; }
    }
}
