using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {


        //Objects
        private List<Die> _diceList = new List<Die>();
        private List<int> _RollList = new List<int>();
       
        //Menu
        static void Main(string[] args)
        {
            Statistics stats = new Statistics();
            SevensOut sevensOut = new SevensOut();
            ThreeOrMore TOM = new ThreeOrMore();
            Game[] games = { sevensOut, TOM };
            int score = 0;
            int Choice = 0;
            string withComps = "";

            while (Choice != 5) 
            { 
                Console.WriteLine("Enter a digit for what you would like to do: 1 = Sevens Out, 2 = Three Or More, 3 = Stats Menu, 4 = Testing, 5 = Exit");
                string ChoiceStr = Console.ReadLine();
               
                try
                {
                    Convert.ToInt32(ChoiceStr);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Did not enter a valid digit, defaulting to Exit");
                    ChoiceStr = "5";
                }

                Choice = Convert.ToInt32(ChoiceStr);
                if (Choice < 1 || Choice > 5)
                {
                    Console.WriteLine("Did not enter a valid digit, defaulting to Exit");
                    Choice = 5;
                }
                
                //With or without computers (if entered either 1 or 2 in the choices menu)
                if (Choice == 1 || Choice == 2)
                {
                    Console.WriteLine("Would you like to play with a person (p) or computer (c)");
                    withComps = Console.ReadLine();
                    try
                    {
                        withComps.ToLower();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("INVALID INPUT, DEFAULT TO WITH COMPUTERS");
                        withComps = "c";
                    }
                }
                
                switch (Choice)
                {
                    case 1:
                        {
                            stats.IncreaseSOGamesPlayed();
                            if (withComps.ToLower() == "c")
                            {
                                score = (games[0].PlayGame(true));
                                if (score > stats.GetSevensOutHighScore())
                                {
                                    Console.WriteLine($"{score} WAS A NEW HIGHSCORE!");
                                    stats.SetOSHighScore(score);
                                }
                            }
                            else if (withComps.ToLower() == "p")
                            {
                                score = (games[0].PlayGame(false));
                                if (score > stats.GetSevensOutHighScore())
                                {

                                    Console.WriteLine($"{score} WAS A NEW HIGHSCORE!");
                                    stats.SetOSHighScore(score);
                                }
                            }
                            else
                            {
                                Console.WriteLine("INVALID CHOICE, DEFAULTING TO WITH COMPUTERS");
                                score = (games[0].PlayGame(true));
                                if (score > stats.GetSevensOutHighScore())
                                {
                                    Console.WriteLine($"{score} WAS A NEW HIGHSCORE!");
                                    stats.SetOSHighScore(score);
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            stats.IncreaseThreeOrMorePlayed();
                            if (withComps.ToLower() == "c")
                            {
                                score = TOM.PlayGame(true);
                                if (score > stats.GetThreeOrMoreHighScore())
                                {
                                    Console.WriteLine($"{score} WAS A NEW HIGHSCORE!");
                                    stats.SetTOMHighScore(score);
                                }
                            }
                            else if (withComps.ToLower() == "p")
                            {
                                score = TOM.PlayGame(false);
                                if (score > stats.GetThreeOrMoreHighScore())
                                {
                                    Console.WriteLine($"{score} WAS A NEW HIGHSCORE!");
                                    stats.SetTOMHighScore(score);
                                }
                            }
                            else
                            {
                                Console.WriteLine("INVALID CHOICE, DEFAULTING TO WITH COMPUTERS");
                                score = TOM.PlayGame(true);
                                if (score > stats.GetThreeOrMoreHighScore())
                                {
                                    Console.WriteLine($"{score} WAS A NEW HIGHSCORE!");
                                    stats.SetTOMHighScore(score);
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("STATISTICS:");
                            Console.WriteLine("-----------");
                            Console.WriteLine($"You have played SEVENS OUT {stats.GetSOGamesPlayed()} times!");
                            Console.WriteLine($"You have played THREE OR MORE {stats.GetThreeOrMorePlayed()} times!");
                            Console.WriteLine($"There is a human high score of {stats.GetSevensOutHighScore()} points in SEVENS OUT!");
                            Console.WriteLine($"There is a human high score of {stats.GetThreeOrMoreHighScore()} turns in THREE OR MORE!");
                        }
                        break;
                    case 4:
                        {
                            Testing test = new Testing();
                            test.TestSevensOut();
                            test.TestThreeOrMore();
                            break;
                        }
                }
                Console.WriteLine();
            }
            Console.WriteLine("THANKS FOR PLAYING!");
            Console.ReadKey();
        }


        //Methods

        //Generates correct number of dice
        public void GenerateDie(int NumOfDie)
        {
            for (int i = 0; i < NumOfDie; i++)
            {
                Die die = new Die();
                _diceList.Add(die);
                _RollList.Add(0);
            }
        }
        
        //Rolls all die in list
        public void RollDie()
        {
            int i = 0;
            foreach (Die die in _diceList)
            {
                _RollList[i] = die.Roll();
                Thread.Sleep(10);
                i++;
            }
        }

        //Returns rolls
        public int GetRoll(int index)
        {
            return _RollList[index];
        }

        public virtual int PlayGame(bool withComps)
        {
            return 0;
        }
        //Testing gives certain rolls
        public void RollDie(string TestForGame)
        {
            if (TestForGame == "s")
            {
                // 1 and 6 test for total of 7, 5 and 6 checks for points add by 11, 6 and 6 check score adds by 24
                _RollList.Add(1);
                _RollList.Add(6);
                _RollList.Add(5);
                _RollList.Add(6);
            }
            else
            {
                _RollList.Add(6);
                _RollList.Add(6);
                _RollList.Add(6);
                _RollList.Add(6);
                _RollList.Add(6);
                _RollList.Add(1);
            }
        }


    }
}
