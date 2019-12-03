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
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()   
                .WriteTo.Console()
                .WriteTo.File("logs\\.txt", rollingInterval: RollingInterval.Minute)
                .CreateLogger();


            RunFirst(1, 3, 10, 10, 20, 10, 20);

            foreach (var test in testsLis)
            {
                Log.Information("TimeStamp: " + test.TestTime);
                Log.Information("TestParam: " + test.TestParametersId);
                Log.Information("TestId: " + test.TestId);
                Log.Information("UserId: " + test.UserId);
                Log.Information("EndpointId: " + test.EndpointId);
                Log.Information("API_Time: " + test.ApiTestTime);
                Log.Information("DB_Time: " + test.DatabaseTestTime);
                Log.Information("Apl_Time: " + test.ApplicationTestTime);
                Log.Debug("");
            }

            foreach (var c in TestRun.comp)
            {

                Log.Information("Company:   " + c.Id + "   " + c.Name);

            }
            Log.CloseAndFlush();

        }


        public static void RunFirst(int paramId, int numOfUsers, int numOfReq, double minBuyPrice, double maxBuyPrice, double minSellPrice, double maxSellPrice)
        {
            // Console.WriteLine("Userzy: ");
            ReturnUserGenerator ug = UserGenerator.userGenerator(numOfUsers);
            foreach (var x in ug.userGenerators)
            {


                //ReturnAddCompanies addcomp = CompaniesMethod.POSTCompanies(x.userId, paramId, 1, x.userToken);
                ReturnResources returnResources = ResourcesMethods.GetResources(paramId, x.userToken, x.userId);
                ReturnGetCompanies returnGetCompanies = CompaniesMethod.GetCompanies(paramId, x.userToken, x.userId);
                ReturnGetSellOffers returnGetSellOffers = SellOffersMethods.GetUserSellOffers(paramId, x.userId, x.userToken);
                //ReturnAddSellOffers addSellOffers = SellOffersMethods.AddSellOffer(paramId, x.userToken, x.userId, minSellPrice, maxSellPrice);
                ReturnGetSellOffers returnGetSellOffers2 = SellOffersMethods.GetUserSellOffers(paramId, x.userId, x.userToken);
                ReturnTransactions returnTransactions =
                    TransactionMethods.GetTransactions(paramId, x.userToken, x.userId);

                //// ReturnPUTSellOffers putSellOffers = SellOffersMethods.PutSellOffers(paramId, x.userToken, x.userId);
                //ReturnGetBuyOffers returnGetBuyOffers = BuyOfferMethods.GetUserBuyOffers(paramId, x.userId, x.userToken);
                //ReturnAddBuyOffers returnAddBuyOffers = BuyOfferMethods.AddBuyOffer(paramId, x.userToken, x.userId, minBuyPrice, maxBuyPrice);
                //ReturnPUTBuyOffers returnPutBuyOffers = BuyOfferMethods.PutBuyOffers(paramId, x.userToken, x.userId);

                //UsersMethods.LogoutUser(paramId, x.userId, x.userToken);
                //Log.Information(x.userId + " - " + returnGetCompanies.companies.Count);

                //Console.WriteLine(x.userId + " - " + returnGetCompanies.companies.Count);
            }



        }



        

    }



  

}

