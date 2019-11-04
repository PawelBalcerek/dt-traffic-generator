/*Kod apliakcji generujacej obciazenie na serwerze
 * Autor: Kuczman Kamil
 * Data ostatniej aktualizacji 4.11.2019
 * aktualna wersja oprogramowania: 1.2
 * 
 * zaimplementowane funkcjonalności:
 * -generowanie losowej liczby w celu sprawdzenia roznych etapów/drzewek sciezek łaczenia z baza danych     (version 1.0)
 * -licznik do zliczania czasu operacji                                                                     (version 1.0)
 * -ustawienia żądania GET(pobranie całego HTML)                                                            (version 1.0)
 * -wyslanie okreslonej  ilosci zadąń w czasie minuty (np 60,120,240)                                       (version 1.1)
 * 
 * 
 */


using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//do obslugi GET i POST
using System.Net;
using System.IO;
using System.Threading;




namespace TestApplication
{
    class Program
    {

        //testowy request GET


        static void Main(string[] args)
        {

            int numberOfRequestSend = 0;

            //opis parametrow testowych wraz z numerem testu
            int[,] TestScenarioParameter = new int[5, 5]{
                //{}
                {1,2,3,4,5 },
                {1,2,3,4,5 },
                {1,2,3,4,5 },
                {1,2,3,4,5 },
                {1,2,3,4,5 },
            };

            //logowanie, zakup akcji,sprzedanie akcji, wylogowanie
            int[,] persentChance = new int[4, 4]
            {

                {100,0,0,0},
                {0,50,30,20},
                {0,40,50,10},
                {0,10,10,80}
            };

            int numberOfUser = 6;
            int numberOfRequest = 10;
            //wynik obciazenia jako mnoznik ilosci uzytkonikow i requestow
            int testFreQuency = numberOfRequest * numberOfUser;
            //delay do odczekania po kazdej akcji
            int delayTest = 60000 / testFreQuency;


            Stopwatch sw = new Stopwatch();
            int testScenarioNumber;

            Console.WriteLine("podaj numer scenariusza:");
            testScenarioNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("wybrano scenariusz:");
            Console.WriteLine(testScenarioNumber);
            sw.Start();
            testScenario(testScenarioNumber);
            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
            Console.WriteLine("oczekiwanie na wcisniecie klawisza");
            Console.ReadLine();

        }

        static void testScenario(int testScenarioNumber)
        {

            string sURL;
            sURL = "http://www.microsoft.com";
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);

            switch (testScenarioNumber)
            {
                case 1:
                    int numberOfUser = 20;
                    Console.WriteLine("scenariusz 1");
                    testScenerio1();
                    break;
                case 2:
                    Console.WriteLine("sceariusz 2");
                    Stream objStream;
                    objStream = wrGETURL.GetResponse().GetResponseStream();
                    StreamReader objReader = new StreamReader(objStream);


                    string sLine = "";
                    int i = 0;

                    while (sLine != null)
                    {
                        i++;
                        sLine = objReader.ReadLine();
                        if (sLine != null)
                            Console.WriteLine("{0}:{1}", i, sLine);
                    }
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("scenariusz 3");
                    testScenerio3();
                    break;
                default:
                    Console.WriteLine("wybrano zly scenariusz");
                    break;

            }


        }



        static void testScenerio1()
        {
            bool logged_in = false;
            bool log_out = false;
            //pierwszy scenariusz testowy:
            Console.WriteLine("wywolanie funkcji w test scenario1");

            Random rnd = new Random();
            for (int i = 1; i < 20; i++)
            {



                int randomNumber = rnd.Next(1, 101);//generate and return number beetwen 0 and 100
                Console.WriteLine(randomNumber);

                if (logged_in == true)
                {
                    randomNumber = rnd.Next(21, 101);
                }
                if (log_out == true)
                {
                    randomNumber = rnd.Next(1, 21);
                }

                if (randomNumber < 20)
                {
                    Console.WriteLine("logowanie");
                    logged_in = true;
                    log_out = false;

                }
                else if (randomNumber >= 20 && randomNumber < 50)
                {
                    Console.WriteLine("kupno akcji");
                } else if (randomNumber >= 50 && randomNumber < 90)
                {
                    Console.WriteLine("sprzedaz akcji");
                }
                else
                {
                    Console.WriteLine("wylogowanie");
                    log_out = true;
                    logged_in = false;
                }
                if (i == 20)
                {
                    Console.WriteLine("wylogowanie");
                    log_out = true;
                    logged_in = false;
                }


            }

        }

        static void testScenerio31()
       {
            bool logged_in = false;
            bool log_out = false;
            Random rnd = new Random();
          
                int randomNumber = rnd.Next(1, 101);//generate and return number beetwen 0 and 100
                Console.WriteLine(randomNumber);

                if (logged_in == true)
                {
                    randomNumber = rnd.Next(21, 101);
                }
                if (log_out == true)
                {
                    randomNumber = rnd.Next(1, 21);
                }

                if (randomNumber < 20)
                {
                    Console.WriteLine("logowanie");
                    logged_in = true;
                    log_out = false;

                }
                else if (randomNumber >= 20 && randomNumber < 50)
                {
                    Console.WriteLine("kupno akcji");
                }
                else if (randomNumber >= 50 && randomNumber < 90)
                {
                    Console.WriteLine("sprzedaz akcji");
                }
                else
                {
                    Console.WriteLine("wylogowanie");
                    log_out = true;
                    logged_in = false;
                }
               


            
        }

        static void testScenerio3()
        { int numberOfRequestSend = 0;
            Stopwatch sw = new Stopwatch();
            
            Stopwatch delay = new Stopwatch();
            //3 scenariusz testowy do tworzenia cegiełek kodu
            // test wykonania okreslonej ilosci zapytan w ciagu minuty
            sw.Start();
            while (sw.ElapsedMilliseconds < 2000) {
                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                    numberOfRequestSend++;
                testScenerio31();
                sw1.Stop();
                Console.WriteLine("odcczekiwanie");
                Thread.Sleep(100);
                //while (delay.ElapsedMilliseconds < 250) { }//poprawic by działalo
                Console.Write("czas:");
                Console.WriteLine("Elapsed={0}", sw1.Elapsed);
            }

            sw.Stop();

            Console.Write("liczba requestow:");
            Console.WriteLine(numberOfRequestSend);

            Console.Write("czas całkowity:");
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
            Console.WriteLine("oczekiwanie na wcisniecie klawisza");
            Console.ReadLine();

            

        }

        
            

    }
}

