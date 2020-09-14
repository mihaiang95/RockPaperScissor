using RockPaperScissor.Enums;

namespace RockPaperScissor.Players.Bots
{
    class RandomBot : BotPlayer
    {
        protected override PlaysEnum GenerateChoice()
        {
            return GenerateRandomPlay();
        }
    }
}
