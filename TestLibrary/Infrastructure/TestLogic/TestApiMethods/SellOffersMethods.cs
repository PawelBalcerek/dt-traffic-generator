using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Serilog;
using TestLibrary;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Request;
using TestLibrary.Infrastructure.TestLogic.API.Request.SellOffers;
using TestLibrary.Infrastructure.TestLogic.API.Response.SellOffers;
using TestLibrary.Infrastructure.TestLogic.API.Response.Users;
using TestLibrary.Infrastructure.TestLogic.TestDB;


namespace testdll.TestApiMethods
{
    class SellOffersMethods
    {
        public static ReturnGetSellOffers GetUserSellOffers(int paramId, int userId, string token)
        {
            ReturnGetSellOffers returnedSellOffers = new ReturnGetSellOffers();
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                string resp = "";
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");
                    client.Headers.Add("Authorization", "Bearer " + token);
                    var result = client.DownloadString(GET_URLs.SellOffers); //URI  
                    resp = result;
                    GetSellOffersByUserIdResponseModel response = new GetSellOffersByUserIdResponseModel();
                    response = JsonConvert.DeserializeObject<GetSellOffersByUserIdResponseModel>(resp);
                    returnedSellOffers.tests = new List<Test>();
                    returnedSellOffers.sell = new List<SellOfferModel>();
                    returnedSellOffers.sell.AddRange(response.SellOffers);
                    watch.Stop();
                    long TestTime = watch.ElapsedMilliseconds;
                    if (response.ExecDetails.ExecTime == null || response.ExecDetails.DbTime == null ||
                        TestTime == null)
                    {
                        response.ExecDetails.ExecTime = 0;
                        response.ExecDetails.DbTime = 0;
                        TestTime = 0;
                    }

                    returnedSellOffers.tests.Add(new Test(DateTime.Now, paramId, userId, (int) EndpointEnum.GetSellOffers,
                        response.ExecDetails.DbTime.Value, TestTime, response.ExecDetails.ExecTime.Value));
                    Program.testsLis.AddRange(returnedSellOffers.tests);


                    Program.user.Where(u => u.userId == userId).ToList()
                        .ForEach(ug => ug.userSellOffers = returnedSellOffers.sell);

                }
            }
            catch (Exception e)
            {
                returnedSellOffers.tests = new List<Test>();
                returnedSellOffers.tests.Add(new Test(DateTime.Now, paramId, userId, (int) EndpointEnum.GetSellOffers,
                    0, 0, 0));
                Program.testsLis.AddRange(returnedSellOffers.tests);
            }


        

            return returnedSellOffers;
        }

        public static ReturnAddSellOffers AddSellOffer(int testParam, string token, int USERID, double minSellPrice, double maxSellPrice)
        {
            ReturnAddSellOffers ret = new ReturnAddSellOffers();
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();


                Random random = new Random();
                int amount = random.Next(1, 50);
                double price = random.Next((int)minSellPrice, (int)maxSellPrice);
                List<ResourceModel> userResources = new List<ResourceModel>();
                List<int> IdUserResources = new List<int>();


                foreach (var x in Program.user)
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
                    streamWriter.Write(output);
                }

                string resp = "";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    resp = result;
                }
                CreateSellOfferResponseModel response = new CreateSellOfferResponseModel();
                response = JsonConvert.DeserializeObject<CreateSellOfferResponseModel>(resp);
                watch.Stop();
                long TestTime = watch.ElapsedMilliseconds;
                ret.tests = new List<Test>();
                if (response.ExecDetails.ExecTime == null || response.ExecDetails.DbTime == null || TestTime == null)
                {
                    response.ExecDetails.ExecTime = 0;
                    response.ExecDetails.DbTime = 0;
                    TestTime = 0;
                }
                ret.tests.Add(new Test(DateTime.Now, testParam, USERID, (int)EndpointEnum.AddSellOffer, response.ExecDetails.DbTime.Value, TestTime, response.ExecDetails.ExecTime.Value));
                Program.testsLis.AddRange(ret.tests);
            }
            catch (Exception e)
            {
                ret.tests = new List<Test>();
                ret.tests.Add(new Test(DateTime.Now, testParam, USERID, (int)EndpointEnum.AddSellOffer, 0, 0, 0));
                Program.testsLis.AddRange(ret.tests);
            }
            
            return ret;

        }

        public static ReturnPUTSellOffers PutSellOffers(int testParam, string token, int USERID)
        {
            ReturnPUTSellOffers ret = new ReturnPUTSellOffers();
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();


                Random random = new Random();


                List<SellOfferModel> userSellOffers = new List<SellOfferModel>();
                List<int> IdUserSellOffers = new List<int>();


                foreach (var x in Program.user)
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
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    resp = result;
                }
                WithdrawSellOfferResponseModel response = new WithdrawSellOfferResponseModel();
                response = JsonConvert.DeserializeObject<WithdrawSellOfferResponseModel>(resp);
                watch.Stop();
                long TestTime = watch.ElapsedMilliseconds;
                ret.tests = new List<Test>();
                if (response.ExecDetails.ExecTime == null || response.ExecDetails.DbTime == null || TestTime == null)
                {
                    response.ExecDetails.ExecTime = 0;
                    response.ExecDetails.DbTime = 0;
                    TestTime = 0;
                }
                ret.tests.Add(new Test(DateTime.Now, testParam, USERID, (int)EndpointEnum.PUTSellOffer, response.ExecDetails.DbTime.Value, TestTime, response.ExecDetails.ExecTime.Value));
                Program.testsLis.AddRange(ret.tests);
            }
            catch (Exception e)
            {
                ret.tests = new List<Test>();
                ret.tests.Add(new Test(DateTime.Now, testParam, USERID, (int)EndpointEnum.PUTSellOffer, 0, 0, 0));
                Program.testsLis.AddRange(ret.tests);
            }
            
            return ret;

        }
    }
}
