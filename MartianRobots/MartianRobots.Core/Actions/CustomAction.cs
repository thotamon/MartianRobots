
namespace MartianRobots.Core.Actions
{
    using MartianRobots.Core.Mars;
    using System;

    public sealed class CustomAction : ISceneAction
    {
        private readonly Func<IScene, bool> _action;
        public CustomAction(Func<IScene, bool> action)
        {
            this._action = action;
        }

        public bool Act(IScene scene)
        {
            return this._action(scene);
        }
    }
}
