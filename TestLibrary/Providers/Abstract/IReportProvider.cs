using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;

namespace TestLibrary.Providers.Abstract
{
    public interface IReportProvider
    {
        IGetAverageEndpointsExecutionTimesResponse GetAverageEndpointsExecutionTimes(long testParametersId);
        IGetUsersEndpointExecutionTimesResponse GetUsersEndpointsExecutionTimes(long testParametersId);
        IGetUsersEndpointExecutionTimesResponse GetUsersEndpointExecutionTimes(long testParametersId, long endpointId);
    }
}
