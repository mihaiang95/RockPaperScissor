using RockPaperScissor.Players;
using System;

namespace RockPaperScissor
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer bot = new RandomBotPlayer();
            Console.Write("Please select option from 0 to 2:");
            string choice = Console.ReadLine();
            int choiceInt = Convert.ToInt32(choice);

            int botChoice = bot.Play();
            Console.WriteLine("Winner is: " + Rules.DecideWinner(choiceInt, botChoice));
            Console.WriteLine("Bot played: " + botChoice);
        }
    }
}
