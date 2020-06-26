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
            var scene = new Scene(s => log.Add(s));

            var line1 = MartianRobotCommandParser.Parse("5 3");
            scene.Action(line1);
            Assert.IsNotNull(log.Last());

            var line2 = MartianRobotCommandParser.Parse("1 1 E");
            scene.Action(line2);
            Assert.IsNotNull(log.Last());

            var line3 = MartianRobotCommandParser.Parse("RFRFRFRF");
            scene.Action(line3);
            Assert.IsNotNull(log.Last());

            var line4 = MartianRobotCommandParser.Parse("3 2 N");
            scene.Action(line4);
            Assert.IsNotNull(log.Last());

            var line5 = MartianRobotCommandParser.Parse("FRRFLLFFRRFLL");
            scene.Action(line5);
            Assert.IsNotNull(log.Last());

            var line6 = MartianRobotCommandParser.Parse("03 W");
            scene.Action(line6);
            Assert.IsNotNull(log.Last());

            var line7 = MartianRobotCommandParser.Parse("LLFFFLFLFL");
            scene.Action(line7);
            Assert.IsNotNull(log.Last());
        }
    }
}
