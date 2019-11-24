using TestLibrary.Infrastructure.EndpointInfrastructure.Abstract;

namespace TestLibrary.Providers.Abstract
{
    public interface IEndpointsProvider
    {
        IGetEndpointResponse GetEndpoint(long endpointId);
        IGetEndpointsResponse GetEndpoints();
    }
}
