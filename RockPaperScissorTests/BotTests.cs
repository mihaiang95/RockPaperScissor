using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissor;
using RockPaperScissor.Enums;
using RockPaperScissor.Players.Bots;

namespace RockPaperScissorTests
{
    [TestClass]
    public class BotTests
    {
        [DataTestMethod]
        [DataRow(PlaysEnum.Rock, PlaysEnum.Paper)]
        [DataRow(PlaysEnum.Paper, PlaysEnum.Scissor)]
        [DataRow(PlaysEnum.Scissor, PlaysEnum.Rock)]
        public void SmartbotGenerateChoiceTest(PlaysEnum oldPlay, PlaysEnum newPlay)
        {
            //Arrange
            SmartBot bot = new SmartBot();
            bot.callback.Invoke(oldPlay, PlaysEnum.Paper, GameResults.Undecided);

            //Act
            var botNextPlay = bot.Play();

            //Assert
            Assert.AreEqual(newPlay, botNextPlay);
        }
    }
}
