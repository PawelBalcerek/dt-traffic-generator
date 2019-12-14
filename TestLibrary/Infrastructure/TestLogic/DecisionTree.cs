using System;
using System.Collections.Generic;
using System.Text;

namespace TestLibrary.Infrastructure.TestLogic
{
    class DecisionTree
    {

        int[] secondStageDecysionTree = { 50, 30, 5, 5, 20, 10 };
        int[] thirdStageDecysionTree = { 10, 70, 20 };

        List<treeNodes> ActionPathList;
        enum treeNodes
        {
            BUYOFFER = 1,
            SHOWBUYOFFER = 11,
            ADDBUYOFFER = 12,
            WITHDRAWBUYOFFER = 13,


            SELLOFFER = 2,
            SHOWSELLOFFER = 21,
            ADDSELLOFFER = 22,
            WITHDRAWOFFER = 23,

            RESOURCES = 3,

            COMPANIES = 4,

            TRANSACTION = 5,

            LOGOUT = 6
        };

        public void SecondStage()
        {
            //buyOffer sellOffer Resources companies Transaction LogOut
            // zliczenie wszystkich procentów do drzewa decyzyjnego
            int seconStage_buyOffer = secondStageDecysionTree[0];
            int seconStage_sellOffer = secondStageDecysionTree[0] + secondStageDecysionTree[1];
            int secondStage_Resources = secondStageDecysionTree[0] + secondStageDecysionTree[1] + secondStageDecysionTree[2];
            int secondStage_Companies = secondStageDecysionTree[0] + secondStageDecysionTree[1] + secondStageDecysionTree[2] + secondStageDecysionTree[3];
            int secondStage_Transaction = secondStageDecysionTree[0] + secondStageDecysionTree[1] + secondStageDecysionTree[2] + secondStageDecysionTree[3] + secondStageDecysionTree[4];
            int secondStage_logOut = secondStageDecysionTree[0] + secondStageDecysionTree[1] + secondStageDecysionTree[2] + secondStageDecysionTree[3] + secondStageDecysionTree[4] + secondStageDecysionTree[5];



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
                ActionPathList.Add(treeNodes.RESOURCES);
            }
            else if (randNum <= secondStage_Companies)
            {
                ActionPathList.Add(treeNodes.COMPANIES);
            }
            else if (randNum <= secondStage_Transaction)
            {
                ActionPathList.Add(treeNodes.TRANSACTION);
            }
            else if (randNum <= secondStage_logOut)
            {
                ActionPathList.Add(treeNodes.LOGOUT);
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
                ActionPathList.Add(treeNodes.SHOWBUYOFFER);
            }
            else if (randNum <= ThirdStage_add)
            {
                ActionPathList.Add(treeNodes.ADDBUYOFFER);
                //ThirdStage_buyOffer_add();
            }
            else if (randNum <= TrirdStage_withdraw)
            {
                ActionPathList.Add(treeNodes.WITHDRAWBUYOFFER);
                //ThirdStage_buyOffer_withdraw();
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
                ActionPathList.Add(treeNodes.SHOWSELLOFFER);
                //ThirdStage_sellOffer_show();
            }
            else if (randNum <= ThirdStage_add)
            {
                ActionPathList.Add(treeNodes.ADDSELLOFFER);
                //ThirdStage_sellOffer_add();
            }
            else if (randNum <= TrirdStage_withdraw)
            {
                ActionPathList.Add(treeNodes.WITHDRAWOFFER);
                //ThirdStage_sellOffer_withdraw();
            }
        }

        //tutaj bedzie wykonanie akcji wypenienia listy akcji, prawdopodobnie trzeba przeniesc w lepsze miesce

        void Generate_tree_path(int number_of_action)
        {
            for(int i = 0; i < number_of_action; i++)
            {
                SecondStage();
            }
        }

    }

    
}
