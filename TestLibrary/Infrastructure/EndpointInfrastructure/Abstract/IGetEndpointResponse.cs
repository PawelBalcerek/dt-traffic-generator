using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.Common.Abstract;

namespace TestLibrary.Infrastructure.EndpointInfrastructure.Abstract
{
    public interface IGetEndpointResponse : IResponseResult
    {
        Endpoint Endpoint { get; }
    }
}
