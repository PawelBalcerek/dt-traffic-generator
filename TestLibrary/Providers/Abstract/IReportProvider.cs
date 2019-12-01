using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;

namespace TestLibrary.Providers.Abstract
{
    public interface IReportProvider
    {
        IGetAverageEndpointsExecutionTimesResponse GetAverageEndpointsExecutionTimes(long testParametersId);
    }
}
