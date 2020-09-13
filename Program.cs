using RockPaperScissor.Players;
using System;

namespace RockPaperScissor
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer bot = new RandomBotPlayer();

            //int botChoice = bot.Play();
            //Console.WriteLine("Winner is: " + Rules.DecideWinner(choiceInt, botChoice));
            //Console.WriteLine("Bot played: " + botChoice);
            IPlayer human = new HumanPlayer();

            Game game = new Game(bot, human, 2);
            GameAnalytics gameResults = game.StartGame();
            Console.WriteLine("Winner is:" + gameResults.winner);
            Console.WriteLine("History: " + gameResults.roundsHistory.ToString());


        }
    }
}
