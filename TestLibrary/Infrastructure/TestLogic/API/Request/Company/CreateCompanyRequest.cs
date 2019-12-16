using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLibrary.Infrastructure.TestLogic.API.Request.Company
{
    public class CreateCompanyRequest
    {
        public string name { get; set; }
        public int resourceAmount { get; set; }


        public bool IsValid => !string.IsNullOrWhiteSpace(name) && resourceAmount > 0;
    }
}
