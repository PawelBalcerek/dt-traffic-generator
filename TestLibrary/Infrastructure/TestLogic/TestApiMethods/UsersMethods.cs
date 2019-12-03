using Newtonsoft.Json;
using System.IO;
using System.Net;
using TestLibrary.Infrastructure.TestLogic.API.Request;
using TestLibrary.Infrastructure.TestLogic.API.Response.Users;

namespace TestLibrary.Infrastructure.TestLogic.TestApiMethods
{
    class UsersMethods
    {
        public static string RegisterUser(string email, string password, string name)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(POST_URLs.Register);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            //httpWebRequest.Headers.Add("Authorization", "Bearer " + jwt);
            RegisterRequest user = new RegisterRequest();
            user.email = email;
            user.password = password;
            user.name = name;
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string output = JsonConvert.SerializeObject(user);
                streamWriter.Write(output);
            }

            string resp = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                resp = result;
            }

            return resp;

        }

        public static int GetUserId(int v, string token)
        {
            string resp = "";
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                client.Headers.Add("Authorization", "Bearer " + token);
                var result = client.DownloadString(GET_URLs.GetUserData); //URI  
                resp = result;
                GetUserResponse user = new GetUserResponse();
                user = JsonConvert.DeserializeObject<GetUserResponse>(resp);

                return user.user.Id;
                //Console.WriteLine(Environment.NewLine + result);
                //return result;
            }

        }

        public static string GetJWT(string email, string password)
        {
            //var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://javatestai.ddns.net:8080/api/login");
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(POST_URLs.Login);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            LoginRequest user = new LoginRequest();
            user.email = email;
            user.password = password;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string output = JsonConvert.SerializeObject(user);
                streamWriter.Write(output);
            }

            string resp = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                resp = result;
            }

            LoginResponse login = new LoginResponse();
            login = JsonConvert.DeserializeObject<LoginResponse>(resp);

            return login.jwt.ToString();

        }
    }
}
