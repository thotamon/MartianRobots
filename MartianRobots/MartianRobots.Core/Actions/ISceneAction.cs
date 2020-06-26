namespace MartianRobots.Core
{
    using MartianRobots.Core.Mars;

    /// <summary>
    /// Interface to allow actions on marthian scene
    /// </summary>
    public interface ISceneAction
    {
        bool Act(IScene scene);
    }
}
