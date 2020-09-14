using RockPaperScissor.Enums;
using RockPaperScissor.Players;
using System;

namespace RockPaperScissor
{
    public class Game
    {
        readonly Player player1;
        readonly Player player2;

        AfterRoundCallback afterRoundCallback;
        GameFinishedCallback gameFinishedCallback;

        readonly int roundsToWin;
        GameAnalytics gameAnalytics;

        GameStates state;

        public Game(Player player1, Player player2, AfterRoundCallback afterRoundCallback = null, GameFinishedCallback gameFinishedCallback = null)
        {
            this.player1 = player1;
            this.player2 = player2;
            
            this.gameFinishedCallback = gameFinishedCallback;
            this.afterRoundCallback = afterRoundCallback;
            
            roundsToWin = Rules.Instance.NumberOfWinsForVictory;
            gameAnalytics = new GameAnalytics();
        }

        public GameAnalytics PlayGame()
        {
            state = GameStates.InProgress;
            ShowPlays();

            while (gameAnalytics.winner == GameResults.Undecided)
            {
                var currentRound = PlayRound();

                if(++gameAnalytics.scoreTable[(int) currentRound.result] == roundsToWin && currentRound.result != 0)
                {
                    gameAnalytics.winner = currentRound.result;
                }

                gameAnalytics.roundsHistory.Add(currentRound);
            }

            gameFinishedCallback?.Invoke(gameAnalytics);
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
            round.result = (GameResults) Rules.Instance.DecideWinner(round.player1Play, round.player2Play);

            player1.callback?.Invoke(round.player1Play, round.player2Play, (GameResults)round.result);
            player2.callback?.Invoke(round.player2Play, round.player1Play, RevertResult((int)round.result));

            afterRoundCallback?.Invoke(round.player1Play, round.player2Play, (GameResults)round.result);

            return round;
        }

        private void ShowPlays()
        {
            Console.WriteLine("\n");
            foreach (PlaysEnum play in Enum.GetValues(typeof(PlaysEnum)))
            {
                Console.WriteLine($"{play} - {(int)play}");
            }
            Console.WriteLine("\n");
        }

        private GameResults RevertResult(int result)
        {
            return result == 0 ? GameResults.Undecided : result == 1 ? GameResults.Player2Victory : GameResults.Player1Victory;
        }
    }

    public delegate void AfterRoundCallback(PlaysEnum myPlay, PlaysEnum otherPlay, GameResults result);
    public delegate void GameFinishedCallback(GameAnalytics gameresult);  
}
