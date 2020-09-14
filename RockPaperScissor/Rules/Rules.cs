using RockPaperScissor.Enums;
using System;
using System.Configuration;

namespace RockPaperScissor
{
    public sealed class Rules
    {
        public static Rules Instance { get; } = new Rules();
        static Rules()
        {
        }

        private Rules()
        {
            GetGameRulesFromConfig(out NumberOfWinsForVictory, out TotalPossiblePlays);
        }

        private int[,] playsEnumHierarchy = null;
        public readonly int NumberOfWinsForVictory;
        public readonly int TotalPossiblePlays;

        public void GetGameRulesFromConfig(out int numberOfWins, out int totalPossiblePlays)
        {
            numberOfWins = Convert.ToInt32(ConfigurationManager.AppSettings["numberOfWins"]);
            totalPossiblePlays = Convert.ToInt32(ConfigurationManager.AppSettings["totalPlays"]);
            playsEnumHierarchy = new int[TotalPossiblePlays, TotalPossiblePlays];

            for (int i = 0; i < TotalPossiblePlays; i++)
            {
                var row = ConfigurationManager.AppSettings[i.ToString()].Split(',');
                for (int j = 0; j < row.Length; j++)
                {
                    playsEnumHierarchy[i, j] = Convert.ToInt32(row[j]);
                }
            }
        }

        public int DecideWinner(PlaysEnum play1, PlaysEnum play2)
        {
            return playsEnumHierarchy[(int)play1, (int)play2];
        }
    }

}
