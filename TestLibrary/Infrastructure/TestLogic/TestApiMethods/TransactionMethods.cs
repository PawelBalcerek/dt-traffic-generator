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
        public static async Task GetTransactions(long testParam, string token, long userID)
        {
            List<TransactionModel> ret = new List<TransactionModel>();
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                string resp = "";
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    client.Headers.Add("Authorization", "Bearer " + token);
                    var result = await client.DownloadStringTaskAsync(GET_URLs.Transactions).ConfigureAwait(false);
                    resp = result;
                    GetTransactionsByUserIdResponseModel transactions = new GetTransactionsByUserIdResponseModel();
                    transactions = JsonConvert.DeserializeObject<GetTransactionsByUserIdResponseModel>(resp);

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
                    ret.AddRange(transactions.Transactions);

                    TestRun.testsLis.Add(new Test(testParam, userID, (long)EndpointEnum.GetTrasactions, transactions.ExecDetails.DbTime.Value, transactions.ExecDetails.ExecTime.Value, TestTime));
                    TestRun.user.Where(u => u.userId == userID).ToList().ForEach(ug => ug.userTransctions = ret);

                }
            }
            catch (Exception e)
            {

                TestRun.testsLis.Add(new Test(testParam, userID, (long)EndpointEnum.GetTrasactions, 0, 0, 0));
            }


        }
    }
}
