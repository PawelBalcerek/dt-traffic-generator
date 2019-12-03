using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.TestDB;
using TestLibrary.Infrastructure.TestLogic.API;
using TestLibrary.Infrastructure.TestLogic;

namespace TestLibrary.TestApiMethods
{
    public class UserGenerator
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string userEmail { get; set; }
        public string userToken { get; set; }
        public int userId { get; set; }
        public double userCash { get; set; }
        public List<ResourceModel> userResources { get; set; }
        public List<SellOfferModel> userSellOffers { get; set; }
        public List<BuyOfferModel> userBuyOffer { get; set; }
        public List<TransactionModel> userTransctions { get; set; }




        public UserGenerator(string name, string password, string email, string token, int id, double cash,List<ResourceModel> resources, List<SellOfferModel> sellOffer, List<BuyOfferModel> buyOffer, List<TransactionModel> transactions)
        {
            userName = name;
            userPassword = password;
            userEmail = email;
            userToken = token;
            userId = id;
            userCash = cash;
            userResources = resources;
            userSellOffers = sellOffer;
            userBuyOffer = buyOffer;
            userTransctions = transactions;

        }


        public static ReturnUserGenerator userGenerator(int usernumber)
        {
            ReturnUserGenerator ret = new ReturnUserGenerator();

            List<UserGenerator> userGens = new List<UserGenerator>();


            string name2 = Guid.NewGuid().ToString().Substring(0, 5);
            string name = "cccc";
            for (int i = 1; i < usernumber + 1; i++)
            {
                userGens.Add(new UserGenerator(name + i, "pass", name + i + "@user.user", "", 0, 0, null, null, null, null));
            }

            List<Test> testy = new List<Test>();

            foreach (var x in userGens)
            {
                try
                {

                    ReturnLogin logRet = UsersMethods.GetJWT(1, x.userEmail.ToString(), x.userPassword.ToString());
                    string key = logRet.jwt;
                    ReturnUserInfo returnUserInfo = UsersMethods.GetUserId(0, key);
                    int id = returnUserInfo.id;
                    logRet.testy[0].UserId = id;
                    returnUserInfo.test[0].UserId = id;
                    testy.AddRange(logRet.testy);
                    testy.AddRange(returnUserInfo.test);


                    userGens.Where(u => u.userName == x.userName.ToString()).ToList()
                        .ForEach(ug => ug.userToken = key);
                    userGens.Where(u => u.userName == x.userName.ToString()).ToList().ForEach(ug => ug.userId = id);

                }
                catch (Exception e)
                {
                    ReturnRegistration registration = UsersMethods.RegisterUser(1, x.userEmail, x.userPassword, x.userName);

                    ReturnLogin logRet = UsersMethods.GetJWT(1, x.userEmail.ToString(), x.userPassword.ToString());
                    string key = logRet.jwt;

                    ReturnUserInfo returnUserInfo = UsersMethods.GetUserId(0, key);
                    int id = returnUserInfo.id;
                    double cash = returnUserInfo.cash;
                    registration.test[0].UserId = id;
                    logRet.testy[0].UserId = id;
                    returnUserInfo.test[0].UserId = id;
                    testy.AddRange(registration.test);
                    testy.AddRange(logRet.testy);
                    testy.AddRange(returnUserInfo.test);

                    userGens.Where(u => u.userName == x.userName.ToString()).ToList()
                        .ForEach(ug => ug.userToken = key);
                    userGens.Where(u => u.userName == x.userName.ToString()).ToList().ForEach(ug => ug.userId = id);
                    userGens.Where(u => u.userName == x.userName.ToString()).ToList().ForEach(ug => ug.userCash = cash);

                }


            }

            ret.userGenerators = userGens;
            ret.test = testy;
            TestRun.testsLis.AddRange(ret.test);
            TestRun.user.AddRange(ret.userGenerators);

            return ret;

        }
    }
}
