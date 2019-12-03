using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using API.Models.TestParameters;
using TestLibrary.BusinessObject;
using TestLibrary.Creators.Abstract;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.TestParametersInfrastructure.Abstract;
using TestLibrary.Providers.Abstract;

namespace API.Controllers
{
    [Route("testapi/[controller]")]
    [ApiController]
    public class TestsParametersController : ControllerBase
    {
        private readonly ITestParametersProvider _testParametersProvider;
        private readonly ITestParametersCreator _testParametersCreator;
        public TestsParametersController(ITestParametersProvider testParametersProvider, ITestParametersCreator testParametersCreator)
        {
            _testParametersProvider = testParametersProvider;
            _testParametersCreator = testParametersCreator;
        }

        /// <summary>
        /// Method to get test parameters by id
        /// </summary>
        [ProducesResponseType(200, Type = typeof(GetTestParametersResponseModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
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
                    return Ok(new GetTestParametersResponseModel(testParametersResponse.TestParameters));
                case ResponseResultEnum.NotFound:
                    return StatusCode(404);
                default:
                    return StatusCode(500);
            }
        }

        /// <summary>
        /// Method to get all tests parameters
        /// </summary>
        [ProducesResponseType(200, Type = typeof(GetTestsParametersResponseModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                IGetTestsParametersResponse testsParametersResponse = _testParametersProvider.GetTestsParameters();
                return PrepareHttpResponse(testsParametersResponse);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "TestsParametersController(GetMany)(EXCEPTION)");
                return StatusCode(500);
            }
        }

        private ActionResult PrepareHttpResponse(IGetTestsParametersResponse testsParametersResponse)
        {
            switch (testsParametersResponse.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    return Ok(new GetTestsParametersResponseModel(testsParametersResponse.TestsParameters));
                case ResponseResultEnum.NotFound:
                    return StatusCode(404);
                default:
                    return StatusCode(500);
            }
        }


        /// <summary>
        /// Method to add test parameters
        /// </summary>
        [ProducesResponseType(200, Type = typeof(AddTestParametersResponseModel))]
        [ProducesResponseType(500)]
        [HttpPost("Add")]
        public ActionResult AddTestParameters([FromBody] AddTestParametersRequestModel request)
        {
            try
            {
                TestParameters testParameters = new TestParameters(request.NumberOfUsers, request.TestName, request.NumberOfRequests, request.MinBuyPrice, request.MaxBuyPrice, request.MinSellPrice, request.MaxSellPrice);
                IAddTestParametersResponse addTestParametersResponse = _testParametersCreator.AddTestParameters(testParameters);
                return PrepareHttpResponse(addTestParametersResponse);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "TestsParametersController(Add)(EXCEPTION)");
                return StatusCode(500);
            }
        }

        private ActionResult PrepareHttpResponse(IAddTestParametersResponse addTestParametersResponse)
        {
            switch (addTestParametersResponse.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    return Ok(new AddTestParametersResponseModel(addTestParametersResponse.AddedTestParameters));
                default:
                    return StatusCode(500);
            }
        }
    }
}
