using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;

namespace TestLibrary.Infrastructure.ReportInfrastructure.Concrete
{
    public class AverageEndpointsExecutionTimes : IAverageEndpointsExecutionTimes
    {
        public AverageEndpointsExecutionTimes(IEndpoint endpoint, IExecutionTimes averageExecutionTimes)
        {
            Endpoint = endpoint;
            AverageExecutionTimes = averageExecutionTimes;
        }

        public IEndpoint Endpoint { get; }
        public IExecutionTimes AverageExecutionTimes { get; }
    }
}
