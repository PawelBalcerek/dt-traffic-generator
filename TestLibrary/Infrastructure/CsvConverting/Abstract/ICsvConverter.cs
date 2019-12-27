using System.Collections.Generic;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Concrete;

namespace TestLibrary.Infrastructure.CsvConverting.Abstract
{
    public interface ICsvConverter
    {
        string ConvertToCsv(IEnumerable<AverageEndpointsExecutionTimes> data);
        string ConvertToCsv(IEnumerable<IExecutionTimesWithStamp> data);
    }
}
