using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serilog;
using TestLibrary;
using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.TestLogic;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Request;
using TestLibrary.Infrastructure.TestLogic.API.Request.SellOffers;
using TestLibrary.Infrastructure.TestLogic.API.Response.SellOffers;
using TestLibrary.Infrastructure.TestLogic.API.Response.Users;


namespace TestLibrary.TestApiMethods
{
    class SellOffersMethods
    {
        public static async Task GetUserSellOffers(long paramId, string token)
        {
            List<SellOfferModel> returnedSellOffers = new List<SellOfferModel>();
            long userId = TestRun.user.Where(u => u.userToken == token).First().userId;
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                string resp = "";
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");
                    client.Headers.Add("Authorization", "Bearer " + token);
                    var result = await client.DownloadStringTaskAsync(GET_URLs.SellOffers).ConfigureAwait(true); //URI  
                    resp = result;
                    GetSellOffersByUserIdResponseModel response = new GetSellOffersByUserIdResponseModel();
                    response = JsonConvert.DeserializeObject<GetSellOffersByUserIdResponseModel>(resp);
                    //returnedSellOffers.tests = new List<Test>();
                    returnedSellOffers = new List<SellOfferModel>();
                    returnedSellOffers.AddRange(response.SellOffers);
                    watch.Stop();
                    long TestTime = watch.ElapsedMilliseconds;
                    if (response.execDetails.ExecTime == null || response.execDetails.DbTime == null ||
                        TestTime == null)
                    {
                        response.execDetails.ExecTime = 0;
                        response.execDetails.DbTime = 0;
                        TestTime = 0;
                    }
                    //(new Test(0, paramId, userId, (long)EndpointEnum.GetSellOffers, response.execDetails.DbTime.Value, response.execDetails.ExecTimeValue, TestTime, DateTime.Now));
                    //returnedSellOffers.tests.Add(new Test( paramId, userId, (long)EndpointEnum.GetSellOffers, response.execDetails.DbTime.Value, response.execDetails.ExecTime.Value, TestTime));
                    TestRun.testsLis.Add(new Test(paramId, userId, (long)EndpointEnum.GetSellOffers, response.execDetails.DbTime.Value, TestTime, response.execDetails.ExecTime.Value));


                    TestRun.user.Where(u => u.userId == userId).ToList()
                        .ForEach(ug => ug.userSellOffers = returnedSellOffers);

                }
            }
            catch (Exception e)
            {
                //returnedSellOffers.tests = new List<Test>();
                //returnedSellOffers.tests.Add(new Test(paramId, userId, (long)EndpointEnum.GetSellOffers, 0, 0, 0));
                TestRun.testsLis.Add(new Test(paramId, userId, (long)EndpointEnum.GetSellOffers, 0, 0, 0));
            }

            await Task.CompletedTask;


