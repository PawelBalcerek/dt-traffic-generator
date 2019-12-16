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
        public static async Task GetResources(long testParam, string token)
        {
            long userID = TestRun.user.Where(u => u.userToken == token).First().userId;
            List<ResourceModel> ret = new List<ResourceModel>();
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                string resp = "";
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    client.Headers.Add("Authorization", "Bearer " + token);
                    var result = await client.DownloadStringTaskAsync(GET_URLs.Resources).ConfigureAwait(true);

                    resp = result;
                    GetUserResourcesResponseModel resources = new GetUserResourcesResponseModel();
                    resources = JsonConvert.DeserializeObject<GetUserResourcesResponseModel>(resp);


                    ret = new List<ResourceModel>();
                    watch.Stop();
                    long TestTime = watch.ElapsedMilliseconds;
                    if (resources.execDetails.ExecTime == null || resources.execDetails.DbTime == null ||
                        TestTime == null)
                    {
                        resources.execDetails.ExecTime = 0;
                        resources.execDetails.DbTime = 0;
                        TestTime = 0;
                    }

                    ret.AddRange(resources.Resources);

                    TestRun.testsLis.Add(new Test(testParam, userID, (long)EndpointEnum.GetUserResources, resources.execDetails.DbTime.Value, resources.execDetails.ExecTime.Value, TestTime));


                    TestRun.user.Where(u => u.userId == userID).ToList().ForEach(ug => ug.userResources = ret);


                }
            }
            catch (Exception e)
            {
                TestRun.testsLis.Add(new Test(testParam, userID, (long)EndpointEnum.GetUserResources, 0, 0, 0));
            }


        }
    }

}
