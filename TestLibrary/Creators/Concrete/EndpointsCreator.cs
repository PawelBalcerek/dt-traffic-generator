using System;
using Serilog;
using TestLibrary.BusinessObject;
using TestLibrary.Creators.Abstract;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.EndpointInfrastructure.Abstract;
using TestLibrary.Infrastructure.EndpointInfrastructure.Concrete;
using TestLibrary.Repositories.Abstract;

namespace TestLibrary.Creators.Concrete
{
    public class EndpointsCreator : IEndpointsCreator
    {
        private readonly IEndpointRepository _endpointRepository;

        public EndpointsCreator(IEndpointRepository endpointRepository)
        {
            _endpointRepository = endpointRepository;
        }

        public IAddEndpointResponse AddEndpoint(Endpoint endpoint)
        {
            try
            {
                _endpointRepository.AddEndpoint(endpoint);
                return new AddEndpointResponse(ResponseResultEnum.Success);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "AddEndpoint(EXCEPTION)");
                return new AddEndpointResponse(ResponseResultEnum.Exception);
            }
        }
    }
}
