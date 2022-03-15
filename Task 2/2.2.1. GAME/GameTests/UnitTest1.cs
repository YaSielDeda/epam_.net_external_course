using _2._2._1._GAME.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GameObjectGenerator_GenerateGameObjects_ReturnTrue()
        {
            GameObjectGenerator gameObjectGenerator = new GameObjectGenerator();

            gameObjectGenerator.GenerateGameObjects();

            Assert.IsNotNull(gameObjectGenerator.GetGameObjects());
        }
    }
}
