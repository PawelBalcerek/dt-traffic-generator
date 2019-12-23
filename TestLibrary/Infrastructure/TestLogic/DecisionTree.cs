using System;
using System.Collections.Generic;
using System.Text;

namespace TestLibrary.Infrastructure.TestLogic
{
    public class DecisionTree
    {
        public DecisionTree(int numOfRequest)
        {
            _numOfRequest = numOfRequest;
            treeNodesString = new List<string>();
            SecondStage();
        }

        int _numOfRequest;
        int[] secondStageDecysionTree = { 55, 35, 5, 5, 20, 0 };
        int[] thirdStageDecysionTree = { 15, 80, 5 };

        

       public  List<string> treeNodesString { get; set; }


        public void SecondStage()
        {
            int i = 0;
           
                
        
            //buyOffer sellOffer Resources companies Transaction LogOut
            // zliczenie wszystkich procentów do drzewa decyzyjnego
            int seconStage_buyOffer = secondStageDecysionTree[0];
            int seconStage_sellOffer = secondStageDecysionTree[0] + secondStageDecysionTree[1];
            int secondStage_Resources = secondStageDecysionTree[0] + secondStageDecysionTree[1] + secondStageDecysionTree[2];
            int secondStage_Companies = secondStageDecysionTree[0] + secondStageDecysionTree[1] + secondStageDecysionTree[2] + secondStageDecysionTree[3];
            int secondStage_Transaction = secondStageDecysionTree[0] + secondStageDecysionTree[1] + secondStageDecysionTree[2] + secondStageDecysionTree[3] + secondStageDecysionTree[4];
            int secondStage_logOut = secondStageDecysionTree[0] + secondStageDecysionTree[1] + secondStageDecysionTree[2] + secondStageDecysionTree[3] + secondStageDecysionTree[4] + secondStageDecysionTree[5];



           


            while (i < _numOfRequest)
            {
                i++;
                Random rand = new Random();
                int randNum = rand.Next(0, 100);


                if (randNum <= seconStage_buyOffer)
                {
                    //wywolanie funckji losujacej z buyOffer
                    ThirdStage_buyOffer();
                }
                else if (randNum <= seconStage_sellOffer)
                {
                    //wywołanie funkcji losujacej z sellOffer
                    ThirdStage_sellOffer();

                }
                else if (randNum <= secondStage_Resources)
                {

                    //
                    //ActionPathList.Add(treeNodes.RESOURCES);
                    treeNodesString.Add("WyswietlanieZasobow");
                }
                else if (randNum <= secondStage_Companies)
                {
                    //ActionPathList.Add(treeNodes.COMPANIES);
                    treeNodesString.Add("DodanieFirmy");
                }
                else if (randNum <= secondStage_Transaction)
                {
                    //ActionPathList.Add(treeNodes.TRANSACTION);
                    treeNodesString.Add("WyswietlanieTransakcji");
                }
                else if (randNum <= secondStage_logOut)
                {
                    //ActionPathList.Add(treeNodes.LOGOUT);
                    treeNodesString.Add("Wylogowanie");
                }
            }
        }


        /// <summary>
        /// funckja odpowiadajaca za wylosowanie akcji w buYOffer
        /// </summary>
        public void ThirdStage_buyOffer()
        {
            Random randThirdStage = new Random();
            int randNum = randThirdStage.Next(0, 100);
            int[] thirdStageDecysionTree = { 10, 45, 45 };
            int ThirdStage_show = thirdStageDecysionTree[0];
            int ThirdStage_add = thirdStageDecysionTree[0] + thirdStageDecysionTree[1];
            int TrirdStage_withdraw = thirdStageDecysionTree[0] + thirdStageDecysionTree[1] + thirdStageDecysionTree[2];

            if (randNum <= ThirdStage_show)
            {
                //ActionPathList.Add(treeNodes.SHOWBUYOFFER);
                treeNodesString.Add("WyswietlanieOfertKupna");
            }
            else if (randNum <= ThirdStage_add)
            {
                //ActionPathList.Add(treeNodes.ADDBUYOFFER);
                //ThirdStage_buyOffer_add();
                treeNodesString.Add("NowaOfertaKupna");
            }
            else if (randNum <= TrirdStage_withdraw)
            {
                // ActionPathList.Add(treeNodes.WITHDRAWBUYOFFER);
                //ThirdStage_buyOffer_withdraw();

                treeNodesString.Add("WycofanieOfertyKupna");
            }
            
        }

        /// <summary>
        /// funckja odpowiadajaca za wylosowanie akcji w sellOffer
        /// </summary>
        public void ThirdStage_sellOffer()
        {
            Random randThirdStage = new Random();
            int randNum = randThirdStage.Next(0, 100);
            int[] thirdStageDecysionTree = { 10, 45, 45 };
            int ThirdStage_show = thirdStageDecysionTree[0];
            int ThirdStage_add = thirdStageDecysionTree[0] + thirdStageDecysionTree[1];
            int TrirdStage_withdraw = thirdStageDecysionTree[0] + thirdStageDecysionTree[1] + thirdStageDecysionTree[2];

            if (randNum <= ThirdStage_show)
            {
                //ActionPathList.Add(treeNodes.SHOWSELLOFFER);
                //ThirdStage_sellOffer_show();
                treeNodesString.Add("WyswietlanieOfertSprzedazy");

            }
            else if (randNum <= ThirdStage_add)
            {
                treeNodesString.Add("NowaOfertaSprzedazy");
                //ActionPathList.Add(treeNodes.ADDSELLOFFER);
                //ThirdStage_sellOffer_add();
            }
            else if (randNum <= TrirdStage_withdraw)
            {

                treeNodesString.Add("WycofanieOfertySprzedazy");
                //ActionPathList.Add(treeNodes.WITHDRAWOFFER);
                //ThirdStage_sellOffer_withdraw();
            }
        }

     

    }

    
}
