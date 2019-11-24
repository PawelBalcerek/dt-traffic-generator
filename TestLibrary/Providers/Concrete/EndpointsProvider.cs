using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Infrastructure.EndpointInfrastructure.Abstract;
using TestLibrary.Infrastructure.EndpointInfrastructure.Concrete;
using TestLibrary.Infrastructure.ObjectsConverter.Abstract;
using TestLibrary.Providers.Abstract;
using TestLibrary.Repositories.Abstract;

namespace TestLibrary.Providers.Concrete
{
    public class EndpointsProvider : IEndpointsProvider
    {
        private readonly IEndpointRepository _endpointRepository;
        private readonly IDataToBusinessObjectsConverter _converter;
        public EndpointsProvider(IDataToBusinessObjectsConverter converter, IEndpointRepository endpointRepository)
        {
            _converter = converter;
            _endpointRepository = endpointRepository;
        }

        public IGetEndpointResponse GetEndpoint(long endpointId)
        {
            try
            {
                IEndpoint endpoint = _endpointRepository.GetEndpoint(endpointId);
                return new GetEndpointResponse(_converter.ConvertEndpoint(endpoint));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "GetEndpointById(EXCEPTION)");
                return new GetEndpointResponse();
            }
        }

        public IGetEndpointsResponse GetEndpoints()
        {
            try
            {
                IEnumerable<IEndpoint> endpoints = _endpointRepository.GetEndpoints();
                return new GetEndpointsResponse(endpoints.Select(p => _converter.ConvertEndpoint(p)));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "GetEndpoints(EXCEPTION)");
                return new GetEndpointsResponse();
            }
        }
    }


}
