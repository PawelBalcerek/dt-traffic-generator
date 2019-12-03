using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Response.ExecutingTimes;

namespace TestLibrary.Infrastructure.TestLogic.API.Response.Companies
{
    public class GetCompaniesResponseModel
    {
        public List<CompanyModel> Companies { get; set; }
        public ExecutionDetails ExecDetails { get; set; }

    }

}
