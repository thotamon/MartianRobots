namespace MartianRobots.Core.Actions
{
    using MartianRobots.Core.Enums;
    using MartianRobots.Core.Mars;
    using System;
    using System.Collections.Generic;

    public class MartianRobotRotateAction : ISceneAction
    {
        private readonly RobotDirection _direction;

        private readonly Dictionary<RobotOrientation, RobotOrientation> left = new Dictionary<RobotOrientation, RobotOrientation>
        {
            { RobotOrientation.East, RobotOrientation.North },
            { RobotOrientation.West, RobotOrientation.South },
            { RobotOrientation.North, RobotOrientation.West },
            { RobotOrientation.South, RobotOrientation.East }
        };

        private readonly Dictionary<RobotOrientation, RobotOrientation> right = new Dictionary<RobotOrientation, RobotOrientation>
        {
            { RobotOrientation.East, RobotOrientation.South },
            { RobotOrientation.West, RobotOrientation.North },
            { RobotOrientation.North, RobotOrientation.East },
            { RobotOrientation.South, RobotOrientation.West }
        };

        public MartianRobotRotateAction(RobotDirection direction)
        {
            if (direction == RobotDirection.Forward)
            {
                throw new ArgumentException(nameof(direction));
            }

            this._direction = direction;
        }

        public bool Act(IScene scene)
        {
            var robot = scene.Robot;
            
            if (robot == null || robot.IsLost)
            {
                return false;
            }

            var rotation = this._direction == RobotDirection.Left
                ? this.left
                : this.right;

            robot.Orientation = rotation[robot.Orientation];

            return true;
        }
    }
}
