using Newtonsoft.Json;
using System.IO;
using System.Net;
using TestLibrary.Infrastructure.TestLogic.API.Request.Company;
using TestLibrary.Infrastructure.TestLogic.API.Response.Companies;

namespace TestLibrary.Infrastructure.TestLogic.TestApiMethods
{
    class CompaniesMethod
    {

        public static CreateCompanyResponseModel POSTCompanies(string jwt, string name, int amount)
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(POST_URLs.AddCompanies);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + jwt);
            CreateCompanyRequest comapny = new CreateCompanyRequest();
            //comapny.name = "Ahacompany";
            //comapny.resourcesAmount = 1000;
            comapny.name = name;
            comapny.resourcesAmount = amount;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string output = JsonConvert.SerializeObject(comapny);
                streamWriter.Write(output);
            }

            string resp = "";
            var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                resp = result;
            }
            CreateCompanyResponseModel comp = new CreateCompanyResponseModel();
            comp = JsonConvert.DeserializeObject<CreateCompanyResponseModel>(resp);
            return comp;
        }

        public static GetCompaniesResponseModel GetCompanies(string token)
        {
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

                return comp;
                //Console.WriteLine(Environment.NewLine + result);
                //return result;
            }
        }
    }
}
