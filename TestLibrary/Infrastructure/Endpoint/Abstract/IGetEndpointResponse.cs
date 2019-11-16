using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Infrastructure.Common.Abstract;

namespace TestLibrary.Infrastructure.Endpoint.Abstract
{
    public interface IGetEndpointResponse : IResponseResult
    {
        IEndpoint Endpoint { get; }
    }
}
