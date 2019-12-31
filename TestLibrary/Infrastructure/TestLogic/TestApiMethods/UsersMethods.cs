using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestLibrary;
using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.TestLogic;
using TestLibrary.Infrastructure.TestLogic.API.Request;
using TestLibrary.Infrastructure.TestLogic.API.Response.Users;



namespace TestLibrary.TestApiMethods
{
    class UsersMethods
    {
        public static async Task<Test> RegisterUser(long testParam, string email, string password, string name)
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(POST_URLs.Register);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                RegisterRequest user = new RegisterRequest();
                user.email = email;
                user.password = password;
                user.name = name;
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string output = JsonConvert.SerializeObject(user);
                    await streamWriter.WriteAsync(output);
                }

                string resp = "";
                var httpResponse = await httpWebRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync();

                    resp = result;
                }
                RegisterResponse reg = new RegisterResponse();
                reg = JsonConvert.DeserializeObject<RegisterResponse>(resp);
                watch.Stop();
                long TestTime = watch.ElapsedMilliseconds;

                if (reg.ExecDetails.ExecTime == null || reg.ExecDetails.DbTime == null || TestTime == null)
                {
                    reg.ExecDetails.ExecTime = 0;
                    reg.ExecDetails.DbTime = 0;
                    TestTime = 0;
                }

                //TestRun.testsLis.Add(new Test(testParam, 0, (long)EndpointEnum.AddUser, reg.ExecDetails.DbTime.Value, reg.ExecDetails.ExecTime.Value, TestTime));
                Test test = new Test(testParam, 0, (long) EndpointEnum.AddUser, reg.ExecDetails.DbTime.Value,
                    reg.ExecDetails.ExecTime.Value, TestTime);
                return test;
            }
            catch (Exception e)
            {
                //TestRun.testsLis.Add(new Test(testParam, 0, (long)EndpointEnum.AddUser, 0, 0, 0));
                Test test = new Test(testParam, 0, (long) EndpointEnum.AddUser, 0, 0, 0);
                return test;
            }

            
        }

        public static async Task<Test> GetUserId(long testParameters, string token)
        {
            int id = 0;
            double cash = 0;
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                string resp = "";
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");
                    client.Headers.Add("Authorization", "Bearer " + token);
                    var result = await client.DownloadStringTaskAsync(GET_URLs.GetUserData).ConfigureAwait(true); //URI  
                    resp = result;
                    GetUserResponse user = new GetUserResponse();
                    user = JsonConvert.DeserializeObject<GetUserResponse>(resp);

                    id = user.user.Id;
                    cash = user.user.Cash;
                    watch.Stop();
                    long TestTime = watch.ElapsedMilliseconds;
                    if (user.execDetails.ExecTime == null || user.execDetails.DbTime == null || TestTime == null)
                    {
                        user.execDetails.ExecTime = 0;
                        user.execDetails.DbTime = 0;
                        TestTime = 0;
                    }
                    TestRun.user.Where(u => u.userToken == token).ToList().ForEach(ug => ug.userId = id);
                    TestRun.user.Where(u => u.userToken == token).ToList().ForEach(ug => ug.userCash = cash);
                    //TestRun.testsLis.Add(new Test(testParameters, id, (long)EndpointEnum.GetUserInfo, user.execDetails.DbTime.Value, user.execDetails.ExecTime.Value, TestTime));
                    Test test = new Test(testParameters, id, (long)EndpointEnum.GetUserInfo, user.execDetails.DbTime.Value, user.execDetails.ExecTime.Value, TestTime);
                    return test;
                }
            }
            catch (Exception e)
            {
                //TestRun.testsLis.Add(new Test(testParameters, id, (long)EndpointEnum.GetUserInfo, 0, 0, 0));
                Test test = new Test(testParameters, id, (long) EndpointEnum.GetUserInfo, 0, 0, 0);
                return test;
            }
        }

        public static async Task<Test> GetJWT(long testParam, string email, string password)
        {
            string jwt = "";
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(POST_URLs.Login);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            LoginRequest user = new LoginRequest();
            user.email = email;
            user.password = password;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string output = JsonConvert.SerializeObject(user);
                await streamWriter.WriteAsync(output);
            }

            string resp = "";
            var httpResponse = await httpWebRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = await streamReader.ReadToEndAsync();
                resp = result;
            }

            LoginResponse login = new LoginResponse();
            login = JsonConvert.DeserializeObject<LoginResponse>(resp);

            jwt = login.jwt.ToString();
            watch.Stop();
            long TestTime = watch.ElapsedMilliseconds;
            if (login.ExecDetails.ExecTime == null || login.ExecDetails.DbTime == null || TestTime == null)
            {
                login.ExecDetails.ExecTime = 0;
                login.ExecDetails.DbTime = 0;
                TestTime = 0;
            }
            int userId = TestRun.user.Where(u => u.userEmail == email).First().userId;
            TestRun.user.Where(u => u.userEmail == email).ToList().ForEach(ug => ug.userToken = jwt);
            //TestRun.testsLis.Add(new Test(testParam, userId, (long)EndpointEnum.Login, login.ExecDetails.DbTime.Value, login.ExecDetails.ExecTime.Value, TestTime));
            Test test = new Test(testParam, 0, (long) EndpointEnum.Login, login.ExecDetails.DbTime.Value,
                login.ExecDetails.ExecTime.Value, TestTime);
            return test;
        }


        public static async Task LogoutUser(long TestParamId, long id, string token)
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                string resp = "";
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    client.Headers.Add("Authorization", "Bearer " + token);
                    var result = await client.DownloadStringTaskAsync(GET_URLs.Logout).ConfigureAwait(false); 
                    resp = result;
                    LogoutResponse logout = new LogoutResponse();
                   logout = JsonConvert.DeserializeObject<LogoutResponse>(resp);


                    
                    watch.Stop();
                    long TestTime = watch.ElapsedMilliseconds;
                    if (logout.ExecDetails.ExecTime == null || logout.ExecDetails.DbTime == null || TestTime == null)
                    {
                        logout.ExecDetails.ExecTime = 0;
                        logout.ExecDetails.DbTime = 0;
                        TestTime = 0;
                    }

                    TestRun.testsLis.Add(new Test(TestParamId, id, (long)EndpointEnum.Logout, logout.ExecDetails.DbTime.Value, logout.ExecDetails.ExecTime.Value, TestTime));

                }
            }
            catch (Exception e)
            {
                
                TestRun.testsLis.Add(new Test(TestParamId, id, (long)EndpointEnum.Logout, 0, 0, 0));

            }

            

        }
    }
}
