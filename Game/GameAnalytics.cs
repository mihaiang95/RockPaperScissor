using RockPaperScissor.Enums;
using System.Collections.Generic;

namespace RockPaperScissor
{
    public class GameAnalytics
    {
        public List<Round> roundsHistory = new List<Round>();
        public int[] scoreTable = new int[3];

        public GameResults winner = GameResults.Undecided;
    }
}
