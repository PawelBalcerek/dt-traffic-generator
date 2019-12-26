using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLibrary.Infrastructure.TestLogic.API.Response.ExecutingTimes
{
    public class ExecutionDetails
    {
        public long? DbTime { get; set; }
        public long? ExecTime { get; set; }
    }
}