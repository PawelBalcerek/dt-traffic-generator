using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Test> TestMain(TestParameters testsParameters)
        {
            // Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //.WriteTo.Console()
            //     .WriteTo.File("logs\\.txt", rollingInterval: RollingInterval.Minute)
            //   .CreateLogger();

            //TestParameters tp = new TestParameters(20, "x", 10, 10, 20, 20, 30);
            
            RunFirst(testsParameters);


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

            for (int i = 0; i < ug.Count; i++)
            {
                userTasks.Add(new UserActions(ug[i],tp).PerformUserAction());
            }

            Task.WaitAll(userTasks.ToArray());



            watch2.Stop();
            long TestTime2 = watch2.ElapsedMilliseconds;
            Log.Information(TestTime2.ToString());



            return testsLis;
        }






    }

    public class UserActions
    {
        
        private UserGenerator _user = null;
        private TestParameters _testParameters = null;

        public UserActions(UserGenerator user, TestParameters testParams)
        {
            _user = user;
            _testParameters = testParams;
        }

        public async Task PerformUserAction()
        {

            await WyswietlanieOfertKupna();
          
            await NowaOfertaKupna();
            
            //await DodanieFirmy();
            await NowaOfertaSprzedazy();
            //await WycofanieOfertySprzedazy();
            await WyswietlanieOfertSprzedazy();
           
            //await WycofanieOfertyKupna();
            await WyswietlanieTransakcji();
            await WyswietlanieZasobów();
            await Wylogowanie();

            
           

        }

        public async Task WyswietlanieOfertKupna()
        {
            await BuyOfferMethods.GetUserBuyOffers(_testParameters.TestParametersId, _user.userId, _user.userToken);
        }
        public async Task NowaOfertaKupna()
        {
            await CompaniesMethod.GetCompanies(_testParameters.TestParametersId, _user.userToken, _user.userId);
            await BuyOfferMethods.AddBuyOffer(_testParameters.TestParametersId, _user.userToken, _user.userId, _testParameters.MinBuyPrice, _testParameters.MaxBuyPrice);
        }
        public async Task WycofanieOfertyKupna()
        {
            await BuyOfferMethods.GetUserBuyOffers(_testParameters.TestParametersId, _user.userId, _user.userToken);
            await BuyOfferMethods.PutBuyOffers(_testParameters.TestParametersId, _user.userToken, _user.userId);
            await BuyOfferMethods.GetUserBuyOffers(_testParameters.TestParametersId, _user.userId, _user.userToken);
        }

        public async Task DodanieFirmy()
        {
            await CompaniesMethod.POSTCompanies(_user.userId, _testParameters.TestParametersId, _user.userToken);
            await ResourcesMethods.GetResources(_testParameters.TestParametersId, _user.userToken);
        }
        public async Task WyswietlanieTransakcji()
        {
            await TransactionMethods.GetTransactions(_testParameters.TestParametersId, _user.userToken, _user.userId);
        }
        public async Task WyswietlanieZasobów()
        {
            await ResourcesMethods.GetResources(_testParameters.TestParametersId, _user.userToken);
        }
        public async Task WyswietlanieOfertSprzedazy()
        {
            await SellOffersMethods.GetUserSellOffers(_testParameters.TestParametersId, _user.userToken);
        }
        public async Task NowaOfertaSprzedazy()
        {
            await ResourcesMethods.GetResources(_testParameters.TestParametersId, _user.userToken);
            await SellOffersMethods.AddSellOffer(_testParameters.TestParametersId, _user.userToken, _testParameters.MinSellPrice, _testParameters.MaxSellPrice);
            await SellOffersMethods.GetUserSellOffers(_testParameters.TestParametersId, _user.userToken);
        }

        public async Task WycofanieOfertySprzedazy()
        {
            await SellOffersMethods.GetUserSellOffers(_testParameters.TestParametersId, _user.userToken);
            await SellOffersMethods.PutSellOffers(_testParameters.TestParametersId, _user.userToken, _user.userId);
        }
        public async Task Wylogowanie()
        {
            await UsersMethods.LogoutUser(_testParameters.TestParametersId , _user.userId, _user.userToken);
        }

    }


}



