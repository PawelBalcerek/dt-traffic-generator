using System.Collections.Generic;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Concrete;

namespace TestLibrary.Infrastructure.FileGenerating.Abstract
{
    public interface IFileGenerator
    {
        byte[] GenerateUserEndpointExecutionTimesZipFile(IEnumerable<UserEndpointExecutionTimes> data);
        byte[] GenerateCsvFile(IEnumerable<IExecutionTimesWithStamp> data);
        byte[] GenerateCsvFile(IEnumerable<AverageEndpointsExecutionTimes> data);
    }
}
