using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using TestLibrary.BusinessObject;
using TestLibrary.Creators.Abstract;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.TestInfrastructure.Abstract;
using TestLibrary.Infrastructure.TestLogic.TestApiMethods;

namespace TestLibrary.Infrastructure.TestLogic
{
    public class TestRun : ITestRun
    {
        private readonly ITestsCreator _testsCreator;
        public TestRun(ITestsCreator testsCreator)
        {
            _testsCreator = testsCreator;
        }
        //private static string url = "http://javatestai.ddns.net:8080/api";
        //private static string url = "http://net-core-ai.eastus.cloudapp.azure.com/api";

        public void TestMain()
        {

            //IList<Test> tests = new List<Test>(); //TODO jak w bazie nie bedzie podanych "testParametersId" lub "endpointId" to narazie wraca status "Exception"
            //tests.Add(new Test(1, 1, 1, new DateTime(), new DateTime(), new DateTime()));
            //tests.Add(new Test(9, 1, 13, new DateTime(), new DateTime(), new DateTime()));
            //IAddTestsResponse addTestsResponse = _testsCreator.AddTests(tests);
            //ResponseResultEnum result = addTestsResponse.ResponseResult;
            //if (result ==ResponseResultEnum.Success)
            //{

            //}
            //GetCompaniesResponseModel comp = CompaniesMethod.GetCompanies(jwt);
            //foreach (var x in comp.Companies)
            //{
            //    Console.WriteLine(x.Id + " " + x.Name);
            //}

            //try
            //{
            //    Console.WriteLine("Czasy: " + comp.ExecDetails.DbTime + " " + comp.ExecDetails.ExecTime);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            //CreateCompanyResponseModel comp  = CompaniesMethod.POSTCompanies(jwt, "Nazwa_aha", 1500);
            //Console.WriteLine("Dodano w czasie: " + comp.ExecDetails.DbTime + " " + comp.ExecDetails.ExecTime );


            List<UserGenerator> ug = userGenerator(2);
            foreach (var xGen in ug)
            {
                //Log.Information();
                Console.WriteLine(xGen.userName + " " + xGen.userEmail + " " + xGen.userPassword + " " + xGen.userToken + " " + xGen.userId);
                Console.WriteLine();
            }


            //foreach (var xGen in ug)
            //{
            //    Console.WriteLine(xGen.userName + " " + xGen.userEmail + " " + xGen.userPassword + " " + xGen.userToken + " " + xGen.userId);
            //}

            //UsersMethods.RegisterUser("aha@aha", "aha", "aha");
            //GetUserData();

            #region NotUsedCode

            /*RegisterUser();
            string JWTAuth = GetJWT();
            string comp = GetAllCompany();
            GetCompaniesResponseModel getUser = JsonConvert.DeserializeObject<GetCompaniesResponseModel>(comp);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nDatabase time: " + getUser.ExecutionDetails.DbTime);
            Console.WriteLine("Execution time: " + getUser.ExecutionDetails.ExecTime);
            foreach (var x in getUser.Companies)
            {
                Console.WriteLine(x.Id);
                Console.WriteLine(x.Name);

            }
            Console.WriteLine(getUser);

            List < GetCompaniesResponseModel >
           string result = GetAllUser(url + "/users");

            string result = GetAllUsers();
            Console.WriteLine(result);
            Console.WriteLine(JWTAuth);
            Console.ForegroundColor = fg;
            POSTCompanies();
            string res = GetAllCompany();
            Console.WriteLine(res);
            GetAllUsers();
            RegisterUser();
            string url = string.Format("http://javatestai.ddns.net:8080/api/users/all");
            string details = GetAllUser(url);
            string details = GetAllUsers();
            string companies = GetAllCompany();
            Console.WriteLine("\n\nPlik .JSON");
            Console.WriteLine(companies);
            GetUserResponse getUser = JsonConvert.DeserializeObject<GetUserResponse>(details);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nDatabase time: " + getUser.execDetails.DbTime);
            Console.WriteLine("Execution time: " + getUser.execDetails.ExecTime);
            Console.ForegroundColor = fg;

            Console.WriteLine("(" + getUser.user.Id + ")" + " " + getUser.user.Name + " " + getUser.user.Email + " " + getUser.user.Cash);


            GetAllUsers();*/

            #endregion

        }

        public static string jwt = UsersMethods.GetJWT("aha@aha", "aha");









        /* public static string GetAllCompany()
         {
             string resp = "";
             using (var client = new WebClient())
             {
                 client.Headers.Add("Content-Type:application/json"); //Content-Type  
                 client.Headers.Add("Accept:application/json");
                 client.Headers.Add("Authorization", "Bearer " + jwt);
                 var result = client.DownloadString(url + "/companies"); //URI  
                 resp = result;
                 //Console.WriteLine(Environment.NewLine + result);
                 return result;
             }

         }*/

        /* public static string GetAllUser(string url)
         {

             HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
             webrequest.Method = "GET";
             webrequest.ContentType = "application/x-www-form-urlencoded";
             webrequest.Headers.Add("Authorization", "Bearer " + jwt);
             //  webrequest.Headers.Add("Password", "abc");
             HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
             Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
             StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
             string result = string.Empty;
             result = responseStream.ReadToEnd();
             webresponse.Close();
             return result;
         }*/

        public static List<UserGenerator> userGenerator(int usernumber)
        {
            List<UserGenerator> userGens = new List<UserGenerator>();

            for (int i = 1; i < usernumber + 1; i++)
            {
                userGens.Add(new UserGenerator("utest" + i, "pass", "utest" + i + "@user.user", "", 0));
            }

            //foreach (var x in userGens)
            //{
            //    UsersMethods.RegisterUser(x.userEmail, x.userPassword, x.userName);
            //}
            // userGens.Add(new UserGenerator("aha", "aha", "aha@aha", "", 0));

            for (int i = 0; i < userGens.Count; i++)
            {
                string key = UsersMethods.GetJWT(userGens[i].userEmail.ToString(), userGens[i].userPassword.ToString());
                int id = UsersMethods.GetUserId(key);
                userGens.Where(u => u.userName == userGens[i].userName.ToString()).ToList().ForEach(ug => ug.userToken = key);
                userGens.Where(u => u.userName == userGens[i].userName.ToString()).ToList().ForEach(ug => ug.userId = id);
            }

            return userGens;

        }
    }

    public class UserGenerator
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string userEmail { get; set; }
        public string userToken { get; set; }
        public int userId { get; set; }



        public UserGenerator(string name, string password, string email, string token, int id)
        {
            userName = name;
            userPassword = password;
            userEmail = email;
            userToken = token;
            userId = id;

        }
    }

}