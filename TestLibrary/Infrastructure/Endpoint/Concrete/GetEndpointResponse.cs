using TestLibrary.BusinessObject.Abstract;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.Endpoint.Abstract;

namespace TestLibrary.Infrastructure.Endpoint.Concrete
{
    public class GetEndpointResponse : IGetEndpointResponse
    {
        public GetEndpointResponse()
        {
            ResponseResult = ResponseResultEnum.Exception;
        }

        public GetEndpointResponse(IEndpoint endpoint)
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
        public IEndpoint Endpoint { get; }
        public ResponseResultEnum ResponseResult { get; }
    }
}
