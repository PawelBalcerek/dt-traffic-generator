using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestLibrary.BusinessObject;
using TestLibrary.TestApiMethods;

namespace TestLibrary.Infrastructure.TestLogic
{
    public class UserActions
    {

        private UserGenerator _user = null;
        private TestParameters _testParameters = null;

        public UserActions(UserGenerator user, TestParameters testParams)
        {
            _user = user;
            _testParameters = testParams;
        }

        public async Task Random(List<string> methods)
        {
            foreach (var method in methods)
            {
                await (Task)this.GetType().GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance).Invoke(this, null);
            }
        }

        private async Task WyswietlanieOfertKupna()
        {
            await BuyOfferMethods.GetUserBuyOffers(_testParameters.TestParametersId, _user.userId, _user.userToken);
        }
        private async Task NowaOfertaKupna()
        {
            await CompaniesMethod.GetCompanies(_testParameters.TestParametersId, _user.userToken, _user.userId);
            await BuyOfferMethods.AddBuyOffer(_testParameters.TestParametersId, _user.userToken, _user.userId, _testParameters.MinBuyPrice, _testParameters.MaxBuyPrice);
        }
        private async Task WycofanieOfertyKupna()
        {
            await BuyOfferMethods.GetUserBuyOffers(_testParameters.TestParametersId, _user.userId, _user.userToken);
            await BuyOfferMethods.PutBuyOffers(_testParameters.TestParametersId, _user.userToken, _user.userId);
            await BuyOfferMethods.GetUserBuyOffers(_testParameters.TestParametersId, _user.userId, _user.userToken);
        }

        private async Task DodanieFirmy()
        {
            await CompaniesMethod.POSTCompanies(_user.userId, _testParameters.TestParametersId, _user.userToken);
            await ResourcesMethods.GetResources(_testParameters.TestParametersId, _user.userToken);
        }
        private async Task WyswietlanieTransakcji()
        {
            await TransactionMethods.GetTransactions(_testParameters.TestParametersId, _user.userToken, _user.userId);
        }
        private async Task WyswietlanieZasobów()
        {
            await ResourcesMethods.GetResources(_testParameters.TestParametersId, _user.userToken);
        }
        private async Task WyswietlanieOfertSprzedazy()
        {
            await SellOffersMethods.GetUserSellOffers(_testParameters.TestParametersId, _user.userToken);
        }
        private async Task NowaOfertaSprzedazy()
        {
            await ResourcesMethods.GetResources(_testParameters.TestParametersId, _user.userToken);
            await SellOffersMethods.AddSellOffer(_testParameters.TestParametersId, _user.userToken, _testParameters.MinSellPrice, _testParameters.MaxSellPrice);
            await SellOffersMethods.GetUserSellOffers(_testParameters.TestParametersId, _user.userToken);
        }

        private async Task WycofanieOfertySprzedazy()
        {
            await SellOffersMethods.GetUserSellOffers(_testParameters.TestParametersId, _user.userToken);
            await SellOffersMethods.PutSellOffers(_testParameters.TestParametersId, _user.userToken, _user.userId);
        }
        private async Task Wylogowanie()
        {
            await UsersMethods.LogoutUser(_testParameters.TestParametersId, _user.userId, _user.userToken);
        }

    }
}
