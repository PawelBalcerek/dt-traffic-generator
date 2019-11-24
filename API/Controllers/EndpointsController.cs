using System;
using API.Models.Endpoint;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TestLibrary.BusinessObject;
using TestLibrary.Creators.Abstract;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.EndpointInfrastructure.Abstract;
using TestLibrary.Providers.Abstract;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndpointsController : ControllerBase
    {
        private readonly IEndpointsProvider _endpointsProvider;
        private readonly IEndpointsCreator _endpointsCreator;

        public EndpointsController(IEndpointsProvider endpointsProvider, IEndpointsCreator endpointsCreator)
        {
            _endpointsProvider = endpointsProvider;
            _endpointsCreator = endpointsCreator;
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            try
            {
                IGetEndpointResponse getEndpointResponse = _endpointsProvider.GetEndpoint(id);
                return PrepareHttpResponse(getEndpointResponse);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "EndpointsController(Get)(EXCEPTION)");
                return StatusCode(500);
            }
        }

        private ActionResult PrepareHttpResponse(IGetEndpointResponse getEndpointResponse)
        {
            switch (getEndpointResponse.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    return Ok(new GetEndpointResponseModel(getEndpointResponse.Endpoint));
                case ResponseResultEnum.NotFound:
                    return StatusCode(404);
                default:
                    return StatusCode(500);
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("Add")]
        public ActionResult AddEndpoint([FromBody] AddEndpointRequestModel request)
        {
            try
            {
                Endpoint endpoint = new Endpoint(request.EndpointName, request.HttpMethod);
                IAddEndpointResponse addEndpointResponse = _endpointsCreator.AddEndpoint(endpoint);
                return PrepareHttpResponse(addEndpointResponse);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "EndpointsController(Add)(EXCEPTION)");
                return StatusCode(500);
            }
        }

        private ActionResult PrepareHttpResponse(IAddEndpointResponse addEndpointResponse)
        {
            switch (addEndpointResponse.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    return Ok();
                default:
                    return StatusCode(500);
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                IGetEndpointsResponse getEndpointsResponse = _endpointsProvider.GetEndpoints();
                return PrepareHttpResponse(getEndpointsResponse);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "EndpointsController(GetMany)(EXCEPTION)");
                return StatusCode(500);
            }
        }

        private ActionResult PrepareHttpResponse(IGetEndpointsResponse getEndpointsResponse)
        {
            switch (getEndpointsResponse.ResponseResult)
            {
                case ResponseResultEnum.Success:
                    return Ok(new GetEndpointsResponseModel(getEndpointsResponse.Endpoints));
                case ResponseResultEnum.NotFound:
                    return StatusCode(404);
                default:
                    return StatusCode(500);
            }
        }
    }
}
