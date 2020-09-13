using RockPaperScissor.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor.Players
{
    public abstract class BotPlayer : IPlayer
    {
        public virtual AfterRoundCallback callback { get; }

        public PlaysEnum Play()
        {
            return GenerateChoice();
        }

        protected abstract PlaysEnum GenerateChoice();
    }
}
