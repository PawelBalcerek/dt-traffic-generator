using System;
using System.Collections.Generic;
using System.Text;

namespace TestLibrary
{
    class GET_URLs
    {
        public static string apiUrl = "http://javatestai.ddns.net:8081/api";
         //public static string apiUrl = "http://java-ai.eastus.cloudapp.azure.com/api";
        //public static string apiUrl = "http://net-core-ai.eastus.cloudapp.azure.com/api";
        // public static string GETLogin = apiUrl + "/users";
        public static string GETCompanies = apiUrl + "/companies";
        public static string GetUserData = apiUrl + "/users";
        public static string Logout = apiUrl + "/logout";
        public static string Resources = apiUrl + "/users/resources";
        public static string SellOffers = apiUrl + "/users/sell-offers";
        public static string BuyOffers = apiUrl + "/users/buy-offers";
        public static string Transactions = apiUrl + "/users/transactions";



    }
    class POST_URLs
    {
        public static string apiUrl = GET_URLs.apiUrl;
        public static string Login = apiUrl + "/login";
        public static string Register = apiUrl + "/users";
        public static string AddCompanies = apiUrl + "/companies";
        public static string AddSellOffers = apiUrl + "/sell-offers";
        public static string AddBuyOffers = apiUrl + "/buy-offers";


    }

    class PUT_URLs
    {

        public static string apiUrl = GET_URLs.apiUrl;
        public static string WithdrawSellOffer = apiUrl + "/sell-offers/";
        public static string WithdrawBuyOffers = apiUrl + "/buy-offers/";
        public static string Configurations = apiUrl + "/configurations";

    }

    class DELETE_URLs
    {

        public static string apiUrl = GET_URLs.apiUrl;
        public static string DatabaseClear = apiUrl + "/database/clear";
        public static string DatabasePurge = apiUrl + "/database/purge";
    }
}
