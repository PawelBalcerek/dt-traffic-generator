using System.ComponentModel.DataAnnotations;

namespace API.Models.Endpoint
{
    public class AddEndpointRequestModel
    { 
        [Required]
        public string EndpointName { get; set; }

        [Required]
        public string HttpMethod { get; set; }
    }
}
