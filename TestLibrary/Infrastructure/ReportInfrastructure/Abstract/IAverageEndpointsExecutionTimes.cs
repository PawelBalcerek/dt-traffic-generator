using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.Infrastructure.ReportInfrastructure.Abstract
{
    public interface IAverageEndpointsExecutionTimes
    {
        IEndpoint Endpoint { get; }
        IExecutionTimes AverageExecutionTimes { get; }
    }
}
