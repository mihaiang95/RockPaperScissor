using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor
{
    public static class Rules
    {
        private static int[,] playsEnumHierarchy = { { 0, 2, 1 }, { 1, 0, 2 }, { 2, 1, 0 } };
        public const int NumberOfWinsForVictory = 2;
        
        public static int TotalPossiblePlaysEnum { 
            get 
            {
                return Enum.GetNames(typeof(PlaysEnum)).Length;
            } 
        }

        public static int DecideWinner(PlaysEnum play1, PlaysEnum play2)
        {
            return playsEnumHierarchy[(int)play1, (int)play2];
        }
    }

    public enum PlaysEnum
    {
        Rock = 0,
        Paper = 1,
        Scissor = 2
    }
}
