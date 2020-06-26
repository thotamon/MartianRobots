namespace MartianRobots.Core.Actions
{
    using MartianRobots.Core.Enums;
    using MartianRobots.Core.Mars;
    using System;

    /// <summary>
    /// Action represention robot move operation
    /// </summary>
    public class MartianRobotMoveAction : ISceneAction
    {
        public int Step { get; }

        public MartianRobotMoveAction(int step = 1)
        {
            this.Step = step;
        }

        public bool Act(IScene scene)
        {
            if (scene == null)
            {
                throw new ArgumentNullException(nameof(scene));
            }

            if (scene.Robot == null || scene.Robot.IsLost)
            {
                return false;
            }

            var robot = scene.Robot;
            var surface = scene.Surface;

            switch (robot.Orientation)
            {
                case RobotOrientation.East:
                {
                    var step = this.Step;
                    while (step > 0)
                    {
                        if (robot.X + 1 == surface.Width)
                        {
                            if (!surface[robot.X, robot.Y])
                            {
                                return true;
                            }

                            surface[robot.X, robot.Y] = false;
                            robot.Lose();
                            return false;
                        }

                        robot.X += 1;
                        step--;
                    }

                    break;
                }
                case RobotOrientation.West:
                {
                    var step = this.Step;
                    while (step > 0)
                    {
                        if (robot.X == 0)
                        {
                            if (!surface[robot.X, robot.Y])
                            {
                                return true;
                            }

                            surface[robot.X, robot.Y] = false;
                            robot.Lose();
                            return false;
                        }

                        robot.X -= 1;
                        step--;
                    }
                    break;
                }
                case RobotOrientation.North:
                {
                    var step = this.Step;
                    while (step > 0)
                    {
                        if (robot.Y + 1 == surface.Height)
                        {
                            if (!surface[robot.X, robot.Y])
                            {
                                return true;
                            }

                            surface[robot.X, robot.Y] = false;
                            robot.Lose();
                            return false;
                        }

                        robot.Y += 1;
                        step--;
                    }
                    break;
                }
                case RobotOrientation.South:
                {
                    var step = this.Step;
                    while (step > 0)
                    {
                        if (robot.Y == 0)
                        {
                            if (!surface[robot.X, robot.Y])
                            {
                                return true;
                            }

                            surface[robot.X, robot.Y] = false;
                            robot.Lose();
                            return false;
                        }

                        robot.Y -= 1;
                        step--;
                    }
                    break;
                }
            }

            return true;
        }
    }
}
