using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame.GameLogic;
using System;
using System.Collections.Generic;
using System.Text;
using GameLogic;
using Moq;

namespace CardGame.GameLogic.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void GameTest()
        {
            var display = new Mock<IDisplay>();
            var result = new Game(display.Object);
            Assert.IsNotNull(result.Field);
        }

        [TestMethod()]
        public void GameNullTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Game(null));
        }

        [TestMethod()]
        public void StartGameProcessTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GameOverTest()
        {
            var playerMock = new Mock<IPlayer>();
            playerMock.SetupGet(x => x.Life).Returns(0);

            var display = new Mock<IDisplay>();

            var game = new Mock<Game>(display.Object);
            game.SetupGet(x => x.Player1).Returns(playerMock.Object);

            var result = game.Object.GameOver;

            Assert.IsTrue(result);
        }
    }
}