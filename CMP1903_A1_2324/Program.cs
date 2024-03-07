using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Runs the test of the game, then the game and displays them to the console
            Game gameRun = new Game();
            Testing gameTest = new Testing();
            if (gameTest.Test())
            {
                gameRun.ExecuteGame();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Error when testing the application. Please ammend and restart")
            }
            
        }
    }
}
