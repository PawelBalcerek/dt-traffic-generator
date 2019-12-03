using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Response.Transactions;
using TestLibrary.Infrastructure.TestLogic.TestDB;
using TestLibrary.Infrastructure.TestLogic.API.Response.Users;
using TestLibrary;
using TestLibrary.Infrastructure.TestLogic;

namespace TestLibrary.TestApiMethods
{
    class TransactionMethods
    {
        public static ReturnTransactions GetTransactions(int testParam, string token, int userID)
        {
            ReturnTransactions ret = new ReturnTransactions();
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
                    var result = client.DownloadString(GET_URLs.Transactions); //URI  
                    resp = result;
                    GetTransactionsByUserIdResponseModel transactions = new GetTransactionsByUserIdResponseModel();
                    transactions = JsonConvert.DeserializeObject<GetTransactionsByUserIdResponseModel>(resp);

                    ret.tests = new List<Test>();
                    ret.Transaction = new List<TransactionModel>();
                    watch.Stop();
                    long TestTime = watch.ElapsedMilliseconds;
                    if (transactions.ExecDetails.ExecTime == null || transactions.ExecDetails.DbTime == null ||
                        TestTime == null)
                    {
                        transactions.ExecDetails.ExecTime = 0;
                        transactions.ExecDetails.DbTime = 0;
                        TestTime = 0;
                    }

                    ret.tests.Add(new Test(DateTime.Now, testParam, userID, (int)EndpointEnum.GetTrasactions,
                        transactions.ExecDetails.DbTime.Value, TestTime, transactions.ExecDetails.ExecTime.Value));

                    ret.Transaction.AddRange(transactions.Transactions);

                    TestRun.testsLis.AddRange(ret.tests);


                    TestRun.user.Where(u => u.userId == userID).ToList().ForEach(ug => ug.userTransctions = ret.Transaction);

                    //   Program.user.Where(u => u.userId == userID).ToList().ForEach(ug => ug.userResources = ret.res);
                }
            }
            catch (Exception e)
            {
                ret.tests = new List<Test>();

                ret.tests.Add(new Test(DateTime.Now, testParam, userID, (int)EndpointEnum.GetTrasactions,
                    0, 0, 0));

                TestRun.testsLis.AddRange(ret.tests);
            }

            return ret;
            //Console.WriteLine(Environment.NewLine + result);
            //return result;
        }
    }
}
