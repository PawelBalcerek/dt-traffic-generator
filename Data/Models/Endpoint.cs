using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    [Table("Endpoints")]
    public class Endpoint
    {
        public Endpoint()
        {
            Tests = new HashSet<Test>();
        }

        public int EndpointId { get; set; }
        public string EndpointName { get; set; }
        public string HttpMethod { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
