namespace RockPaperScissor.Players.Bots
{
    class RandomBotPlayer : BotPlayer
    {
        protected override PlaysEnum GenerateChoice()
        {
            return this.GenerateRandomPlay();
        }
    }
}
