using RockPaperScissor.Enums;
using System;

namespace RockPaperScissor.Players
{
    class HumanPlayer : Player
    { 
        public override PlaysEnum Play()
        {
            return GetChoice();
        }

        public PlaysEnum GetChoice()
        {
            Console.Write("Please select option from 0 to {0}: ", Rules.TotalPossiblePlaysEnum - 1);

            string choice = Console.ReadLine();
            int choiceInt = Convert.ToInt32(choice);

            return (PlaysEnum)choiceInt;
        }
    }
}
