using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestLibrary.Infrastructure.TestLogic.API.Objects;
using TestLibrary.Infrastructure.TestLogic.API;
using TestLibrary.Infrastructure.TestLogic;
using TestLibrary.TestApiMethods;
using System.Threading.Tasks;
using TestLibrary.BusinessObject;

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




        public UserGenerator(string name, string password, string email, string token, int id, double cash, List<ResourceModel> resources, List<SellOfferModel> sellOffer, List<BuyOfferModel> buyOffer, List<TransactionModel> transactions)
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

        public static void CreateListOfUsers(int numOfUsers)
        {
            List<UserGenerator> userGens = new List<UserGenerator>();


            string name2 = Guid.NewGuid().ToString().Substring(0, 5);
            string name = "cccc";
            for (int i = 1; i < numOfUsers + 1; i++)
            {
                userGens.Add(new UserGenerator(name + i, "pass", name + i + "@user.user", "", 0, 0, null, null, null, null));
            }

            TestRun.user = userGens;
        }





    }


}

public class UGAction
{
    private UserGenerator _user = null;
    private TestParameters _testParameters = null;

    public UGAction(UserGenerator user, TestParameters testParams)
    {
        _user = user;
        _testParameters = testParams;
    }
    public async Task userGenerator()
    {



        try
        {

            
            await UsersMethods.GetJWT(_testParameters.TestParametersId, _user.userEmail, _user.userPassword);
            await UsersMethods.GetUserId(_testParameters.TestParametersId, _user.userToken);

        }
        catch (Exception e)
        {

            await UsersMethods.RegisterUser(_testParameters.TestParametersId, _user.userEmail, _user.userPassword, _user.userName);
            await UsersMethods.GetJWT(_testParameters.TestParametersId, _user.userEmail, _user.userPassword);
            await UsersMethods.GetUserId(_testParameters.TestParametersId, _user.userToken);




        }
    }
}