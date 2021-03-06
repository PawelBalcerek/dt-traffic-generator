﻿using System;
using System.Collections.Generic;
using API.Models.Test;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TestLibrary.BusinessObject;
using TestLibrary.Creators.Abstract;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.RunTest.Abstract;
using TestLibrary.Infrastructure.TestInfrastructure.Abstract;
using TestLibrary.Providers.Abstract;

namespace API.Controllers
{
    [Route("testapi/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestRunner _testRunner;
        private readonly ITestsCreator _testsCreator;
        private readonly ITestsProvider _testsProvider;
        public TestsController(ITestRunner testRunner, ITestsCreator testsCreator, ITestsProvider testsProvider)
        {
            _testRunner = testRunner;
            _testsCreator = testsCreator;
            _testsProvider = testsProvider;
        }

        /// <summary>
        /// Method to run test by testParameters id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPost("RunTest")]
        public ActionResult RunTest([FromBody] RunTestRequestModel request)
        {
            try
            {
                IRunTestResponse runTestResponse = _testRunner.RunTest(request.TestParametersId);
                return PrepareHttpResponse(runTestResponse);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "TestsController(RunTest)(EXCEPTION)");
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

        /// <summary>
        /// Method to add test
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("Add")]
        public ActionResult AddTest([FromBody] AddTestRequestModel request)
        {
            try
            {
                Test test = new Test(request.TestParametersId, request.UserId, request.EndpointId, request.DatabaseTestTime, request.ApplicationTestTime, request.ApiTestTime);
                IAddTestsResponse addTestsResponse = _testsCreator.AddTests(new List<Test> { test });
                return PrepareHttpResponse(addTestsResponse);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "TestsController(Add)(EXCEPTION)");
                return StatusCode(500);
            }
        }

        private ActionResult PrepareHttpResponse(IAddTestsResponse addTestsResponse)
        {
            switch (addTestsResponse.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    return Ok();
                default:
                    return StatusCode(500);
            }
        }


        /// <summary>
        /// Method to get test by id
        /// </summary>
        [ProducesResponseType(200, Type = typeof(GetTestResponseModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            try
            {
                IGetTestResponse getTestResponse = _testsProvider.GetTest(id);
                return PrepareHttpResponse(getTestResponse);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "TestsController(Get)(EXCEPTION)");
                return StatusCode(500);
            }
        }

        private ActionResult PrepareHttpResponse(IGetTestResponse getTestResponse)
        {
            switch (getTestResponse.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    return Ok(new GetTestResponseModel(getTestResponse.Test));
                case ResponseResultEnum.NotFound:
                    return StatusCode(404);
                default:
                    return StatusCode(500);
            }
        }

        /// <summary>
        /// Method to get all tests.
        /// </summary>
        [ProducesResponseType(200, Type = typeof(GetTestsResponseModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                IGetTestsResponse testsResponse = _testsProvider.GetTests();
                return PrepareHttpResponse(testsResponse);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "TestsController(GetMany)(EXCEPTION)");
                return StatusCode(500);
            }
        }

        private ActionResult PrepareHttpResponse(IGetTestsResponse testsResponse)
        {
            switch (testsResponse.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    return Ok(new GetTestsResponseModel(testsResponse.Tests));
                case ResponseResultEnum.NotFound:
                    return StatusCode(404);
                default:
                    return StatusCode(500);
            }
        }
    }
}
