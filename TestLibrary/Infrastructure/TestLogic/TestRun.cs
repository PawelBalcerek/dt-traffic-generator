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

        public void TestMain()
        {
            // Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //.WriteTo.Console()
            //     .WriteTo.File("logs\\.txt", rollingInterval: RollingInterval.Minute)
            //   .CreateLogger();


            RunFirst(11, 1, 50, 10, 10, 20, 10, 20);


            foreach (var u in user)
            {
                Log.Information(u.userToken);
            }

            foreach (var test in testsLis)
            {
                if (test != null)
                {
                    Log.Information(test.TestParametersId + ", " + test.TestId + ", " + test.UserId + ", " + test.EndpointId + ", " + test.ApiTestTime + ", " + test.DatabaseTestTime + ", " + test.ApplicationTestTime);

                    //                    //Log.Information("TimeStamp: " + test.TestTime + "." + test.TestTime.Millisecond);
                    //                    Log.Information("TestParam: " + test.TestParametersId);
                    //Log.Information("TestId: " + test.TestId);
                    //Log.Information("UserId: " + test.UserId);
                    //Log.Information("EndpointId: " + test.EndpointId);
                    //Log.Information("API_Time: " + test.ApiTestTime / 1000);
                    //Log.Information("DB_Time: " + test.DatabaseTestTime / 1000);
                    //Log.Information("Apl_Time: " + test.ApplicationTestTime);

                    //Log.Debug("");
                }
                else
                {
                    Log.Error("NULL");

                }
            }
            foreach (var c in TestRun.comp)
            {

                Log.Information("Company:   " + c.Id + "   " + c.Name);

            }
            Log.CloseAndFlush();
        }


        public static async Task RunFirst(int testId, int paramId, int numOfUsers, int numOfReq, double minBuyPrice, double maxBuyPrice,
           double minSellPrice, double maxSellPrice)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();
            UserGenerator.CreateListOfUsers(numOfUsers);

            List<UserGenerator> ug = TestRun.user;

            List<Task> generateUserList = new List<Task>();

            for (int i = 0; i < ug.Count; i++)
            {
                generateUserList.Add(new UGAction(ug[i]).userGenerator());
            }

            Task.WaitAll(generateUserList.ToArray());

            watch.Stop();
            long TestTime = watch.ElapsedMilliseconds;
            Log.Information(TestTime.ToString());




            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            List<Task> userTasks = new List<Task>();

            for (int i = 0; i < ug.Count; i++)
            {
                userTasks.Add(new UserActions(ug[i]).PerformUserAction());
            }

            Task.WaitAll(userTasks.ToArray());



            watch2.Stop();
            long TestTime2 = watch2.ElapsedMilliseconds;
            Log.Information(TestTime2.ToString());




        }






    }

    public class UserActions
    {
        //private List<ResourceModel> _resources = new List<ResourceModel>();
        private UserGenerator _user = null;

        public UserActions(UserGenerator user)
        {
            _user = user;
        }

        public async Task PerformUserAction()
        {

            await WyswietlanieOfertKupna();
            //await DodanieFirmy();
            //await NowaOfertaKupna();
            //await WyswietlanieOfertKupna();
            //await DodanieFirmy();
            await WyswietlanieOfertSprzedazy();
            // await NowaOfertaKupna();
            //await WycofanieOfertyKupna();
            await WyswietlanieTransakcji();
            await WyswietlanieZasobów();
            await Wylogowanie();

            //await DodanieFirmy();
            //await NowaOfertaKupna();
            //await WyswietlanieOfertKupna();
            // await ResourcesMethods.GetResources(0, _user.userToken);
            // // await SellOffersMethods.AddSellOffer(0, _user.userToken, _user.userId, 20, 50);
            // await SellOffersMethods.GetUserSellOffers(0, _user.userToken);
            // await ResourcesMethods.GetResources(0, _user.userToken);

            // ///await CompaniesMethod.POSTCompanies(_user.userId, 0, 0, _user.userToken);
            // await CompaniesMethod.GetCompanies(0, _user.userToken, _user.userId);

            //// await SellOffersMethods.AddSellOffer(0,_user.userToken,20,30);
            //// await SellOffersMethods.AddSellOffer(0,_user.userToken,60,90);
            // await SellOffersMethods.PutSellOffers(0, _user.userToken, _user.userId);

            // await SellOffersMethods.GetUserSellOffers(0, _user.userToken);
            // //await BuyOfferMethods.GetUserBuyOffers(0, _user.userId, _user.userToken);
            // //await BuyOfferMethods.AddBuyOffer(0, _user.userToken,_user.userId, 20, 30);
            // //await BuyOfferMethods.AddBuyOffer(0, _user.userToken, _user.userId, 60, 90);
            // //await BuyOfferMethods.PutBuyOffers(0, _user.userToken, _user.userId);

            // await BuyOfferMethods.GetUserBuyOffers(0, _user.userId, _user.userToken);

            // await TransactionMethods.GetTransactions(0, _user.userToken, _user.userId);
            // await ResourcesMethods.GetResources(0, _user.userToken);

        }

        public async Task WyswietlanieOfertKupna()
        {
            await BuyOfferMethods.GetUserBuyOffers(0, _user.userId, _user.userToken);
        }
        public async Task NowaOfertaKupna()
        {
            await CompaniesMethod.GetCompanies(0, _user.userToken, _user.userId);
            await BuyOfferMethods.AddBuyOffer(0, _user.userToken, _user.userId, 20, 30);
        }
        public async Task WycofanieOfertyKupna()
        {
            await BuyOfferMethods.GetUserBuyOffers(0, _user.userId, _user.userToken);
            await BuyOfferMethods.PutBuyOffers(0, _user.userToken, _user.userId);
            await BuyOfferMethods.GetUserBuyOffers(0, _user.userId, _user.userToken);
        }

        public async Task DodanieFirmy()
        {
            await CompaniesMethod.POSTCompanies(_user.userId, 0, 0, _user.userToken);
            await ResourcesMethods.GetResources(0, _user.userToken);
        }
        public async Task WyswietlanieTransakcji()
        {
            await TransactionMethods.GetTransactions(0, _user.userToken, _user.userId);
        }
        public async Task WyswietlanieZasobów()
        {
            await ResourcesMethods.GetResources(0, _user.userToken);
        }
        public async Task WyswietlanieOfertSprzedazy()
        {
            await SellOffersMethods.GetUserSellOffers(0, _user.userToken);
        }
        public async Task NowaOfertaSprzedazy()
        {
            await ResourcesMethods.GetResources(0, _user.userToken);
            await SellOffersMethods.AddSellOffer(0, _user.userToken, 20, 50);
            await SellOffersMethods.GetUserSellOffers(0, _user.userToken);
        }

        public async Task WycofanieOfertySprzedazy()
        {
            await SellOffersMethods.GetUserSellOffers(0, _user.userToken);
            await SellOffersMethods.PutSellOffers(0, _user.userToken, _user.userId);
        }
        public async Task Wylogowanie()
        {
            await UsersMethods.LogoutUser(0, _user.userId, _user.userToken);
        }

    }


}



