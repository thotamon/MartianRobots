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

        MartianSurface IScene.Surface { get; set; }

        MartianRobot IScene.Robot { get; set; }

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

            if (this._currentRobot != null)
            {
                this._output(this._currentRobot.ToString());
            }
            this._currentRobot = null;
        }
    }
}
