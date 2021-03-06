﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

        public static async Task POSTCompanies(long userId, long testParam, string jwt)
        {
            List<CompanyModel> ret = new List<CompanyModel>();
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
                var httpResponse = await httpWebRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync();

                    resp = result;
                }
                CreateCompanyResponseModel comp = new CreateCompanyResponseModel();
                comp = JsonConvert.DeserializeObject<CreateCompanyResponseModel>(resp);

                watch.Stop();
                long TestTime = watch.ElapsedMilliseconds;
                if (comp.execDetails.ExecTime == null || comp.execDetails.DbTime == null || TestTime == null)
                {
                    comp.execDetails.ExecTime = 0;
                    comp.execDetails.DbTime = 0;
                    TestTime = 0;
                }
                TestRun.testsLis.Add(new Test(testParam, userId, (long)EndpointEnum.AddCompanies, comp.execDetails.DbTime.Value, comp.execDetails.ExecTime.Value, TestTime));
            }
            catch (Exception e)
            {
                TestRun.testsLis.Add(new Test(testParam, userId, (long)EndpointEnum.AddCompanies, 0, 0, 0));
            }


        }

        public static async Task GetCompanies(long testParam, string token, long userId)
        {
            List<CompanyModel> ret = new List<CompanyModel>();
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                string resp = "";
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    client.Headers.Add("Authorization", "Bearer " + token);
                    var result = await client.DownloadStringTaskAsync(GET_URLs.GETCompanies).ConfigureAwait(true);
                    resp = result;
                    GetCompaniesResponseModel comp = new GetCompaniesResponseModel();
                    comp = JsonConvert.DeserializeObject<GetCompaniesResponseModel>(resp);

                    ret = new List<CompanyModel>();
                    watch.Stop();
                    long TestTime = watch.ElapsedMilliseconds;
                    if (comp.execDetails.ExecTime == null || comp.execDetails.DbTime == null || TestTime == null)
                    {
                        comp.execDetails.ExecTime = 0;
                        comp.execDetails.DbTime = 0;
                        TestTime = 0;
                    }

                    ret.AddRange(comp.Companies);

                    TestRun.testsLis.Add(new Test(testParam, userId, (long)EndpointEnum.GetCompanies, comp.execDetails.DbTime.Value, comp.execDetails.ExecTime.Value, TestTime));
                    TestRun.comp.Clear();
                    TestRun.comp.AddRange(ret);
                }
            }
            catch (Exception e)
            {
                TestRun.testsLis.Add(new Test(testParam, userId, (long)EndpointEnum.GetCompanies, 0, 0, 0));
            }


        }
    }
}
