namespace MartianRobots.Core.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// Robot orientation
    /// </summary>
    public enum RobotOrientation
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

}
