using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarLanes;

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

            Assert.AreEqual("F4", StarLanes.Move.ToString(x, y), "Incorrect Move.ToString() static result");

            StarLanes.Move move = new StarLanes.Move(x, y);

            Assert.AreEqual("F4", move.ToString(), "Incorrect Move.ToString() instance result.");
        }
    }
}
