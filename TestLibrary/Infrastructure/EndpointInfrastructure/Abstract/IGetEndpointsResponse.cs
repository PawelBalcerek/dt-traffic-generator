using System.Collections.Generic;
using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.Common.Abstract;

namespace TestLibrary.Infrastructure.EndpointInfrastructure.Abstract
{
    public interface IGetEndpointsResponse : IResponseResult
    {
        IEnumerable<Endpoint> Endpoints { get; }
    }
}
