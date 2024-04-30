using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Statistics
    {
        private int _SevensOutPlayed = 0;
        private int _ThreeOrMorePlayed = 0;
        private int _SevensOutHighScore = -1;
        private int _ThreeOrMoreHighScore = -1;
        

        //Changing the statistics in a controlled way
        public void IncreaseSOGamesPlayed()
        {
            _SevensOutPlayed++;
        }

        public void IncreaseThreeOrMorePlayed()
        {
            _SevensOutPlayed++;
        }

        public void SetOSHighScore(int newHighScore)
        {
            _SevensOutHighScore = newHighScore;
        }

        

        public void SetTOMHighScore(int newHighScore)
        {
            _ThreeOrMoreHighScore = newHighScore;
        }

        

        //Retrieving the statistics in a controlled way
        public int GetSOGamesPlayed()
        {
            return _SevensOutPlayed;
        }

        public int GetThreeOrMorePlayed()
        {
            return _ThreeOrMorePlayed;
        }

        public int GetSevensOutHighScore()
        {
            return _SevensOutHighScore;
        }

        

        public int GetThreeOrMoreHighScore()
        {
            return _ThreeOrMoreHighScore;
        }

        
    }
}
