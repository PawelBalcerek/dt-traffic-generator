using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.EndpointInfrastructure.Abstract;

namespace TestLibrary.Creators.Abstract
{
    public interface IEndpointsCreator
    {
        IAddEndpointResponse AddEndpoint(Endpoint endpoint);
    }
}
