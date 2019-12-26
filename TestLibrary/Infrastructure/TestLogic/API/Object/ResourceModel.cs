using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLibrary.Infrastructure.TestLogic.API.Objects
{
    public class ResourceModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public CompanyModel Company { get; set; }
        public int Amount { get; set; }
    }
}
