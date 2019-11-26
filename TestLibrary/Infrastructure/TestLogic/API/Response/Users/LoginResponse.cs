using TestLibrary.Infrastructure.TestLogic.API.Response.ExecutingTimes;

namespace TestLibrary.Infrastructure.TestLogic.API.Response.Users
{
    public class LoginResponse
    {
        /// <summary>
        /// Token
        /// </summary>
       // [JsonProperty("jwt")]
        public string jwt { get; set; }
        public ExecutionDetails ExecDetails { get; set; }
    }
}
