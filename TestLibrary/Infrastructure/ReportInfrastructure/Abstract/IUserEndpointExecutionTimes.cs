using System.Collections.Generic;
using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.Infrastructure.ReportInfrastructure.Abstract
{
    public interface IUserEndpointExecutionTimes
    {
        long UserId { get; }
        IEndpoint Endpoint { get; }
        IEnumerable<IExecutionTimesWithStamp> ExecutionTimesWithStamps { get; }
    }
}
