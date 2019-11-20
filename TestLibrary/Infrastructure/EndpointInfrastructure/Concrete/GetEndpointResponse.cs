using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.EndpointInfrastructure.Abstract;

namespace TestLibrary.Infrastructure.EndpointInfrastructure.Concrete
{
    public class GetEndpointResponse : IGetEndpointResponse
    {
        public GetEndpointResponse()
        {
            ResponseResult = ResponseResultEnum.Exception;
        }

        public GetEndpointResponse(Endpoint endpoint)
        {
            if (endpoint == null)
            {
                ResponseResult = ResponseResultEnum.NotFound;
            }
            else
            {
                Endpoint = endpoint;
                ResponseResult = ResponseResultEnum.Success;
            }
        }
        public Endpoint Endpoint { get; }
        public ResponseResultEnum ResponseResult { get; }
    }
}
