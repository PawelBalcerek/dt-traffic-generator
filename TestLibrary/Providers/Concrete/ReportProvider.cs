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

        public IGetUsersEndpointExecutionTimesResponse GetUsersEndpointsExecutionTimes(long testParametersId)
        {
            try
            {
                IEnumerable<IUserEndpointExecutionTimes> response = _reportRepository.GetUsersEndpointsExecutionTimes(testParametersId);
                return new GetUsersEndpointExecutionTimesResponse(response.Select(p => _converter.ConvertUserEndpointExecutionTimes(p)));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "GetUsersEndpointsExecutionTimes(EXCEPTION)");
                return new GetUsersEndpointExecutionTimesResponse();
            }
        }

        public IGetUsersEndpointExecutionTimesResponse GetUsersEndpointExecutionTimes(long testParametersId, long endpointId)
        {
            try
            {
                IEnumerable<IUserEndpointExecutionTimes> response = _reportRepository.GetUsersEndpointExecutionTimes(testParametersId, endpointId);
                return new GetUsersEndpointExecutionTimesResponse(response.Select(p => _converter.ConvertUserEndpointExecutionTimes(p)));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "GetUsersEndpointExecutionTimes(EXCEPTION)");
                return new GetUsersEndpointExecutionTimesResponse();
            }
        }
    }
}
