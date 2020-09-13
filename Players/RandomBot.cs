using System;
using RockPaperScissor;

namespace RockPaperScissor.Players
{
    class RandomBotPlayer : BotPlayer
    {
        public override AfterRoundCallback callback => TestCallBack;

        public void TestCallBack(PlaysEnum play, PlaysEnum play2, GameResults winner)
        {
            //Console.WriteLine(play.ToString() + " " + play2.ToString() + " " + winner.ToString());
        }

        protected override PlaysEnum GenerateChoice()
        {
            return (PlaysEnum) new Random().Next(Rules.TotalPossiblePlaysEnum);
        }
    }
}
