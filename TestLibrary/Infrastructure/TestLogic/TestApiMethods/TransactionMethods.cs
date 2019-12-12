using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Response.Transactions;
using TestLibrary.Infrastructure.TestLogic.API.Response.Users;
using TestLibrary;
using TestLibrary.Infrastructure.TestLogic;
using System.Threading.Tasks;
using TestLibrary.BusinessObject;

namespace TestLibrary.TestApiMethods
{
    class TransactionMethods
    {
        public static async Task GetTransactions(long testParam, string token, int userID)
        {
            List<TransactionModel> ret = new List<TransactionModel>();
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
                    var result = await client.DownloadStringTaskAsync(GET_URLs.Transactions).ConfigureAwait(false); //URI  
                    resp = result;
                    GetTransactionsByUserIdResponseModel transactions = new GetTransactionsByUserIdResponseModel();
                    transactions = JsonConvert.DeserializeObject<GetTransactionsByUserIdResponseModel>(resp);

                    //ret.tests = new List<Test>();
                    ret = new List<TransactionModel>();
                    watch.Stop();
                    long TestTime = watch.ElapsedMilliseconds;
                    if (transactions.ExecDetails.ExecTime == null || transactions.ExecDetails.DbTime == null ||
                        TestTime == null)
                    {
                        transactions.ExecDetails.ExecTime = 0;
                        transactions.ExecDetails.DbTime = 0;
                        TestTime = 0;
                    }
                    //(new Test(0, testParam, userID, (int)EndpointEnum.GetTrasactions, transactions.ExecDetails.DbTime.Value,  transactions.ExecDetails.ExecTime.Value, TestTime, DateTime.Now));
                    //ret.tests.Add(new Test( testParam, userID, (int)EndpointEnum.GetTrasactions, transactions.ExecDetails.DbTime.Value, transactions.ExecDetails.ExecTime.Value, TestTime));

                    ret.AddRange(transactions.Transactions);

                    TestRun.testsLis.Add(new Test(testParam, userID, (int)EndpointEnum.GetTrasactions, transactions.ExecDetails.DbTime.Value, transactions.ExecDetails.ExecTime.Value, TestTime));


                    TestRun.user.Where(u => u.userId == userID).ToList().ForEach(ug => ug.userTransctions = ret);

                    //   Program.user.Where(u => u.userId == userID).ToList().ForEach(ug => ug.userResources = ret.res);
                }
            }
            catch (Exception e)
            {
                //ret.tests = new List<Test>();
                ////(new Test(0, testParam, USERID, (int)EndpointEnum.PUTSellOffer, response.execDetails.DbTime.Value, response.execDetails.ExecTimeValue, TestTime, DateTime.Now));
                //ret.tests.Add(new Test( testParam, userID, (int)EndpointEnum.GetTrasactions, 0, 0, 0));

                TestRun.testsLis.Add(new Test(testParam, userID, (int)EndpointEnum.GetTrasactions, 0, 0, 0));
            }

            //  return ret;
            //Console.WriteLine(Environment.NewLine + result);
            //return result;
        }
    }
}
