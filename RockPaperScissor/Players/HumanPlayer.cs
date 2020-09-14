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
            int choiceInt;

            do
            {
                Console.Write("Please select option from 0 to {0}: ", Rules.Instance.TotalPossiblePlays - 1);

                string choice = Console.ReadLine();
                
                if(!Int32.TryParse(choice, out choiceInt))
                {
                    choiceInt = 0;
                    Console.WriteLine("Automatically selected: " + choiceInt);
                }
            } while (choiceInt < 0 || choiceInt > Rules.Instance.TotalPossiblePlays);

            return (PlaysEnum)choiceInt;
        }
    }
}
