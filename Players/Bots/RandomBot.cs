using System;
using RockPaperScissor;

namespace RockPaperScissor.Players
{
    class RandomBotPlayer : BotPlayer
    {
        protected override PlaysEnum GenerateChoice()
        {
            return this.GenerateRandomPlay();
        }
    }
}
