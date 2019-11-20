using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.TestParametersInfrastructure.Abstract;
using TestLibrary.Providers.Abstract;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsParametersController : ControllerBase
    {
        private readonly ITestParametersProvider _testParametersProvider;
        public TestsParametersController(ITestParametersProvider testParametersProvider)
        {
            _testParametersProvider = testParametersProvider;
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            try
            {
                IGetTestParametersResponse testParametersResponse = _testParametersProvider.GetTestParameters(id);
                return PrepareHttpResponse(testParametersResponse);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "TestsParametersController(Get)(EXCEPTION)");
                return StatusCode(500);
            }
        }

        private ActionResult PrepareHttpResponse(IGetTestParametersResponse testParametersResponse)
        {
            switch (testParametersResponse.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    return Ok(testParametersResponse.TestParameters);
                case ResponseResultEnum.NotFound:
                    return StatusCode(404);
                default:
                    return StatusCode(500);
            }
        }
    }
}
