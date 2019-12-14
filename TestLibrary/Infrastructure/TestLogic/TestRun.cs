using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TestLibrary.BusinessObject;
using TestLibrary.Creators.Abstract;
using TestLibrary.Infrastructure.Common.Const;
using TestLibrary.Infrastructure.TestInfrastructure.Abstract;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
//using TestLibrary.Infrastructure.TestLogic.TestApiMethods;
using TestLibrary.TestApiMethods;


namespace TestLibrary.Infrastructure.TestLogic
{
    public class TestRun : ITestRun
    {
        private readonly ITestsCreator _testsCreator;
        public TestRun(ITestsCreator testsCreator)
        {
            _testsCreator = testsCreator;
        }


        public static List<Test> testsLis = new List<Test>();
        public static List<CompanyModel> comp = new List<CompanyModel>();
        public static List<UserGenerator> user = new List<UserGenerator>();
        public static List<string> listaAkcji = new List<string> { "Logowanie z pobraniem informacji o userze" };
        public List<Test> TestMain(TestParameters testsParameters)
        {
            // Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //.WriteTo.Console()
            //     .WriteTo.File("logs\\.txt", rollingInterval: RollingInterval.Minute)
            //   .CreateLogger();

            //TestParameters tp = new TestParameters(20, "x", 10, 10, 20, 20, 30);
            
            RunFirst(testsParameters);

            foreach (var akcja in listaAkcji)
            {
                Log.Information(akcja);
            }
            //foreach (var u in user)
            //{
            //    Log.Information(u.userToken);
            //}

            //foreach (var test in testsLis)
            //{
            //    if (test != null)
            //    {
            //        Log.Information(test.TimeStamp.ToLongTimeString()+"." + test.TimeStamp.Millisecond);
            //        Log.Information(test.TestParametersId + ", " + test.TestId + ", " + test.UserId + ", " + test.EndpointId + ", " + test.ApiTestTime + ", " + test.DatabaseTestTime + ", " + test.ApplicationTestTime);

            //        //                    //Log.Information("TimeStamp: " + test.TestTime + "." + test.TestTime.Millisecond);
            //        //                    Log.Information("TestParam: " + test.TestParametersId);
            //        //Log.Information("TestId: " + test.TestId);
            //        //Log.Information("UserId: " + test.UserId);
            //        //Log.Information("EndpointId: " + test.EndpointId);
            //        //Log.Information("API_Time: " + test.ApiTestTime / 1000);
            //        //Log.Information("DB_Time: " + test.DatabaseTestTime / 1000);
            //        //Log.Information("Apl_Time: " + test.ApplicationTestTime);

            //        //Log.Debug("");
            //    }
            //    else
            //    {
            //        Log.Error("NULL");

            //    }
            //}
            //foreach (var c in TestRun.comp)
            //{

            //    Log.Information("Company:   " + c.Id + "   " + c.Name);

            //}
            //Log.CloseAndFlush();
            return testsLis;
        }


        public  async Task<List<Test>> RunFirst(TestParameters testParams)
        {
            TestParameters tp = testParams;
            
            var watch = System.Diagnostics.Stopwatch.StartNew();
            UserGenerator.CreateListOfUsers(tp.NumberOfUsers);

            List<UserGenerator> ug = TestRun.user;

            List<Task> generateUserList = new List<Task>();

            for (int i = 0; i < ug.Count; i++)
            {
                generateUserList.Add(new UGAction(ug[i],tp).userGenerator());
            }

            Task.WaitAll(generateUserList.ToArray());

            watch.Stop();
            long TestTime = watch.ElapsedMilliseconds;
            Log.Information(TestTime.ToString());




            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            List<Task> userTasks = new List<Task>();
            var reflection = typeof(UserActions);
            List<string> listOfMethods = reflection.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(method => method.IsPrivate).Select(method => method.Name).ToList();
            int indexWylogowywanie = listOfMethods.IndexOf("Wylogowanie");
            listOfMethods.RemoveAt(indexWylogowywanie);
            Random r = new Random();
            List<string> randomMethodorder = new List<string>();
            int j = 0;
            while (j < testParams.NumberOfRequests)
            {
                int number = r.Next(listOfMethods.Count);
                randomMethodorder.Add(listOfMethods[number]);
                j++;
                //listOfMethods.RemoveAt(number);
            }
            randomMethodorder.Add("Wylogowanie");

            for (int i = 0; i < ug.Count; i++)
            {
                userTasks.Add(new UserActions(ug[i],tp).Random(randomMethodorder));
            }
            listaAkcji.AddRange(randomMethodorder);
            Task.WaitAll(userTasks.ToArray());



            watch2.Stop();
            long TestTime2 = watch2.ElapsedMilliseconds;
            Log.Information(TestTime2.ToString());



            return testsLis;
        }






    }

    


}



