using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Response.ExecutingTimes;

namespace TestLibrary.Infrastructure.TestLogic.API.Response.Users
{
    public class GetUserResponse
    {
        public UserModel user { get; set; }
        public ExecutionDetails execDetails { get; set; }
    }
}
