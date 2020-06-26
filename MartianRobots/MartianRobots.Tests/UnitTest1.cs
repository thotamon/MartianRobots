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
            Assert.AreEqual(0, log.Count);

            inputController.ProcessLine("1 1 E");
            Assert.AreEqual(0, log.Count);

            inputController.ProcessLine("RFRFRFRF");
            Assert.IsNotNull(log.Last());

            inputController.ProcessLine("3 2 N");
            Assert.IsNotNull(log.Last());

            inputController.ProcessLine("FRRFLLFFRRFLL");
            Assert.AreEqual("3 3 N LOST", log.Last());

            inputController.ProcessLine("0 3 W");
            Assert.IsNotNull(log.Last());

            inputController.ProcessLine("LLFFFLFLFL");
            Assert.IsNotNull(log.Last());
        }
    }
}
