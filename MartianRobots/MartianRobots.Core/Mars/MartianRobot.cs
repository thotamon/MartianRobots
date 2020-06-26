namespace MartianRobots.Core
{
    using MartianRobots.Core.Enums;

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
            return $"{this.X} {this.Y} {this.Orientation}";
        }
    }
}
