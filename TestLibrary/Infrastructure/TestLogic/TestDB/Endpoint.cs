using System;
using System.Collections.Generic;
using System.Text;

namespace TestLibrary.Infrastructure.TestLogic.TestDB
{
  
    public class Endpoint
    {
        //public Endpoint()
        //{
        //    Tests = new HashSet<Test>();
        //}

        public Endpoint(string endpointName, string httpMethod)
        {
            EndpointName = endpointName;
            HttpMethod = httpMethod;
           // Tests = new HashSet<Test>();
        }

       // public int EndpointId { get; set; }
        public string EndpointName { get; set; }
        public string HttpMethod { get; set; }

        //public virtual ICollection<Test> Tests { get; set; }
    }

    
    
    }

