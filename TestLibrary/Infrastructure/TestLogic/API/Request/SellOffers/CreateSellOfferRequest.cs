using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLibrary.Infrastructure.TestLogic.API.Request.SellOffers
{
    public class CreateSellOfferRequest
    {
        public int resourceId { get; set; }
        public int amount { get; set; }
        public double price { get; set; }
    }
}
