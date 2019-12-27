using System.Collections.Generic;
using System.Linq;
using ServiceStack;
using TestLibrary.Infrastructure.CsvConverting.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Concrete;
using TestLibrary.Infrastructure.ReportInfrastructure.Concrete.Model;

namespace TestLibrary.Infrastructure.CsvConverting.Concrete
{
    public class CsvConverter : ICsvConverter
    {
        public string ConvertToCsv(IEnumerable<AverageEndpointsExecutionTimes> data)
        {
            return ConvertToCsvModel(data).ToCsv();
        }

        private IEnumerable<EndpointExecutionTimesModel> ConvertToCsvModel(IEnumerable<AverageEndpointsExecutionTimes> data)
        {
            return data.Select(item => new EndpointExecutionTimesModel(
                item.Endpoint.EndpointId, 
                item.Endpoint.EndpointName, 
                item.Endpoint.HttpMethod, 
                item.AverageExecutionTimes.DatabaseTestTime, 
                item.AverageExecutionTimes.ApplicationTestTime, 
                item.AverageExecutionTimes.ApiTestTime));
        }

        public string ConvertToCsv(IEnumerable<IExecutionTimesWithStamp> data)
        {
            return data.ToCsv();
        }
    }
}
