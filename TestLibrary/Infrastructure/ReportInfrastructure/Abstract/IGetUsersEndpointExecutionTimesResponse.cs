using System.Collections.Generic;
using TestLibrary.Infrastructure.Common.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Concrete;

namespace TestLibrary.Infrastructure.ReportInfrastructure.Abstract
{
    public interface IGetUsersEndpointExecutionTimesResponse : IResponseResult
    {
        IEnumerable<UserEndpointExecutionTimes> UserEndpointExecuteTimes { get; }
    }
}
