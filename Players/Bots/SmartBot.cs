using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor.Players.Bots
{
    class SmartBot : BotPlayer
    {
        PlaysEnum? lastChoice = null;
        public override AfterRoundCallback callback => (PlaysEnum myPlay, PlaysEnum otherPlay, GameResults result) =>
        {
            this.lastChoice = myPlay;
        };

        protected override PlaysEnum GenerateChoice()
        {
            PlaysEnum? newChoice = null;

            if (lastChoice.HasValue)
            {
                var plays = Enum.GetValues(typeof(PlaysEnum));

                foreach (PlaysEnum play in plays)
                {
                    if (Rules.DecideWinner(lastChoice.Value, play) == (int)GameResults.Player2Victory)
                    {
                        newChoice = play;
                        break;
                    }
                }

                return newChoice.HasValue ? newChoice.Value : this.GenerateRandomPlay();
            }
        }
    }
}
