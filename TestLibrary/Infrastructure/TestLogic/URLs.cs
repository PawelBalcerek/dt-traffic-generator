using System;
using System.Collections.Generic;
using System.Text;

namespace TestLibrary.Infrastructure.TestLogic
{
    class GET_URLs
    {
       // public static string apiUrl = "http://javatestai.ddns.net:8080/api";
        public static string apiUrl = "http://java-ai.eastus.cloudapp.azure.com/api";
       // public static string GETLogin = apiUrl + "/users";
        public static string GETCompanies = apiUrl + "/companies";
        public static string GetUserData = apiUrl + "/users";

    }
    class POST_URLs
    {
        //public static string apiUrl = "http://javatestai.ddns.net:8080/api";
        public static string apiUrl = "http://java-ai.eastus.cloudapp.azure.com/api";

        public static string Login = apiUrl + "/login";
        public static string Register = apiUrl + "/users";
        public static string AddCompanies = apiUrl + "/companies";
        

    }
}
