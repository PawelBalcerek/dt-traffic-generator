﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLibrary.Infrastructure.TestLogic.API.Objects
{
    public class SellOfferModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int StartAmount { get; set; }
        public bool IsValid { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public CompanyModel Company { get; set; }
    }
}
