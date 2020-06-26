using MartianRobots.Core.Mars;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Core.Actions
{
    public class MartianRobotMoveAction : ISceneAction
    {
        public int Step { get; }

        public MartianRobotMoveAction(int step = 1)
        {
            this.Step = step;
        }

        public bool Act(IScene scene)
        {
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
                        if (robot.X + 1 >= surface.Width && surface[robot.X, robot.Y])
                        {
                            surface[robot.X, robot.Y] = false;
                            robot.X = robot.X + 1;
                            robot.Lose();
                            return false;
                        }

                        robot.X = robot.X + 1;
                        step--;
                    }

                    break;
                }
                case RobotOrientation.West:
                    {
                        var step = this.Step;
                        while (step > 0)
                        {
                            if (robot.X - 1 < 0 && surface[robot.X, robot.Y])
                            {
                                surface[robot.X, robot.Y] = false;
                                robot.X = robot.X - 1;
                                robot.Lose();
                                return false;
                            }

                            robot.X = robot.X - 1;
                            step--;
                        }
                        break;
                    }
                case RobotOrientation.North:
                    {
                        var step = this.Step;
                        while (step > 0)
                        {
                            if (robot.Y + 1 >= surface.Height && surface[robot.X, robot.Y])
                            {
                                surface[robot.X, robot.Y + 1] = false;
                                robot.Y = robot.Y + 1;
                                robot.Lose();
                                return false;
                            }

                            robot.Y = robot.Y + 1;
                            step--;
                        }
                        break;
                    }
                case RobotOrientation.South:
                    {
                        var step = this.Step;
                        while (step > 0)
                        {
                            if (robot.Y - 1 < 0 && surface[robot.X, robot.Y])
                            {
                                surface[robot.X, robot.Y] = false;
                                robot.Y = robot.Y - 1;
                                robot.Lose();
                                return false;
                            }

                            robot.Y = robot.Y - 1;
                            step--;
                        }
                        break;
                    }
            }

            return true;
        }
    }
}
