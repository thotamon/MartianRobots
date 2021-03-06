﻿namespace MartianRobots.Core
{
    using MartianRobots.Core.Enums;

    /// <summary>
    /// Marthian robot 
    /// </summary>
    public class MartianRobot
    {
        public RobotOrientation Orientation { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public bool IsLost { get; private set; }

        public MartianRobot(int x, int y, RobotOrientation orientation)
        {
            this.X = x;
            this.Y = y;
            this.Orientation = orientation;
            this.IsLost = false;
        }

        public void Lose()
        {
            this.IsLost = true;
        }

        public override string ToString()
        {
            return this.IsLost
                ? $"{this.X} {this.Y} {DescriptionHelper.GetEnumDescription(this.Orientation)} LOST"
                : $"{this.X} {this.Y} {DescriptionHelper.GetEnumDescription(this.Orientation)}";
        }
    }
}
