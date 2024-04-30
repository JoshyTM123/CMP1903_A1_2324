using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        public void TestSevensOut()
        {
            Game game = new Game();
            game.RollDie("s");
            //Tests the 7 detector
            Debug.Assert(game.GetRoll(0) + game.GetRoll(1) == 7);

            //Tests adding up 2 numbers not totalling 7 AND are not the same
            if (game.GetRoll(1) == game.GetRoll(2))
            {
                Debug.Assert(game.GetRoll(1) + game.GetRoll(2) == 11);
            }

            //Tests adding up 2 numbers that are doubles
            if (game.GetRoll(1) == game.GetRoll(3))
            {
                Debug.Assert(((game.GetRoll(1) + game.GetRoll(3)) * 2) == 24);
            }

            Console.WriteLine("Seven Out Test Successful");
        }

        public void TestThreeOrMore()
        {
            Game game = new Game();
            int DieShown;
            int Count = 0;
            int[] RollCount = new int[6];
            game.RollDie("t");

            //Testing finding 2 numbers the same
            DieShown = 2;
            for (int i = 0; i < DieShown; i++)
            {
                RollCount[game.GetRoll(i) - 1]++;
            }
            for (int i = 0; i < 6; i++)
            {
                if (RollCount[i] > Count)
                {
                    Count = RollCount[i];
                }
            }
            Debug.Assert(Count == 2);

            ResetRollCount(RollCount);
            Count = 0;
            //Testing finding 3 numbers the same
            DieShown = 3;
            for (int i = 0; i < DieShown; i++)
            {
                RollCount[game.GetRoll(i) - 1]++;
            }
            for (int i = 0; i < 6; i++)
            {
                if (RollCount[i] > Count)
                {
                    Count = RollCount[i];
                }
            }

            Debug.Assert(Count == 3);

            ResetRollCount(RollCount);
            Count = 0;
            //Testing finding 4 numbers the same
            DieShown = 4;
            for (int i = 0; i < DieShown; i++)
            {
                RollCount[game.GetRoll(i) - 1]++;
            }
            for (int i = 0; i < 6; i++)
            {
                if (RollCount[i] > Count)
                {
                    Count = RollCount[i];
                }
            }
            Debug.Assert(Count == 4);

            ResetRollCount(RollCount);
            Count = 0;
            //Testing finding 5 numbers the same
            DieShown = 5;
            for (int i = 0; i < DieShown; i++)
            {
                RollCount[game.GetRoll(i) - 1]++;
            }
            for (int i = 0; i < 6; i++)
            {
                if (RollCount[i] > Count)
                {
                    Count = RollCount[i];
                }
            }
            Debug.Assert(Count == 5);

            ResetRollCount(RollCount);
            Count = 0;
            //Testing no numbers are the same
            RollCount[game.GetRoll(4) - 1]++;
            RollCount[game.GetRoll(5) - 1]++;

            for (int i = 0; i < 6; i++)
            {
                if (RollCount[i] > Count)
                {
                    Count = RollCount[i];
                }
            }

            Debug.Assert(Count == 1);

            Console.WriteLine();
            Console.WriteLine("Three Or More Test Successful");
            Console.WriteLine("-----------------------------");
        }

        private int[] ResetRollCount(int[] RollCount)
        {
            for (int i = 0; i < 6; i++)
            {
                RollCount[i] = 0;
            }

            return RollCount;
        }



    }
}
