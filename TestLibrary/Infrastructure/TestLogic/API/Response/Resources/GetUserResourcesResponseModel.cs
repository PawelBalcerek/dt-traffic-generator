using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Response.ExecutingTimes;

namespace TestLibrary.Infrastructure.TestLogic.API.Response.Resources
{
    public class GetUserResourcesResponseModel
    {
        public IList<ResourceModel> Resources { get; set; }
        public ExecutionDetails ExecutionDetails { get; set; }
    }
}
