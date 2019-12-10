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
        public static async Task RegisterUser(int testParam, string email, string password, string name)
        {
            ReturnRegistration ret = new ReturnRegistration();
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
                    //streamWriter.Write(output);
                }

                string resp = "";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync();

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
                //(new Test(0, testParam, 0, (int)EndpointEnum.AddUser, reg.ExecDetails.DbTime.Value,  reg.ExecDetails.ExecTime.Value, TestTime, DateTime.Now));
                ret.test.Add(new Test( testParam, 0, (int)EndpointEnum.AddUser, reg.ExecDetails.DbTime.Value, reg.ExecDetails.ExecTime.Value, TestTime));

            }
            catch (Exception e)
            {
                ret.test = new List<Test>();
                ret.test.Add(new Test( testParam, 0, (int)EndpointEnum.AddUser, 0, 0, 0));
            }
            TestRun.testsLis.AddRange(ret.test);
            //return ret;

        }

        public static async Task GetUserId(int testParameters, string token)
        {
            ReturnUserInfo returedId = new ReturnUserInfo();
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

                    TestRun.user.Where(u => u.userToken == token).ToList().ForEach(ug => ug.userId = returedId.id);
                    TestRun.user.Where(u => u.userToken == token).ToList().ForEach(ug => ug.userCash = returedId.cash);


                    //List<UserGenerator> userGens = Program.user;
                    //foreach (var x in userGens)
                    //{
                    //    userGens.Where(u => u.userName == x.userName.ToString()).ToList().ForEach(ug => ug.userId = returedId.id);
                    //    userGens.Where(u => u.userName == x.userName.ToString()).ToList().ForEach(ug => ug.userCash = returedId.cash);
                    //}
                    //(new Test(0, testParameters, returedId.id, (int)EndpointEnum.GetUserInfo, user.execDetails.DbTime.Value,  user.execDetails.ExecTime.Value, TestTime, DateTime.Now));
                    returedId.test.Add(new Test( testParameters, returedId.id, (int)EndpointEnum.GetUserInfo, user.execDetails.DbTime.Value, user.execDetails.ExecTime.Value, TestTime));



                }
            }
            catch (Exception e)
            {
                returedId.test = new List<Test>();
                returedId.test.Add(new Test( testParameters, returedId.id, (int)EndpointEnum.GetUserInfo, 0, 0, 0));

            }

            TestRun.testsLis.AddRange(returedId.test);

            //return returedId;
        }

        public static async Task GetJWT(int testParam, string email, string password)
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
                await streamWriter.WriteAsync(output);
                //streamWriter.Write(output);
            }

            string resp = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = await streamReader.ReadToEndAsync().ConfigureAwait(true);
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
            int userId = TestRun.user.Where(u => u.userEmail == email).First().userId;
            //List<UserGenerator> userGens = Program.user;

            TestRun.user.Where(u => u.userEmail == email).ToList().ForEach(ug => ug.userToken = ret.jwt);


            //foreach (var x in userGens)
            //    {
            //        userGens.Where(u => u.userName == x.userName.ToString()).ToList()
            //            .ForEach(ug => ug.userToken = ret.jwt);
            //    }

            //(new Test(0, testParam, userId, (int)EndpointEnum.Login, login.ExecDetails.DbTime.Value,  login.ExecDetails.ExecTime.Value, TestTime, DateTime.Now));
            ret.testy.Add(new Test( testParam, userId, (int)EndpointEnum.Login, login.ExecDetails.DbTime.Value, login.ExecDetails.ExecTime.Value, TestTime));

            //}
            //catch (Exception e)
            //{
            //    ret.testy = new List<Test>();
            //    ret.testy.Add(new Test(DateTime.Now, testParam, 0, (int)EndpointEnum.Login, 0, 0, 0));

            //}
            TestRun.testsLis.AddRange(ret.testy);

            //return ret.jwt;
        }

        public static async Task LogoutUser(int TestParamId, int id, string token)
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                //ReturnLogout ret = new ReturnLogout();
                List<Test> ret = new List<Test>();
                string resp = "";
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");
                    client.Headers.Add("Authorization", "Bearer " + token);
                    var result = await client.DownloadStringTaskAsync(GET_URLs.Logout).ConfigureAwait(true); //URI  
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

                    //(new Test(0, TestParamId, id, (int)EndpointEnum.Login, logout.ExecDetails.DbTime.Value,  logout.ExecDetails.ExecTime.Value, TestTime, DateTime.Now));
                    ret.Add(new Test( TestParamId, id, (int)EndpointEnum.Login, logout.ExecDetails.DbTime.Value, logout.ExecDetails.ExecTime.Value, TestTime));
                    TestRun.testsLis.AddRange(ret);

                }
            }
            catch (Exception e)
            {
                List<Test> ret = new List<Test>();
                ret.Add(new Test( TestParamId, id, (int)EndpointEnum.Login, 0, 0, 0));
                TestRun.testsLis.AddRange(ret);

            }

            //return ret;

        }
    }
}
