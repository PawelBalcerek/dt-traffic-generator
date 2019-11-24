using System.Collections.Generic;
using TestLibrary.BusinessObject.Abstract;

namespace API.Models.Endpoint
{
    public class GetEndpointsResponseModel
    {
        public GetEndpointsResponseModel(IEnumerable<IEndpoint> endpoints)
        {
            Endpoints = endpoints;
        }

        public IEnumerable<IEndpoint> Endpoints { get; }
    }
}
