using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using TestLibrary;
using TestLibrary.BusinessObject;
using TestLibrary.Infrastructure.TestLogic;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Request.Company;
using TestLibrary.Infrastructure.TestLogic.API.Response.Companies;

using TestLibrary.Infrastructure.TestLogic.Models;

namespace TestLibrary.TestApiMethods
{
    class CompaniesMethod
    {

        //public static CreateCompanyResponseModel POSTCompanies(int userId,int testParam, int testId, string jwt, string name, int amount)
        public static async Task POSTCompanies(int userId, int testParam, int testId, string jwt)
        {
            ReturnAddCompanies ret = new ReturnAddCompanies();
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();


                var httpWebRequest = (HttpWebRequest)WebRequest.Create(POST_URLs.AddCompanies);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + jwt);
                CreateCompanyRequest comapny = new CreateCompanyRequest();
                string guid = Guid.NewGuid().ToString().Substring(0, 6);
                string name = "u" + userId + "_" + guid + "_Company";
                Random rnd = new Random();
                int amount = rnd.Next(1000, 10000);

                comapny.name = name;
                comapny.resourceAmount = amount;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string output = JsonConvert.SerializeObject(comapny);
                    await streamWriter.WriteAsync(output);
                }

                string resp = "";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync();

                    resp = result;
                }
                CreateCompanyResponseModel comp = new CreateCompanyResponseModel();
                comp = JsonConvert.DeserializeObject<CreateCompanyResponseModel>(resp);

                ret.tests = new List<Test>();
                watch.Stop();
                long TestTime = watch.ElapsedMilliseconds;
                if (comp.execDetails.ExecTime == null || comp.execDetails.DbTime == null || TestTime == null)
                {
                    comp.execDetails.ExecTime = 0;
                    comp.execDetails.DbTime = 0;
                    TestTime = 0;
                }
                //(new Test(0, testParam, userId, (int)EndpointEnum.AddCompanies, comp.execDetails.DbTime.Value, comp.execDetails.ExecTime.Value, TestTime, DateTime.Now));
                ret.tests.Add(new Test( testParam, userId, (int)EndpointEnum.AddCompanies, comp.execDetails.DbTime.Value, comp.execDetails.ExecTime.Value, TestTime));
                TestRun.testsLis.AddRange(ret.tests);
            }
            catch (Exception e)
            {
                ret.tests = new List<Test>();
                ret.tests.Add(new Test( testParam, userId, (int)EndpointEnum.AddCompanies, 0, 0, 0));
                TestRun.testsLis.AddRange(ret.tests);
            }

            //return Task.CompletedTask;
        }

        public static async Task GetCompanies(int testParam, string token, int userId)
        {
            ReturnGetCompanies ret = new ReturnGetCompanies();
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
                    var result = await client.DownloadStringTaskAsync(GET_URLs.GETCompanies).ConfigureAwait(true); //URI  
                    resp = result;
                    GetCompaniesResponseModel comp = new GetCompaniesResponseModel();
                    comp = JsonConvert.DeserializeObject<GetCompaniesResponseModel>(resp);

                    ret.tests = new List<Test>();
                    ret.companies = new List<CompanyModel>();
                    watch.Stop();
                    long TestTime = watch.ElapsedMilliseconds;
                    if (comp.execDetails.ExecTime == null || comp.execDetails.DbTime == null || TestTime == null)
                    {
                        comp.execDetails.ExecTime = 0;
                        comp.execDetails.DbTime = 0;
                        TestTime = 0;
                    }
                    //(new Test(0, testParam, userId, (int)EndpointEnum.GetCompanies, comp.execDetails.DbTime.Value, comp.execDetails.ExecTime.Value, TestTime, DateTime.Now));
                    ret.tests.Add(new Test( testParam, userId, (int)EndpointEnum.GetCompanies, comp.execDetails.DbTime.Value, comp.execDetails.ExecTime.Value, TestTime));
                    ret.companies.AddRange(comp.Companies);

                    TestRun.testsLis.AddRange(ret.tests);
                    TestRun.comp.Clear();
                    TestRun.comp.AddRange(ret.companies);
                }
            }
            catch (Exception e)
            {
                ret.tests = new List<Test>();
                ret.tests.Add(new Test( testParam, userId, (int)EndpointEnum.GetCompanies, 0, 0, 0));
                TestRun.testsLis.AddRange(ret.tests);

                TestRun.testsLis.AddRange(ret.tests);
            }
            await Task.CompletedTask;
            //   return Task.CompletedTask;
            //Console.WriteLine(Environment.NewLine + result);
            //return result;

        }
    }
}
