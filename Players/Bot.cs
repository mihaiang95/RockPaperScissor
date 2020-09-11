using RockPaperScissor.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor.Players
{
    public abstract class BotPlayer : IPlayer
    {
        public int Play()
        {
            return GenerateChoice();
        }

        protected abstract int GenerateChoice();
    }
}
