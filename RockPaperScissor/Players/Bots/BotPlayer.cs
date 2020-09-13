using RockPaperScissor.Enums;
using System;

namespace RockPaperScissor.Players.Bots
{
    public abstract class BotPlayer : Player
    {
        public override PlaysEnum Play()
        {
            return GenerateChoice();
        }
        protected PlaysEnum GenerateRandomPlay()
        {
            return (PlaysEnum)new Random().Next(Rules.TotalPossiblePlaysEnum);
        }

        protected abstract PlaysEnum GenerateChoice();
    }
}
