namespace MartianRobots.Core.Actions
{
    using MartianRobots.Core.Mars;

    public sealed class InitializeMarthianSurface : ISceneAction
    {
        private readonly int _width;
        private readonly int _height;

        public InitializeMarthianSurface(int width, int heigth)
        {
            this._width = width;
            this._height = heigth;
        }

        public bool Act(IScene scene)
        {
            if (scene.Surface != null)
            {
                return false;
                //throw new InvalidOperationException($"Can not overwrite existing marthian surface");
            }

            scene.Surface = new MartianSurface(this._width, this._height);
            return true;
        }
    }
}
