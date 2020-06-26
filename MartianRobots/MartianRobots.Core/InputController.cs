using MartianRobots.Core.Mars;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Core
{
    public sealed class InputController
    {
        private enum State
        {
            None = 0,
            SurfaceCreated,
            RobotPlaced
        }

        private readonly Scene _scene;
        private readonly Action<string> _output;

        private State _state = State.None;

        public InputController(Action<string> output)
        {
            this._output = output;
            this._scene = new Scene(output);
        }

        public void ProcessLine(string line)
        {
            this._scene.Action(MartianRobotCommandParser.Parse(line));
            switch (this._state)
            {
                case State.None:
                {
                    if (((IScene)this._scene).Surface != null)
                    {
                        this._state = State.SurfaceCreated;                        
                    }

                    break;
                }
                case State.SurfaceCreated:
                {
                    if (((IScene)this._scene).Robot != null)
                    {
                        this._state = State.RobotPlaced;
                    }
                    break;
                }
                case State.RobotPlaced:
                {
                    this._output(((IScene)this._scene).Robot.ToString());
                    ((IScene)this._scene).Robot = null;
                    this._state = State.SurfaceCreated;
                    break;
                }
            };
        }
    }
}
