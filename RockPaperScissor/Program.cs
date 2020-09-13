using RockPaperScissor.Enums;
using RockPaperScissor.Players;
using RockPaperScissor.Players.Bots;
using System;

namespace RockPaperScissor
{
    class Program
    {
        static void Main(string[] args)
        {
            Player Rbot = new RandomBotPlayer();
            Player Sbot = new SmartBot();
            Player human = new HumanPlayer();

            Game game = new Game(human, Sbot, 2, AfterRound, GameFinished);

            GameAnalytics gameResults = game.PlayGame();
        }

        public static void AfterRound(PlaysEnum player1Play, PlaysEnum player2Play, GameResults result)
        {
            Console.WriteLine("Player 1:" + player1Play + "  Player 2: " + player2Play);
            Console.WriteLine("Round result: " + result + "\n");
        }

        public static void GameFinished(GameAnalytics gameResults)
        {
            Console.WriteLine("Winner is:" + gameResults.winner);
        }
    }
}
