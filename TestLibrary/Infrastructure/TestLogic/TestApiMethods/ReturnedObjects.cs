using System;
using System.Collections.Generic;
using System.Text;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Response.Companies;
using TestLibrary.Infrastructure.TestLogic.Models;
using TestLibrary.Infrastructure.TestLogic.TestDB;
using TestLibrary.TestApiMethods;

namespace TestLibrary.TestApiMethods
{
    public class ReturnLogin
    {
        public string jwt;
        public List<Test> testy;
    }

    public class ReturnUserInfo
    {
        public int id;
        public double cash;
        public List<Test> test;
    }

    public class ReturnUserGenerator
    {
        public List<Test> test;
        public List<UserGenerator> userGenerators;
    }

    public class ReturnRegistration
    {
        public List<Test> test;

    }

    public class ReturnGetCompanies
    {
        public List<Test> tests;
        public List<CompanyModel> companies;
    }
    public class ReturnAddCompanies
    {
        public List<Test> tests;
       
    }
    public class ReturnResources
    {
        public List<Test> tests;
        public List<ResourceModel> res;

    }
    public class ReturnGetSellOffers
    {
        public List<Test> tests;
        public List<SellOfferModel> sell;

    }

    public class ReturnAddSellOffers
    {
        public List<Test> tests;
        

    }
    public class ReturnPUTSellOffers
    {
        public List<Test> tests;


    }
    public class ReturnGetBuyOffers
    {
        public List<Test> tests;
        public List<BuyOfferModel> buy;

    }

    public class ReturnAddBuyOffers
    {
        public List<Test> tests;


    }
    public class ReturnPUTBuyOffers
    {
        public List<Test> tests;


    }
    public class ReturnTransactions
    {
        public List<Test> tests;
        public List<TransactionModel> Transaction;

    }

    //public class ReturnLogout
    //{
    //    public List<Test> test;

    //}

}
