using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MartianRobots.Core
{
    public enum Direction
    {
        [Description("N")]
        North = 0,

        [Description("E")]
        East,

        [Description("S")]
        South,

        [Description("W")]
        West
    }

    public class MartianRobot
    {
        public Direction Direction { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public MartianRobot(int x, int y, Direction direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }

        public override string ToString()
        {
            return $"{this.X} {this.Y} {this.Direction}";
        }
    }
}
