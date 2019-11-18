using System;
using Microsoft.AspNetCore.Mvc;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Repositories.Abstract;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndpointsController : ControllerBase
    {
        private readonly IEndpointRepository _endpointRepository;

        public EndpointsController(IEndpointRepository endpointRepository)
        {
            _endpointRepository = endpointRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<IEndpoint> Get(int id)
        {
            try
            {
                //Tests
                var a = _endpointRepository.GetEndpoint(1);
                var b = _endpointRepository.AddEndpoint("endopint", "metoda http");
                var c = _endpointRepository.GetEndpoint(1);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
