using System.Collections.Generic;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;

namespace TestLibrary.Infrastructure.ReportInfrastructure.Concrete
{
    public class UserEndpointExecutionTimes : IUserEndpointExecutionTimes
    {
        public UserEndpointExecutionTimes(long userId, IEndpoint endpoint, IEnumerable<IExecutionTimesWithStamp> executionTimesWithStamps)
        {
            UserId = userId;
            Endpoint = endpoint;
            ExecutionTimesWithStamps = executionTimesWithStamps;
        }

        public long UserId { get; }
        public IEndpoint Endpoint { get; }
        public IEnumerable<IExecutionTimesWithStamp> ExecutionTimesWithStamps { get; }
    }
}
