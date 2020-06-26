using MartianRobots.Core;
using MartianRobots.Core.Mars;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MartianRobots.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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
