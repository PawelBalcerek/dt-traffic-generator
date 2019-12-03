using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using TestLibrary;
using TestLibrary.Infrastructure.TestLogic;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Response.Companies;
using TestLibrary.Infrastructure.TestLogic.API.Response.Resources;
using TestLibrary.Infrastructure.TestLogic.API.Response.Transactions;
using TestLibrary.Infrastructure.TestLogic.TestDB;

namespace TestLibrary.TestApiMethods
{
    class ResourcesMethods
    {
        public static ReturnResources GetResources(int testParam, string token, int userID)
        {
            ReturnResources ret = new ReturnResources();
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                //GetCompaniesResponseModel comp = new GetCompaniesResponseModel();
                string resp = "";
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");
                    client.Headers.Add("Authorization", "Bearer " + token);
                    var result = client.DownloadString(GET_URLs.Resources); //URI  
                    resp = result;
                    GetUserResourcesResponseModel resources = new GetUserResourcesResponseModel();
                    resources = JsonConvert.DeserializeObject<GetUserResourcesResponseModel>(resp);

                    ret.tests = new List<Test>();
                    ret.res = new List<ResourceModel>();
                    watch.Stop();
                    long TestTime = watch.ElapsedMilliseconds;
                    if (resources.ExecDetails.ExecTime == null || resources.ExecDetails.DbTime == null ||
                        TestTime == null)
                    {
                        resources.ExecDetails.ExecTime = 0;
                        resources.ExecDetails.DbTime = 0;
                        TestTime = 0;
                    }

                    ret.tests.Add(new Test(DateTime.Now, testParam, userID, (int) EndpointEnum.GetUserResources,
                        resources.ExecDetails.DbTime.Value, TestTime, resources.ExecDetails.ExecTime.Value));

                    ret.res.AddRange(resources.Resources);

                    TestRun.testsLis.AddRange(ret.tests);


                    TestRun.user.Where(u => u.userId == userID).ToList().ForEach(ug => ug.userResources = ret.res);

                    //   Program.user.Where(u => u.userId == userID).ToList().ForEach(ug => ug.userResources = ret.res);
                }
            }
            catch (Exception e)
            {
                ret.tests = new List<Test>();

                ret.tests.Add(new Test(DateTime.Now, testParam, userID, (int)EndpointEnum.GetUserResources,
                    0, 0, 0));

                TestRun.testsLis.AddRange(ret.tests);
            }

            return ret;
                //Console.WriteLine(Environment.NewLine + result);
                //return result;
            }
        }
    
}
