using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor
{
    public static class Rules
    {
        private static int[,] playsHierarchy = { { 0, 2, 1 }, { 1, 0, 2 }, { 2, 1, 0 } };
        public static int TotalPossiblePlays { 
            get 
            {
                return Enum.GetNames(typeof(Plays)).Length;
            } 
        }

        public static int DecideWinner(int play1, int play2)
        {
            return playsHierarchy[(int)play1, (int)play2];
        }
    }

    public enum Plays
    {
        Rock = 1,
        Paper = 2,
        Scissor = 3
    }
}
