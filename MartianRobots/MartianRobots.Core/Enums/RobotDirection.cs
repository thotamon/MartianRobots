namespace MartianRobots.Core.Enums
{
    using System.ComponentModel;

    public enum RobotDirection
    {
        [Description("L")]
        Left = 0,

        [Description("R")]
        Right,

        [Description("F")]
        Forward
    }
}