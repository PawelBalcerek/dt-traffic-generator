using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Response.ExecutingTimes;

namespace TestLibrary.Infrastructure.TestLogic.API.Response.Transactions
{
    public class GetTransactionsByUserIdResponseModel
    {
        public IList<TransactionModel> Transactions { get; set; }
        public ExecutionDetails ExecDetails { get; set; }
    }
}
