using MartianRobots.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MartianRobots.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMoveAndLost()
        {
            var log = new List<string>();
            var inputController = new InputController(s => log.Add(s));

            inputController.ProcessLine("4 4");
            inputController.ProcessLine("0 0 W");
            Assert.AreEqual(0, log.Count);

            inputController.ProcessLine("F");
            Assert.AreEqual("0 0 W LOST", log.Last());

            log.Clear();
            inputController.ProcessLine("0 0 N");
            inputController.ProcessLine("FFFFF");
            Assert.AreEqual(0, log.Count);
        }

        [TestMethod]
        public void TestRoundMoveInPlace()
        {
            var log = new List<string>();
            var inputController = new InputController(s => log.Add(s));

            inputController.ProcessLine("4 4");
            inputController.ProcessLine("0 0 W");
            inputController.ProcessLine("LLLL");
            Assert.AreEqual("0 0 W", log.Last());
        }

        [TestMethod]
        public void TestPlaceRobotOutsideSurface()
        {
            var log = new List<string>();
            var inputController = new InputController(s => log.Add(s));

            inputController.ProcessLine("4 4");
            inputController.ProcessLine("6 6 W");

            Assert.AreEqual(0, log.Count);
        }

        [TestMethod]
        public void TestSequenceWithLostRobots()
        {
            var log = new List<string>();
            var inputController = new InputController(s => log.Add(s));

            inputController.ProcessLine("5 3");
            inputController.ProcessLine("1 1 E");
            Assert.AreEqual(0, log.Count);

            inputController.ProcessLine("RFRFRFRF");
            Assert.AreEqual("1 1 E", log.Last());

            inputController.ProcessLine("3 2 N");
            inputController.ProcessLine("FRRFLLFFRRFLL");
            Assert.AreEqual("3 3 N LOST", log.Last());

            inputController.ProcessLine("0 3 W");
            inputController.ProcessLine("LLFFFLFLFL");
            Assert.AreEqual("2 3 S", log.Last());
        }
    }
}
