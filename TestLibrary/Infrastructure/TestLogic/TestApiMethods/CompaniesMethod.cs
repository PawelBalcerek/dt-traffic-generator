using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
//using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using TestLibrary;
using TestLibrary.Infrastructure.TestLogic;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API.Request.Company;
using TestLibrary.Infrastructure.TestLogic.API.Response.Companies;

using TestLibrary.Infrastructure.TestLogic.Models;
using TestLibrary.Infrastructure.TestLogic.TestDB;

namespace TestLibrary.TestApiMethods
{
    class CompaniesMethod
    {

        //public static CreateCompanyResponseModel POSTCompanies(int userId,int testParam, int testId, string jwt, string name, int amount)
        public static ReturnAddCompanies POSTCompanies(int userId, int testParam, int testId, string jwt)
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
                    streamWriter.Write(output);
                }

                string resp = "";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    resp = result;
                }
                CreateCompanyResponseModel comp = new CreateCompanyResponseModel();
                comp = JsonConvert.DeserializeObject<CreateCompanyResponseModel>(resp);

                ret.tests = new List<Test>();
                watch.Stop();
                long TestTime = watch.ElapsedMilliseconds;
                if (comp.ExecDetails.ExecTime == null || comp.ExecDetails.DbTime == null || TestTime == null)
                {
                    comp.ExecDetails.ExecTime = 0;
                    comp.ExecDetails.DbTime = 0;
                    TestTime = 0;
                }
                ret.tests.Add(new Test(DateTime.Now, testParam, userId, (int)EndpointEnum.AddCompanies, comp.ExecDetails.DbTime.Value, TestTime, comp.ExecDetails.ExecTime.Value));
                TestRun.testsLis.AddRange(ret.tests);
                //TestRun
            }
            catch (Exception e)
            {
                ret.tests = new List<Test>();
                ret.tests.Add(new Test(DateTime.Now, testParam, userId, (int)EndpointEnum.AddCompanies, 0, 0, 0));
                TestRun.testsLis.AddRange(ret.tests);
            }

            return ret;
        }

        public static ReturnGetCompanies GetCompanies(int testParam, string token, int userId)
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
                    var result = client.DownloadString(GET_URLs.GETCompanies); //URI  
                    resp = result;
                    GetCompaniesResponseModel comp = new GetCompaniesResponseModel();
                    comp = JsonConvert.DeserializeObject<GetCompaniesResponseModel>(resp);

                    ret.tests = new List<Test>();
                    ret.companies = new List<CompanyModel>();
                    watch.Stop();
                    long TestTime = watch.ElapsedMilliseconds;
                    if (comp.ExecDetails.ExecTime == null || comp.ExecDetails.DbTime == null || TestTime == null)
                    {
                        comp.ExecDetails.ExecTime = 0;
                        comp.ExecDetails.DbTime = 0;
                        TestTime = 0;
                    }

                    ret.tests.Add(new Test(DateTime.Now, testParam, userId, (int)EndpointEnum.GetCompanies,
                        comp.ExecDetails.DbTime.Value, TestTime, comp.ExecDetails.ExecTime.Value));
                    ret.companies.AddRange(comp.Companies);

                    TestRun.testsLis.AddRange(ret.tests);
                    TestRun.comp.Clear();
                    TestRun.comp.AddRange(ret.companies);
                }
            }
            catch (Exception e)
            {
                ret.tests = new List<Test>();
                ret.tests.Add(new Test(DateTime.Now, testParam, userId, (int)EndpointEnum.GetCompanies,
                    0, 0, 0));
                TestRun.testsLis.AddRange(ret.tests);

                TestRun.testsLis.AddRange(ret.tests);
            }

            return ret;
            //Console.WriteLine(Environment.NewLine + result);
            //return result;

        }
    }
}
