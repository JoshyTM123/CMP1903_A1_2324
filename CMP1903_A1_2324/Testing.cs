using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */
        
        //Method
        public bool Test()
        {
            // Runs a test version of the game, and checks the outputs of the rolls
            Game testGame = new Game();
            testGame.ExecuteGame();
            var totalOfRolls = testGame.TotalOfRolls();
            Debug.Assert(testGame.TotalOfRolls() < 18);
            var testTotalOfRolls = testGame.ValueRoll1() + testGame.ValueRoll2() + testGame.ValueRoll3();
            if (testGame.TotalOfRolls() == testTotalOfRolls)
            {
                    Console.WriteLine("Total Is As Expected: " + totalOfRolls.ToString());
                    return true;
            }
            else
            {
                Console.WriteLine("Total Is Noty As Expected, Error With Addition");
                return false;
            }
        }


    }
}
