using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using TestLibrary;
using TestLibrary.Infrastructure.TestLogic;
using TestLibrary.Infrastructure.TestLogic.API.Request;
using TestLibrary.Infrastructure.TestLogic.API.Response.Users;
using TestLibrary.Infrastructure.TestLogic.TestDB;



namespace TestLibrary.TestApiMethods
{
    class UsersMethods
    {
        public static ReturnRegistration RegisterUser(int testParam, string email, string password, string name)
        {
            ReturnRegistration ret = new ReturnRegistration();
            //try
            //{
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
                streamWriter.Write(output);
            }

            string resp = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                resp = result;
            }
            RegisterResponse reg = new RegisterResponse();
            reg = JsonConvert.DeserializeObject<RegisterResponse>(resp);
            watch.Stop();
            long TestTime = watch.ElapsedMilliseconds;
            ret.test = new List<Test>();
            if (reg.ExecDetails.ExecTime == null || reg.ExecDetails.DbTime == null || TestTime == null)
            {
                reg.ExecDetails.ExecTime = 0;
                reg.ExecDetails.DbTime = 0;
                TestTime = 0;
            }
            ret.test.Add(new Test(DateTime.Now, testParam, 0, (int)EndpointEnum.AddUser, reg.ExecDetails.DbTime.Value, TestTime, reg.ExecDetails.ExecTime.Value));

            //}
            //catch (Exception e)
            //{
            //    ret.test = new List<Test>();
            //    ret.test.Add(new Test(DateTime.Now, testParam, 0, (int)EndpointEnum.AddUser, 0, 0, 0));
            //}

            return ret;

        }

        public static ReturnUserInfo GetUserId(int testParameters, string token)
        {
            ReturnUserInfo returedId = new ReturnUserInfo();
            //try
            //{
            var watch = System.Diagnostics.Stopwatch.StartNew();

            string resp = "";
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                client.Headers.Add("Authorization", "Bearer " + token);
                var result = client.DownloadString(GET_URLs.GetUserData); //URI  
                resp = result;
                GetUserResponse user = new GetUserResponse();
                user = JsonConvert.DeserializeObject<GetUserResponse>(resp);

                returedId.id = user.user.Id;
                returedId.cash = user.user.Cash;
                returedId.test = new List<Test>();
                watch.Stop();
                long TestTime = watch.ElapsedMilliseconds;
                if (user.execDetails.ExecTime == null || user.execDetails.DbTime == null || TestTime == null)
                {
                    user.execDetails.ExecTime = 0;
                    user.execDetails.DbTime = 0;
                    TestTime = 0;
                }
                returedId.test.Add(new Test(DateTime.Now, testParameters, 0, (int)EndpointEnum.GetUserInfo, user.execDetails.DbTime.Value, TestTime, user.execDetails.ExecTime.Value));



            }
            //}
            //catch (Exception e)
            //{
            //    returedId.test = new List<Test>();
            //    returedId.test.Add(new Test(DateTime.Now, testParameters, 0, (int)EndpointEnum.GetUserInfo, 0, 0, 0));

            //}



            return returedId;
        }

        public static ReturnLogin GetJWT(int testParam, string email, string password)
        {
            ReturnLogin ret = new ReturnLogin();
            //try
            //{
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
                streamWriter.Write(output);
            }

            string resp = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                resp = result;
            }

            LoginResponse login = new LoginResponse();
            login = JsonConvert.DeserializeObject<LoginResponse>(resp);

            ret.jwt = login.jwt.ToString();
            ret.testy = new List<Test>();
            watch.Stop();
            long TestTime = watch.ElapsedMilliseconds;
            if (login.ExecDetails.ExecTime == null || login.ExecDetails.DbTime == null || TestTime == null)
            {
                login.ExecDetails.ExecTime = 0;
                login.ExecDetails.DbTime = 0;
                TestTime = 0;
            }

            ret.testy.Add(new Test(DateTime.Now, testParam, 0, (int)EndpointEnum.Login, login.ExecDetails.DbTime.Value, TestTime, login.ExecDetails.ExecTime.Value));

            //}
            //catch (Exception e)
            //{
            //    ret.testy = new List<Test>();
            //    ret.testy.Add(new Test(DateTime.Now, testParam, 0, (int)EndpointEnum.Login, 0, 0, 0));

            //}


            return ret;
        }

        public static void LogoutUser(int TestParamId, int id, string token)
        {
            //try
            //{
            var watch = System.Diagnostics.Stopwatch.StartNew();
            //ReturnLogout ret = new ReturnLogout();
            List<Test> ret = new List<Test>();
            string resp = "";
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                client.Headers.Add("Authorization", "Bearer " + token);
                var result = client.DownloadString(GET_URLs.Logout); //URI  
                resp = result;
                LogoutResponse logout = new LogoutResponse();
                // respo user = new GetUserResponse();
                logout = JsonConvert.DeserializeObject<LogoutResponse>(resp);


                // ret.test = new List<Test>();
                watch.Stop();
                long TestTime = watch.ElapsedMilliseconds;
                if (logout.ExecDetails.ExecTime == null || logout.ExecDetails.DbTime == null || TestTime == null)
                {
                    logout.ExecDetails.ExecTime = 0;
                    logout.ExecDetails.DbTime = 0;
                    TestTime = 0;
                }

                ret.Add(new Test(DateTime.Now, TestParamId, id, (int)EndpointEnum.Logout, logout.ExecDetails.DbTime.Value,
                    TestTime,
                    logout.ExecDetails.ExecTime.Value));
                TestRun.testsLis.AddRange(ret);
            }
            //}
            //catch (Exception e)
            //{
            //    List<Test> ret = new List<Test>();
            //    ret.Add(new Test(DateTime.Now, TestParamId, id, (int)EndpointEnum.Logout, 0,
            //        0,
            //        0));
            //}

            //return ret;

        }
    }
}
