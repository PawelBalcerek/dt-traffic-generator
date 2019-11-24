using System.Collections.Generic;
using System.Linq;
using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.EndpointInfrastructure.Abstract;

namespace TestLibrary.Infrastructure.EndpointInfrastructure.Concrete
{
    public class GetEndpointsResponse : IGetEndpointsResponse
    {
        public GetEndpointsResponse()
        {
            ResponseResult = ResponseResultEnum.Exception;
        }

        public GetEndpointsResponse(IEnumerable<Endpoint> endpoints)
        {
            IEnumerable<Endpoint> localEndpoints = endpoints.ToList();
            if (localEndpoints.ToList().Count == 0)
            {
                ResponseResult = ResponseResultEnum.NotFound;
            }
            else
            {
                Endpoints = localEndpoints;
                ResponseResult = ResponseResultEnum.Success;
            }
        }
        public IEnumerable<Endpoint> Endpoints { get; }
        public ResponseResultEnum ResponseResult { get; }
    }
}
