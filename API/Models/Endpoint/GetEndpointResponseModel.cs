using TestLibrary.BusinessObject.Abstract;

namespace API.Models.Endpoint
{
    public class GetEndpointResponseModel
    {
        public GetEndpointResponseModel(IEndpoint endpoint)
        {
            Endpoint = endpoint;
        }

        public IEndpoint Endpoint { get; }
    }
}
