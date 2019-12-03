using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using TestLibrary.Infrastructure.ObjectsConverter.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Concrete;
using TestLibrary.Providers.Abstract;
using TestLibrary.Repositories.Abstract;

namespace TestLibrary.Providers.Concrete
{
    public class ReportProvider : IReportProvider
    {
        private readonly IReportRepository _reportRepository;
        private readonly IDataToBusinessObjectsConverter _converter;

        public ReportProvider(IReportRepository reportRepository, IDataToBusinessObjectsConverter converter)
        {
            _reportRepository = reportRepository;
            _converter = converter;
        }

        public IGetAverageEndpointsExecutionTimesResponse GetAverageEndpointsExecutionTimes(long testParametersId)
        {
            try
            {
                IEnumerable<IAverageEndpointsExecutionTimes> averageEndpointsExecutionTimes = _reportRepository.GetAverageEndpointsExecutionTimes(testParametersId);
                return new GetAverageEndpointsExecutionTimesResponse(averageEndpointsExecutionTimes.Select(p => _converter.ConvertAverageEndpointsExecutionTimes(p)));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "GetAverageEndpointsExecutionTimes(EXCEPTION)");
                return new GetAverageEndpointsExecutionTimesResponse();
            }
        }
    }
}
