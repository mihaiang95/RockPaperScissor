using RockPaperScissor.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor
{
    public class Game
    {
        IPlayer player1;
        IPlayer player2;

        AfterRoundCallback player1Callback, player2Callback;

        readonly int roundsToWin;
        GameAnalytics gameAnalytics;

        GameStates state;

        public Game(IPlayer player1, IPlayer player2, int roundsForWin)
        {
            this.player1 = player1;
            this.player2 = player2;
            roundsToWin = roundsForWin;

            gameAnalytics = new GameAnalytics();
        }

        public GameAnalytics StartGame()
        {
            state = GameStates.InProgress;

            while(gameAnalytics.winner == GameResults.Undecided)
            {
                var currentRound = PlayRound();

                if(++gameAnalytics.scoreTable[(int) currentRound.result] == roundsToWin && currentRound.result != 0)
                {
                    gameAnalytics.winner = currentRound.result;
                }

                gameAnalytics.roundsHistory.Add(currentRound);
            }

            state = GameStates.Finished;

            return gameAnalytics;
        }

        private Round PlayRound()
        {
            var round = new Round
            {
                player1Play = player1.Play(),
                player2Play = player2.Play(),
            };

            round.result = (GameResults) Rules.DecideWinner(round.player1Play, round.player2Play);

            if(player1.callback != null)
            {
                player1.callback(round.player1Play, round.player2Play, (GameResults) round.result);
            }
            if (player2.callback != null)
            {
                player2.callback(round.player2Play, round.player1Play, RevertResult((int) round.result));
            }

            Console.WriteLine("Player 1:" + round.player1Play + "  Player 2: " + round.player2Play);
            Console.WriteLine("Round result:" + round.result);

            return round;
        }

        private GameResults RevertResult(int result)
        {
            return result == 0 ? GameResults.Undecided : result == 1 ? GameResults.Player2Victory : GameResults.Player1Victory;
        }
    }

    public enum GameStates 
    {
        Started = 0,
        InProgress = 1,
        Finished = 2
    }

    public delegate void AfterRoundCallback(PlaysEnum myPlay, PlaysEnum otherPlay, GameResults result);
    
}
