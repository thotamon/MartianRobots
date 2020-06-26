using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Core.Mars
{
    public interface IScene
    {
        MartianSurface Surface { get; set; }
        MartianRobot Robot { get; set; }
    }

    public sealed class Scene: IScene
    {
        private MartianRobot _currentRobot;
        private MartianSurface _surface;
        private Action<string> _output;

        MartianSurface IScene.Surface 
        {
            get => this._surface;
            set => this._surface = value;
        }

        MartianRobot IScene.Robot 
        {
            get => this._currentRobot;
            set => this._currentRobot = value;
        }

        public Scene(Action<string> output)
        {
            this._output = output;
        }

        public void Action(IEnumerable<ISceneAction> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException(nameof(actions));
            }

            foreach(var action in actions)
            {
                if (!action.Act(this))
                {
                    // log error
                }
            }
        }
    }
}