            //return Task.CompletedTask;
        }

        public static async Task AddSellOffer(long testParam, string token, double minSellPrice, double maxSellPrice)
        {
            List<SellOfferModel> ret = new List<SellOfferModel>();
            long USERID = TestRun.user.Where(u => u.userToken == token).First().userId;
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();


                Random random = new Random();
                int amount = random.Next(1, 50);
                double price = random.Next((int)minSellPrice, (int)maxSellPrice);
                List<ResourceModel> userResources = new List<ResourceModel>();
                List<int> IdUserResources = new List<int>();


                foreach (var x in TestRun.user)
                {
                    if (x.userToken == token)
                    {
                        userResources = x.userResources;
                        foreach (var y in userResources)
                        {
                            if (y.Amount > 0)
                            {
                                IdUserResources.Add(y.Id);
                            }

                        }
                    }
                }

                int resourceId = IdUserResources[random.Next(0, IdUserResources.Count)];
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(POST_URLs.AddSellOffers);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
                httpWebRequest.Method = "POST";

                CreateSellOfferRequest sellOfferRequest = new CreateSellOfferRequest();
                sellOfferRequest.resourceId = resourceId;
                sellOfferRequest.amount = amount;
                sellOfferRequest.price = price;
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string output = JsonConvert.SerializeObject(sellOfferRequest);
                    await streamWriter.WriteAsync(output);
                }

                string resp = "";
                var httpResponse = await httpWebRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync();

                    resp = result;
                }
                CreateSellOfferResponseModel response = new CreateSellOfferResponseModel();
                response = JsonConvert.DeserializeObject<CreateSellOfferResponseModel>(resp);
                watch.Stop();
                long TestTime = watch.ElapsedMilliseconds;
                ///ret.tests = new List<Test>();
                if (response.execDetails.ExecTime == null || response.execDetails.DbTime == null || TestTime == null)
                {
                    response.execDetails.ExecTime = 0;
                    response.execDetails.DbTime = 0;
                    TestTime = 0;
                }
                //(new Test(0, testParam, USERID, (long)EndpointEnum.AddSellOffer, response.execDetails.DbTime.Value, response.execDetails.ExecTimeValue, TestTime, DateTime.Now));
                //ret.tests.Add(new Test( testParam, USERID, (long)EndpointEnum.AddSellOffer, response.execDetails.DbTime.Value, response.execDetails.ExecTime.Value, TestTime));
                TestRun.testsLis.Add(new Test(testParam, USERID, (long)EndpointEnum.AddSellOffer, response.execDetails.DbTime.Value, TestTime, response.execDetails.ExecTime.Value));
            }
            catch (Exception e)
            {
                //ret.tests = new List<Test>();
                //ret.tests.Add(new Test( testParam, USERID, (long)EndpointEnum.AddSellOffer, 0, 0, 0));
                TestRun.testsLis.Add(new Test(testParam, USERID, (long)EndpointEnum.AddSellOffer, 0, 0, 0));
            }

        }

        public static async Task PutSellOffers(long testParam, string token, long USERID)
        {
            //List<SellOfferModel> ret = new List<SellOfferModel>();
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();


                Random random = new Random();


                List<SellOfferModel> userSellOffers = new List<SellOfferModel>();
                List<int> IdUserSellOffers = new List<int>();


                foreach (var x in TestRun.user)
                {
                    if (x.userToken == token)
                    {
                        userSellOffers = x.userSellOffers;
                        foreach (var y in userSellOffers)
                        {
                            if (y.IsValid == true)
                            {
                                IdUserSellOffers.Add(y.Id);
                            }

                        }
                    }
                }

                int sellOfferId = IdUserSellOffers[random.Next(0, IdUserSellOffers.Count)];
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(PUT_URLs.WithdrawSellOffer + sellOfferId.ToString());
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
                httpWebRequest.Method = "PUT";

                CreateSellOfferRequest sellOfferRequest = new CreateSellOfferRequest();

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    //string output = JsonConvert.SerializeObject(sellOfferRequest);
                    //streamWriter.Write(output);
                }


                string resp = "";
                var httpResponse = await httpWebRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync();

                    resp = result;
                }
                WithdrawSellOfferResponseModel response = new WithdrawSellOfferResponseModel();
                response = JsonConvert.DeserializeObject<WithdrawSellOfferResponseModel>(resp);
                watch.Stop();
                long TestTime = watch.ElapsedMilliseconds;
                //ret.tests = new List<Test>();
                if (response.execDetails.ExecTime == null || response.execDetails.DbTime == null || TestTime == null)
                {
                    response.execDetails.ExecTime = 0;
                    response.execDetails.DbTime = 0;
                    TestTime = 0;
                }
                //(new Test(0, testParam, USERID, (long)EndpointEnum.PUTSellOffer, response.execDetails.DbTime.Value, response.execDetails.ExecTimeValue, TestTime, DateTime.Now));
                //ret.tests.Add(new Test( testParam, USERID, (long)EndpointEnum.PUTSellOffer, response.execDetails.DbTime.Value, response.execDetails.ExecTime.Value, TestTime));
                TestRun.testsLis.Add(new Test(testParam, USERID, (long)EndpointEnum.PUTSellOffer, response.execDetails.DbTime.Value, TestTime, response.execDetails.ExecTime.Value));
            }
            catch (Exception e)
            {
                //ret.tests = new List<Test>();
                //ret.tests.Add(new Test( testParam, USERID, (long)EndpointEnum.PUTSellOffer, 0, 0, 0));
                TestRun.testsLis.Add(new Test(testParam, USERID, (long)EndpointEnum.PUTSellOffer, 0, 0, 0));
            }

            //  return ret;

        }
    }
}
