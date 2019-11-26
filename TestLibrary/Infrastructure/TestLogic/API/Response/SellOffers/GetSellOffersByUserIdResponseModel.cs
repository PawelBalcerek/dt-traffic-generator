using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Response.ExecutingTimes;

namespace TestLibrary.Infrastructure.TestLogic.API.Response.SellOffers
{
    public class GetSellOffersByUserIdResponseModel
    {
        public IList<SellOfferModel> SellOffers { get; set; }
        public ExecutionDetails ExecDetails { get; set; }
    }
}
