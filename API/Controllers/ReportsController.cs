using System;
using System.Linq;
using System.Text;
using API.Models.Report;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Configuration;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.CsvConverting.Abstract;
using TestLibrary.Infrastructure.FileGenerating.Abstract;
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
        private readonly IFileGenerator _fileGenerator;

        public ReportsController(IReportProvider reportProvider, ICsvConverter csvConverter, IFileGenerator fileGenerator)
        {
            _reportProvider = reportProvider;
            _csvConverter = csvConverter;
            _fileGenerator = fileGenerator;
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
                return PrepareCsvFileHttpResponse(getAverageEndpointsResponse, testParametersId);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "ReportsController(GetAverageEndpointsExecutionTimesCsv)(EXCEPTION)");
                return StatusCode(500);
            }
        }

        private ActionResult PrepareCsvFileHttpResponse(IGetAverageEndpointsExecutionTimesResponse response, long testParametersId)
        {
            switch (response.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    byte[] csvFile = _fileGenerator.GenerateCsvFile(response.AverageEndpointExecutionsTimes);
                    string fileName = $"{Config.AverageEndpointsExecutionTimesCsvFileName}_testId-{testParametersId}{Config.CsvExtension}";
                    return File(csvFile, Config.CsvContentType, fileName);
                case ResponseResultEnum.NotFound:
                    return StatusCode(404);
                default:
                    return StatusCode(500);
            }
        }


        /// <summary>
        /// Method to get the list of all users (for all endpoints) with average execution times for specific test.
        /// </summary>
        [ProducesResponseType(200, Type = typeof(GetUsersEnpointExecutionTimesResponseModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("GetUsersEndpointsExecutionTimes")]
        public ActionResult GetUsersEndpointsExecutionTimes(long testParametersId)
        {
            try
            {
                IGetUsersEndpointExecutionTimesResponse response = _reportProvider.GetUsersEndpointsExecutionTimes(testParametersId);
                return PrepareHttpResponse(response);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "ReportsController(GetUsersEndpointsExecutionTimes)(EXCEPTION)");
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


        /// <summary>
        /// Method to get zip file contains csv file of the list of all users (for all endpoints) with average execution times for specific test.
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("GetUsersEndpointsExecutionTimesCsv")]
        public ActionResult GetUsersEndpointsExecutionTimesCsv(long testParametersId)
        {
            try
            {
                IGetUsersEndpointExecutionTimesResponse response = _reportProvider.GetUsersEndpointsExecutionTimes(testParametersId);
                return PrepareCsvFileHttpResponse(response, testParametersId);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "ReportsController(GetUsersEndpointsExecutionTimesCsv)(EXCEPTION)");
                return StatusCode(500);
            }
        }

        private ActionResult PrepareCsvFileHttpResponse(IGetUsersEndpointExecutionTimesResponse response, long testParametersId)
        {
            switch (response.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    byte[] zipFile = _fileGenerator.GenerateUserEndpointExecutionTimesZipFile(response.UserEndpointExecuteTimes);
                    string fileName = $"{Config.UserEndpointExecutionTimesCsvZipFileName}_testId-{testParametersId}{Config.ZipExtension}";
                    return File(zipFile, Config.ZipContentType, fileName);
                case ResponseResultEnum.NotFound:
                    return StatusCode(404);
                default:
                    return StatusCode(500);
            }
        }
    }
}
