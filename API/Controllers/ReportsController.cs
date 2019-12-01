using System;
using API.Models.Report;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.ReportInfrastructure.Abstract;
using TestLibrary.Providers.Abstract;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportProvider _reportProvider;

        public ReportsController(IReportProvider reportProvider)
        {
            _reportProvider = reportProvider;
        }


        /// <summary>
        /// Gets the list of all endpoints (for specific test) with average execution times.
        /// </summary>
        [ProducesResponseType(200)]
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
    }
}
