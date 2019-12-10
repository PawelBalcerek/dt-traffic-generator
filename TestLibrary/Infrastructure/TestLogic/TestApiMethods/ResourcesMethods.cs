using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestLibrary;
using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.TestLogic;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Response.Companies;
using TestLibrary.Infrastructure.TestLogic.API.Response.Resources;
using TestLibrary.Infrastructure.TestLogic.API.Response.Transactions;

namespace TestLibrary.TestApiMethods
{
    class ResourcesMethods
    {
        public static async Task GetResources(int testParam, string token)
        {
            int userID = TestRun.user.Where(u => u.userToken == token).First().userId;
            ReturnResources ret = new ReturnResources();
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                string resp = "";
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");
                    client.Headers.Add("Authorization", "Bearer " + token);
                    var result = await client.DownloadStringTaskAsync(GET_URLs.Resources).ConfigureAwait(true); //URI  

                    resp = result;
                    GetUserResourcesResponseModel resources = new GetUserResourcesResponseModel();
                    resources = JsonConvert.DeserializeObject<GetUserResourcesResponseModel>(resp);

                    ret.tests = new List<Test>();
                    ret.res = new List<ResourceModel>();
                    watch.Stop();
                    long TestTime = watch.ElapsedMilliseconds;
                    if (resources.execDetails.ExecTime == null || resources.execDetails.DbTime == null ||
                        TestTime == null)
                    {
                        resources.execDetails.ExecTime = 0;
                        resources.execDetails.DbTime = 0;
                        TestTime = 0;
                    }
                    //(new Test(0, testParam, userID, (int)EndpointEnum.GetCompanies, resources.execDetails.DbTime.Value, resources.execDetails.ExecTime.Value, TestTime, DateTime.Now));
                    ret.tests.Add(new Test( testParam, userID, (int)EndpointEnum.GetCompanies, resources.execDetails.DbTime.Value, resources.execDetails.ExecTime.Value, TestTime));

                    ret.res.AddRange(resources.Resources);

                    TestRun.testsLis.AddRange(ret.tests);


                    TestRun.user.Where(u => u.userId == userID).ToList().ForEach(ug => ug.userResources = ret.res);

                    //   Program.user.Where(u => u.userId == userID).ToList().ForEach(ug => ug.userResources = ret.res);
                }
            }
            catch (Exception e)
            {
                ret.tests = new List<Test>();
                //(new Test(0, testParam, userID, (int)EndpointEnum.GetCompanies, resources.execDetails.DbTime.Value, resources.execDetails.ExecTime.Value, TestTime, DateTime.Now));
                ret.tests.Add(new Test( testParam, userID, (int)EndpointEnum.GetCompanies, 0, 0,0));

                TestRun.testsLis.AddRange(ret.tests);
            }

            //return Task.CompletedTask;
            //Console.WriteLine(Environment.NewLine + result);
            //return result;
        }
    }

}
