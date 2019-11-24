using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.EndpointInfrastructure.Abstract;

namespace TestLibrary.Infrastructure.EndpointInfrastructure.Concrete
{
    public class AddEndpointResponse : IAddEndpointResponse
    {
        public AddEndpointResponse(ResponseResultEnum responseResultEnum)
        {
            ResponseResult = responseResultEnum;
        }

        public ResponseResultEnum ResponseResult { get; }
    }
}
