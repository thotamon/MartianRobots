using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Core
{
    public interface IMartianRobotAction
    {
        bool Act(MartianRobot robot, MartianSurface surface);
    }
}
