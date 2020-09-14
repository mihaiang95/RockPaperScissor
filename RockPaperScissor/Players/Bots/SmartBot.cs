using RockPaperScissor.Enums;
using System;

namespace RockPaperScissor.Players.Bots
{
    public class SmartBot : BotPlayer
    {
        protected PlaysEnum? lastChoice = null;
        public override AfterRoundCallback callback => (PlaysEnum myPlay, PlaysEnum otherPlay, GameResults result) =>
        {
            lastChoice = myPlay;
        };

        protected override PlaysEnum GenerateChoice()
        {
            PlaysEnum? newChoice = null;

            if (lastChoice.HasValue)
            {
                var plays = Enum.GetValues(typeof(PlaysEnum));

                foreach (PlaysEnum play in plays)
                {
                    if (Rules.Instance.DecideWinner(lastChoice.Value, play) == (int)GameResults.Player2Victory)
                    {
                        newChoice = play;
                        break;
                    }
                }
            }

            return newChoice.HasValue ? newChoice.Value : GenerateRandomPlay();
        }
    }
}
