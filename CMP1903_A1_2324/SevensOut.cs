using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class SevensOut : Game
    {
        private int _total = 0;
        private int _p1Score = 0;
        private int _p2Score = 0;
        bool cont = true;
        int CurrentPlayer = 1;

        //Plays the game of SevensOut
        public override int PlayGame(bool withComp)
        {
        _total = 0;
        _p1Score = 0;
        _p2Score = 0;
        cont = true;
        CurrentPlayer = 1;
        GenerateDie(2);
            while (cont)
            {
                //Will roll 2 die and compare them to see whether a total of 7 was scored, if so switches to next player. Else adds rolls to total correctly.
                if (CurrentPlayer == 2 && withComp)
                {
                    Thread.Sleep(500); //Computer plays automatically, whilst human players press enter to roll dice.
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Press enter to roll:");
                    Console.ReadLine();
                }
                RollDie();
                Console.WriteLine($"Your rolls were: {GetRoll(0)} and {GetRoll(1)}");
                if (GetRoll(0) + GetRoll(1) == 7)
                {
                    if (CurrentPlayer == 1)
                    {
                        Console.WriteLine("ROLLED A TOTAL OF 7, SWITCHING TO PLAYER 2");
                        Console.WriteLine();
                        _p1Score = _total;
                        CurrentPlayer = 2;
                        _total = 0;
                    }
                    else
                    {
                        Console.WriteLine("ROLLED A TOTAL OF 7, END OF GAME");
                        Console.WriteLine();
                        _p2Score = _total;
                        cont = false;
                    }
                }
                else if (GetRoll(0) == GetRoll(1))
                {
                    _total = _total + ((GetRoll(0) + GetRoll(1)) * 2);
                    Console.WriteLine($"Player {CurrentPlayer}'s Current Score: " + _total);
                }
                else
                {
                    _total = _total + GetRoll(0) + GetRoll(1);
                    Console.WriteLine($"Player {CurrentPlayer}'s Current Score: " + _total);
                }
            }

            //Determines who won, and returns the highest HUMAN score back to game class to be put in statistics if it is a highscore
            if (_p1Score > _p2Score)
            {
                Console.WriteLine("Player 1 wins with: " + _p1Score + " to Player 2's score of: " + _p2Score);
                return _p1Score;
            }
            else
            {
                Console.WriteLine("Player 2 wins with: " + _p2Score + " to Player 1's score of: " + _p1Score);
                if (!withComp)
                {
                    return _p2Score;
                }
                else
                {
                    return _p1Score;
                }
                
            }
           


        }

        



        
    }
}
