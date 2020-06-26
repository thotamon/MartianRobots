namespace MartianRobots.Core
{
    using MartianRobots.Core.Mars;

    public interface ISceneAction
    {
        bool Act(IScene scene);
    }
}
