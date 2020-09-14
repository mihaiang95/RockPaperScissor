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
            Player player1, player2;
            bool playAgain = true;

            while (playAgain)
            {
                player1 = null;
                player2 = null;

                while (player1 == null || player2 == null)
                {
                    SelectPlayers(ref player1, ref player2);
                }

                Game game = new Game(player1, player2, AfterRoundCallback, GameFinishedCallback);
                GameAnalytics gameResults = game.PlayGame();

                playAgain = AfterGame();
            }
        }

        public static void AfterRoundCallback(PlaysEnum player1Play, PlaysEnum player2Play, GameResults result)
        {
            Console.WriteLine("Player 1:" + player1Play + "  Player 2: " + player2Play);
            Console.WriteLine("Round result: " + result + '\n');
        }

        public static void GameFinishedCallback(GameAnalytics gameResults)
        {
            Console.WriteLine("Winner is:" + gameResults.winner + "\n");
        }

        private static void SelectPlayers(ref Player player1,ref Player player2)
        {
            Console.WriteLine("Select player 1");
            Console.WriteLine("\t H - Human Player; R - Random Bot; S - SmartBot: ");
            var choice1 = Console.ReadLine();

            Console.WriteLine("Select player 2");
            Console.WriteLine("\t H - Human Player; R - Random Bot; S - SmartBot;");
            var choice2 = Console.ReadLine();

            switch (choice1.ToUpper())
            {
                case "H":
                    player1 = new HumanPlayer();
                    break;
                case "R":
                    player1 = new RandomBot();
                    break;
                case "S":
                    player1 = new SmartBot();
                break;
                default:
                    player1 = null;
                    break;
            }

            switch (choice2.ToUpper())
            {
                case "H":
                    player2 = new HumanPlayer();
                    break;
                case "R":
                    player2 = new RandomBot();
                    break;
                case "S":
                    player2 = new SmartBot();
                    break;
                default:
                    player2 = null;
                    break;
            }
        }

        private static bool AfterGame()
        {
            Console.WriteLine("Press 'A' to play again, any other key to stop");
            var response = Console.ReadLine();

            return response.ToUpper() == "A";
        }
    }
}
