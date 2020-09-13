using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor
{
    public class GameAnalytics
    {
        public List<Round> roundsHistory = new List<Round>();
        public int[] scoreTable = new int[3];

        public GameResults winner = GameResults.Undecided;
    }

    public enum GameResults
    {
        Undecided = 0,
        Player1Victory = 1,
        Player2Victory = 2
    }
}
