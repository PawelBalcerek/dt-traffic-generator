using System;

namespace TestLibrary.Infrastructure.TestLogic.API.Objects
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public int SellOfferId { get; set; }
        public int BuyOfferId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public CompanyModel Company { get; set; }
    }
}
