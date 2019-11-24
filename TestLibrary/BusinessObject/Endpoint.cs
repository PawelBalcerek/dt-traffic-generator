using TestLibrary.BusinessObject.Abstract;

namespace TestLibrary.BusinessObject
{
    public class Endpoint : IEndpoint
    {
        public Endpoint(int endpointId, string endpointName, string httpMethod)
            : this(endpointName, httpMethod)
        {
            EndpointId = endpointId;
        }

        public Endpoint(string endpointName, string httpMethod)
        {
            EndpointName = endpointName;
            HttpMethod = httpMethod;
        }

        public int EndpointId { get; }
        public string EndpointName { get; }
        public string HttpMethod { get; }
    }
}
