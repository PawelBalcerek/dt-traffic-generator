namespace API.Models.Endpoint
{
    public class AddEndpointRequestModel
    {
        public AddEndpointRequestModel(string endpointName, string httpMethod)
        {
            EndpointName = endpointName;
            HttpMethod = httpMethod;
        }

        public string EndpointName { get; }
        public string HttpMethod { get; }
    }
}
