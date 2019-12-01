using System.Collections.Generic;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;

namespace TestLibrary.Repositories.Abstract
{
    public interface IReportRepository
    {
        IEnumerable<IAverageEndpointsExecutionTimes> GetAverageEndpointsExecutionTimes(long testParametersId);
    }
}
