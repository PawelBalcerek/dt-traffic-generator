using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLibrary.Infrastructure.TestLogic.API.Request.BuyOffers
{
    public class CreateBuyOfferRequest
    {
        public int companyId { get; set; }
        public int amount { get; set; }
        public double price { get; set; }
    }
}
