using System;
using System.Text;
using API.Models.Report;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TestLibrary.Configuration;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.CsvConverting.Abstract;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;
using TestLibrary.Providers.Abstract;

namespace API.Controllers
{
    [Route("testapi/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportProvider _reportProvider;
        private readonly ICsvConverter _csvConverter;

        public ReportsController(IReportProvider reportProvider, ICsvConverter csvConverter)
        {
            _reportProvider = reportProvider;
            _csvConverter = csvConverter;
        }


        /// <summary>
        /// Method to get the list of all endpoints (for specific test) with average execution times.
        /// </summary>
        [ProducesResponseType(200, Type = typeof(GetAverageEndpointsExecutionTimesResponseModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("GetAverageEndpointsExecutionTimes")]
        public ActionResult GetAverageEndpointsExecutionTimes(long testParametersId)
        {
            try
            {
                IGetAverageEndpointsExecutionTimesResponse getAverageEndpointsResponse = _reportProvider.GetAverageEndpointsExecutionTimes(testParametersId);
                return PrepareHttpResponse(getAverageEndpointsResponse);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "ReportsController(GetAverageEndpointsExecutionTimes)(EXCEPTION)");
                return StatusCode(500);
            }
        }

        private ActionResult PrepareHttpResponse(IGetAverageEndpointsExecutionTimesResponse getAverageEndpointsResponse)
        {
            switch (getAverageEndpointsResponse.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    return Ok(new GetAverageEndpointsExecutionTimesResponseModel(getAverageEndpointsResponse.AverageEndpointExecutionsTimes));
                case ResponseResultEnum.NotFound:
                    return StatusCode(404);
                default:
                    return StatusCode(500);
            }
        }


        /// <summary>
        /// Method to get the csv file representation of the list of all endpoints (for specific test) with average execution times.
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("GetAverageEndpointsExecutionTimesCsv")]
        public ActionResult GetAverageEndpointsExecutionTimesCsv(long testParametersId)
        {
            try
            {
                IGetAverageEndpointsExecutionTimesResponse getAverageEndpointsResponse = _reportProvider.GetAverageEndpointsExecutionTimes(testParametersId);
                return PrepareCsvFileHttpResponse(getAverageEndpointsResponse);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "ReportsController(GetAverageEndpointsExecutionTimesCsv)(EXCEPTION)");
                return StatusCode(500);
            }
        }

        private ActionResult PrepareCsvFileHttpResponse(IGetAverageEndpointsExecutionTimesResponse response)
        {
            switch (response.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    string csvResponse = _csvConverter.ConvertToCsv(response.AverageEndpointExecutionsTimes);
                    byte[] csvBytesResponse = Encoding.ASCII.GetBytes(csvResponse);
                    return File(csvBytesResponse, Config.CsvContentType, Config.AverageEndpointsExecutionTimesCsvFileName);
                case ResponseResultEnum.NotFound:
                    return StatusCode(404);
                default:
                    return StatusCode(500);
            }
        }


        /// <summary>
        /// Method to get the list of all users with average execution times for specific test and endpoint.
        /// </summary>
        [ProducesResponseType(200, Type = typeof(GetUsersEnpointExecutionTimesResponseModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("GetUsersEndpointExecutionTimes")]
        public ActionResult GetUsersEndpointExecutionTimes(long testParametersId, long endpointId)
        {
            try
            {
                IGetUsersEndpointExecutionTimesResponse response = _reportProvider.GetUsersEndpointExecutionTimes(testParametersId, endpointId);
                return PrepareHttpResponse(response);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "ReportsController(GetUsersEndpointExecutionTimes)(EXCEPTION)");
                return StatusCode(500);
            }
        }

        private ActionResult PrepareHttpResponse(IGetUsersEndpointExecutionTimesResponse response)
        {
            switch (response.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    return Ok(new GetUsersEnpointExecutionTimesResponseModel(response.UserEndpointExecuteTimes));
                case ResponseResultEnum.NotFound:
                    return StatusCode(404);
                default:
                    return StatusCode(500);
            }
        }
    }
}
