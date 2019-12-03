using System;
using System.Collections.Generic;
using System.Text;

namespace TestLibrary.Infrastructure.TestLogic.TestDB
{
    enum EndpointEnum:int
    {
        GetUserInfo = 1 ,
        AddUser = 2,
        Login = 3,
        Logout = 4,
        GetCompanies = 5,
        AddCompanies = 6,
        GetUserResources = 7,
        GetSellOffers = 8,
        AddSellOffer = 9,
        PUTSellOffer = 10,
        GetBuyOffers = 11,
        AddBuyOffer = 12,
        PUTBuyOffer = 13,
        GetTrasactions = 14,
        ClearDatabase = 15,
        PurgeDatabase = 16,
        ChangeConfiguration = 17

    }
}
