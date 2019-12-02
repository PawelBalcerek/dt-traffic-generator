using System.ComponentModel.DataAnnotations;

namespace API.Models.Endpoint
{
    public class AddEndpointRequestModel
    {
        public AddEndpointRequestModel(string endpointName, string httpMethod)
        {
            EndpointName = endpointName;
            HttpMethod = httpMethod;
        }

        [Required]
        public string EndpointName { get; }

        [Required]
        public string HttpMethod { get; }
    }
}
