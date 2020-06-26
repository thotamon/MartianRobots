
namespace MartianRobots.Core.Actions
{
    using MartianRobots.Core.Enums;
    using MartianRobots.Core.Mars;
    using System;

    /// <summary>
    /// Action representing place robot on marthian surface operation
    /// </summary>
    public sealed class PlaceRobotAction : ISceneAction
    {
        private readonly int _x;
        private readonly int _y;
        private readonly RobotOrientation _orientation;

        public PlaceRobotAction(int x, int y, RobotOrientation orientation)
        {
            if (x < 0 || x > 50)
            {
                throw new ArgumentException(nameof(x));
            }

            if (y < 0 || y > 50)
            {
                throw new ArgumentException(nameof(y));
            }

            this._x = x;
            this._y = y;
            this._orientation = orientation;
        }

        public bool Act(IScene scene)
        {
            if (scene == null)
            {
                throw new ArgumentNullException(nameof(scene));
            }

            if (scene.Surface == null)
            {
                return false;
            }

            if (this._x >= 0 && this._x < scene.Surface.Width && this._y >= 0 && this._y < scene.Surface.Height && scene.Surface[this._x, this._y])
            {
                scene.Robot = new MartianRobot(this._x, this._y, this._orientation);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
