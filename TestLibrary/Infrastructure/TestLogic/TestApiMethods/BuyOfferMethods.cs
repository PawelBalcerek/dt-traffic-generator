using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using TestLibrary.Infrastructure.TestLogic;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Request.BuyOffers;
using TestLibrary.Infrastructure.TestLogic.API.Request.SellOffers;
using TestLibrary.Infrastructure.TestLogic.API.Request.BuyOffers;
using TestLibrary.Infrastructure.TestLogic.API.Request.SellOffers;


using TestLibrary.Infrastructure.TestLogic.API.Request.Company;
using TestLibrary.Infrastructure.TestLogic.API.Response.BuyOffers;
using System.Threading.Tasks;
using TestLibrary.BusinessObject;

namespace TestLibrary.TestApiMethods
{
    class BuyOfferMethods
    {
        public static async Task GetUserBuyOffers(long paramId, long userId, string token)
        {
            List<BuyOfferModel> returnedBuyOffers = new List<BuyOfferModel>();
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                string resp = "";
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    client.Headers.Add("Authorization", "Bearer " + token);
                    var result = await client.DownloadStringTaskAsync(GET_URLs.BuyOffers).ConfigureAwait(true);
                    resp = result;
                    GetBuyOffersByUserIdResponseModel response = new GetBuyOffersByUserIdResponseModel();
                    response = JsonConvert.DeserializeObject<GetBuyOffersByUserIdResponseModel>(resp);
                    returnedBuyOffers = new List<BuyOfferModel>();
                    returnedBuyOffers.AddRange(response.buyOffers);
                    watch.Stop();
                    long TestTime = watch.ElapsedMilliseconds;
                    if (response.execDetails.ExecTime == null || response.execDetails.DbTime == null ||
                        TestTime == null)
                    {
                        response.execDetails.ExecTime = 0;
                        response.execDetails.DbTime = 0;
                        TestTime = 0;
                    }
                    TestRun.testsLis.Add(new Test(paramId, userId, (long)EndpointEnum.GetBuyOffers, response.execDetails.DbTime.Value, response.execDetails.ExecTime.Value, TestTime));
                    TestRun.user.Where(u => u.userId == userId).ToList()
                        .ForEach(ug => ug.userBuyOffer = returnedBuyOffers);

                }
            }
            catch (Exception e)
            {
                TestRun.testsLis.Add(new Test(paramId, userId, (long)EndpointEnum.GetBuyOffers, 0, 0, 0));


            }

        }

        public static async Task AddBuyOffer(long testParam, string token, long USERID, double minBuyPrice, double maxBuyPrice)
        {
            List<BuyOfferModel> ret = new List<BuyOfferModel>();
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();


                Random random = new Random();
                int amount = random.Next(1, 50);
                double price = random.Next((int)minBuyPrice, (int)maxBuyPrice);
                List<CompanyModel> companies = new List<CompanyModel>();
                List<int> companiesId = new List<int>();

                companies = TestRun.comp;
                foreach (var x in companies)
                {
                    companiesId.Add(x.Id);
                }


                int companyId = companiesId[random.Next(0, companiesId.Count)];
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(POST_URLs.AddBuyOffers);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
                httpWebRequest.Method = "POST";

                CreateBuyOfferRequest BuyOfferRequest = new CreateBuyOfferRequest();
                BuyOfferRequest.companyId = companyId;
                BuyOfferRequest.amount = amount;
                BuyOfferRequest.price = price;
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string output = JsonConvert.SerializeObject(BuyOfferRequest);
                    await streamWriter.WriteAsync(output);
                }

                string resp = "";
                var httpResponse = await httpWebRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync();

                    resp = result;
                }
                CreateBuyOfferResponseModel response = new CreateBuyOfferResponseModel();
                response = JsonConvert.DeserializeObject<CreateBuyOfferResponseModel>(resp);
                watch.Stop();
                long TestTime = watch.ElapsedMilliseconds;
                // ret.tests = new List<Test>();
                if (response.execDetails.ExecTime == null || response.execDetails.DbTime == null || TestTime == null)
                {
                    response.execDetails.ExecTime = 0;
                    response.execDetails.DbTime = 0;
                    TestTime = 0;
                }
                TestRun.testsLis.Add(new Test(testParam, USERID, (long)EndpointEnum.AddBuyOffer, response.execDetails.DbTime.Value, response.execDetails.ExecTime.Value, TestTime));
            }
            catch (Exception e)
            {
                TestRun.testsLis.Add(new Test(testParam, USERID, (long)EndpointEnum.AddBuyOffer, 0, 0, 0));
            }
        }

        public static async Task PutBuyOffers(long testParam, string token, long USERID)
        {
            List<BuyOfferModel> ret = new List<BuyOfferModel>();
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();


                Random random = new Random();


                List<BuyOfferModel> userBuyOffers = new List<BuyOfferModel>();
                List<int> IdUserBuyOffers = new List<int>();


                foreach (var x in TestRun.user)
                {
                    if (x.userToken == token)
                    {
                        userBuyOffers = x.userBuyOffer;
                        foreach (var y in userBuyOffers)
                        {
                            if (y.IsValid == true)
                            {
                                IdUserBuyOffers.Add(y.Id);
                            }

                        }
                    }
                }

                int buyOfferId = IdUserBuyOffers[random.Next(0, IdUserBuyOffers.Count)];
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(PUT_URLs.WithdrawBuyOffers + buyOfferId.ToString());
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
                httpWebRequest.Method = "PUT";

                CreateBuyOfferRequest buyOfferRequest = new CreateBuyOfferRequest();

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
                WithdrawBuyOfferResponseModel response = new WithdrawBuyOfferResponseModel();
                response = JsonConvert.DeserializeObject<WithdrawBuyOfferResponseModel>(resp);
                watch.Stop();
                long TestTime = watch.ElapsedMilliseconds;

                if (response.execDetails.ExecTime == null || response.execDetails.DbTime == null || TestTime == null)
                {
                    response.execDetails.ExecTime = 0;
                    response.execDetails.DbTime = 0;
                    TestTime = 0;
                }
                TestRun.testsLis.Add(new Test(testParam, USERID, (long)EndpointEnum.PUTBuyOffer, response.execDetails.DbTime.Value, response.execDetails.ExecTime.Value, TestTime));
            }
            catch (Exception e)
            {
                TestRun.testsLis.Add(new Test(testParam, USERID, (long)EndpointEnum.PUTBuyOffer, 0, 0, 0));
            }

        }

    }
}
