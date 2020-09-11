using RockPaperScissor.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor.Game
{
    public class Game
    {
        IPlayer player1;
        IPlayer player2;

        int numberOfGamesPlayed;
        List<Round> roundsHistory;

        GameStates state;
        int winner;

        public void Startgame()
        {

        }
    }

    public enum GameStates 
    {
        Started = 0,
        InProgress = 1,
        Finished = 2
    }

    
}
