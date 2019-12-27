using System.Collections.Generic;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;

namespace TestLibrary.Repositories.Abstract
{
    public interface IReportRepository
    {
        IEnumerable<IAverageEndpointsExecutionTimes> GetAverageEndpointsExecutionTimes(long testParametersId);
        IEnumerable<IUserEndpointExecutionTimes> GetUsersEndpointsExecutionTimes(long testParametersId);
        IEnumerable<IUserEndpointExecutionTimes> GetUsersEndpointExecutionTimes(long testParametersId, long endpointId);
    }
}
