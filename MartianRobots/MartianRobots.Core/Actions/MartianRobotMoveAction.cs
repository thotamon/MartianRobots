using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Core.Actions
{
    public class MartianRobotMoveAction : IMartianRobotAction
    {
        public int Step { get; }

        public MartianRobotMoveAction(int step = 1)
        {
            this.Step = step;
        }

        public bool Act(MartianRobot robot, MartianSurface surface)
        {

        }
    }
}
