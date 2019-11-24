using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TestLibrary.BusinessObject.Abstract;

namespace Data.Models
{
    [Table("Endpoints")]
    public class Endpoint : IEndpoint
    {
        public Endpoint()
        {
            Tests = new HashSet<Test>();
        }

        public Endpoint(string endpointName, string httpMethod)
        {
            EndpointName = endpointName;
            HttpMethod = httpMethod;
            Tests = new HashSet<Test>();
        }

        public int EndpointId { get; set; }
        public string EndpointName { get; set; }
        public string HttpMethod { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
