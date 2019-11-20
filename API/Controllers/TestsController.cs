using System;
using API.Models.Test;
using Microsoft.AspNetCore.Mvc;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.RunTest.Abstract;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestRunner _testRunner;
        public TestsController(ITestRunner testRunner)
        {
            _testRunner = testRunner;
        }

        [HttpPost("RunTest")]
        public ActionResult RunTest2([FromBody] RunTestRequestModel request)
        {
            try
            {
                IRunTestResponse runTestResponse = _testRunner.RunTest(request.TestParametersId);
                return PrepareHttpResponse(runTestResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        private ActionResult PrepareHttpResponse(IRunTestResponse runTestResponse)
        {
            switch (runTestResponse.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    return Ok();
                case ResponseResultEnum.NotFound:
                    return StatusCode(404);
                default:
                    return StatusCode(500);
            }
        }
    }
}
