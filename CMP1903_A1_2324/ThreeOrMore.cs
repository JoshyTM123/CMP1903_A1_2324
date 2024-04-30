using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMP1903_A1_2324
{
    internal class ThreeOrMore : Game
    {
        private int _total;
        private int _p1Score;
        private int _p2Score;
        
        public override int PlayGame(bool withComp)
        {
            bool Continued;
            int CurrentPlayer = 1;
            int Turns = 0;
            int DieShown;
            int Count = 0;
            string Choice = "-1";
            int[] RollCount = new int[6];

            _total = 0;
            _p1Score = 0;
            _p2Score = 0;

            GenerateDie(5);
            
            while ((_p1Score < 20 && _p2Score < 20))
            {
                if (CurrentPlayer == 1)
                {
                    Turns++;
                    Console.WriteLine();
                    Console.WriteLine("Player 1's Turn: Current Points: " + _p1Score);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Player 2's Turn: Current Points: " + _p2Score);
                }
                
                DieShown = 0;
                Continued = false;
                RollDie();
                
                while (DieShown < 5)
                {
                    if (CurrentPlayer == 2 && withComp)
                    {
                        Thread.Sleep(500);
                    }
                    else
                    {
                        Console.WriteLine("Press enter to roll!");
                        Console.ReadLine();
                    }
                    
                    for (int i = 0; i <= DieShown; i++)
                    {
                        Console.WriteLine($"Die {i + 1}: {GetRoll(i)}");
                    }
                    Console.WriteLine();
                    DieShown++;
                    //Checks to see if the user has rolled more than one-of-a-kind by using an array to count appearences of a number
                    if (DieShown > 1)
                    {
                        for (int i = 0; i < DieShown; i++)
                        {
                            RollCount[GetRoll(i) - 1]++;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            if (RollCount[i] > Count)
                            {
                                Count = RollCount[i];
                            }
                        }
                        switch (Count)
                        {
                            case 2:
                                {
                                    if (!Continued)
                                    {
                                        Console.WriteLine("You rolled a two-of-a-kind");
                                        //Gives the option to re-roll or continute after a 2 of a kind, but once continued, they can no longer re-roll
                                        Console.WriteLine("Would you like to re-roll all dice (r), or continue to roll your dice? (c)");
                                        if (CurrentPlayer == 2 && withComp)
                                        {
                                            //For the computer, if the last die makes a 2 of a kind, will guarantee a re-roll, else the more dice rolled, the higher chance of a reroll!
                                            if (DieShown == 5)
                                            {
                                                Choice = "r";
                                            }
                                            else if (DieShown == 2)
                                            {
                                                Choice = "c";
                                            }
                                            {
                                                Random rnd = new Random();
                                                if (rnd.Next(1, (DieShown * 2)) == 1)
                                                {
                                                    Choice = "c";
                                                }
                                            }
                                            Console.WriteLine(Choice);
                                        }
                                        else
                                        {
                                            Choice = Console.ReadLine();
                                        }
                                        try
                                        {
                                            Choice.ToLower();
                                        }
                                        catch (FormatException ex)
                                        {
                                            Console.WriteLine("INVALID CHOICE: DEFAULTING TO CONTINUE");
                                            Choice = "c";
                                        }

                                        //Chosen to reroll
                                        if (Choice == "r")
                                        {
                                            Console.WriteLine("--------------------");
                                            Console.WriteLine("You chose to re-roll");
                                            Console.WriteLine("--------------------");
                                            RollDie();
                                            DieShown = 0;
                                        }

                                        //Chosen to continue
                                        else if (Choice == "c")
                                        {
                                            Console.WriteLine("---------------------");
                                            Console.WriteLine("You chose to continue");
                                            Console.WriteLine("---------------------");
                                            Continued = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("---------------------");
                                            Console.WriteLine("INVALID CHOICE: DEFAULTING TO CONTINUE");
                                            Console.WriteLine("---------------------");
                                            Continued = true;
                                        }
                                        
                                    }
                                    break;
                                }
                            case 3:
                                //POINTS
                                {
                                    if (DieShown == 5)
                                    {
                                        Console.WriteLine("CONGRATS: You rolled a three-of-a-kind! +3 points");
                                        if (CurrentPlayer == 1)
                                        {
                                            _p1Score += 3;
                                        }
                                        else
                                        {
                                            _p2Score += 3;
                                        }
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    if (DieShown == 5)
                                    {
                                        Console.WriteLine("CONGRATS: You rolled a four-of-a-kind! +6 points");
                                        if (CurrentPlayer == 1)
                                        {
                                            _p1Score += 6;
                                        }
                                        else
                                        {
                                            _p2Score += 6;
                                        }
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    if (DieShown == 5)
                                    {
                                        Console.WriteLine("CONGRATS: You rolled a five-of-a-kind! +12 points");
                                        if (CurrentPlayer == 1)
                                        {
                                            _p1Score += 12;
                                        }
                                        else
                                        {
                                            _p2Score += 12;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    if (DieShown == 5)
                                    {
                                        Console.WriteLine("Nothing, no points given :(");
                                    }
                                    break;
                                }
                        }
                        //Resets the roll count
                        for (int i = 0; i < 6; i++)
                        {
                            RollCount[i] = 0;
                        }
                        Count = 0;
                    }
                }
                if (CurrentPlayer == 1)
                {
                    CurrentPlayer = 2;
                }
                else
                {
                    CurrentPlayer = 1;
                }
            }

            if (_p1Score >= 20)
            {
                Console.WriteLine("PLAYER 1 WINS! YOU TOOK: " + Turns + " TURNS!");
            }
            else
            {
                Console.WriteLine("PLAYER 2 WINS! YOU TOOK: " + Turns + " TURNS!");
            }
            
            return Turns;
        }
        
    }
}
