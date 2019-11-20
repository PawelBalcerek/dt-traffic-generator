using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.TestParameters.Abstract;
using TestLibrary.Providers.Abstract;
using TestLibrary.Repositories.Abstract;

namespace API.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class TestsParametersController : ControllerBase
    {
        private readonly ITestParametersRepository _testParametersRepository;
        private readonly ITestParametersProvider _testParametersProvider;
        public TestsParametersController(ITestParametersRepository testParametersRepository, ITestParametersProvider testParametersProvider)
        {
            _testParametersRepository = testParametersRepository;
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
                Log.Fatal(ex, "TestsParametersController");
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
