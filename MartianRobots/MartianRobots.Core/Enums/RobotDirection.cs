namespace MartianRobots.Core.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// Robot direction 
    /// </summary>
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