using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarLanes.Pages;

namespace StarLanesUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int x = 5;
            int y = 3;

            Assert.AreEqual("F4", StarLanesGame.Move.ToString(x, y), "Incorrect Move.ToString() static result");

            StarLanesGame.Move move = new StarLanesGame.Move(x, y);

            Assert.AreEqual("F4", move.ToString(), "Incorrect Move.ToString() instance result.");
        }
    }
}
