using RockPaperScissor.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor.Players
{
    public abstract class BotPlayer : Player
    {
        public override PlaysEnum Play()
        {
            return GenerateChoice();
        }

        protected abstract PlaysEnum GenerateChoice();

        protected PlaysEnum GenerateRandomPlay()
        {
            return(PlaysEnum) new Random().Next(Rules.TotalPossiblePlaysEnum);
        }
    }
}
