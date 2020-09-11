using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor.Players
{
    class HumanPlayer : IPlayer
    {
        public int Play()
        {
            Console.Write("Please select option from 0 to {0}:", Rules.TotalPossiblePlays);
            
            string choice = Console.ReadLine();
            int choiceInt = Convert.ToInt32(choice);

            return choiceInt;
        }
    }
}
