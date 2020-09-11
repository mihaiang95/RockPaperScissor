using System;
using RockPaperScissor;

namespace RockPaperScissor.Players
{
    class RandomBotPlayer : BotPlayer
    {
        protected override int GenerateChoice()
        {
            return new Random().Next(Rules.TotalPossiblePlays);
        }
    }
}
