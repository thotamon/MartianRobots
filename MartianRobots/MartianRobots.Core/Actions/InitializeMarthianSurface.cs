namespace MartianRobots.Core.Actions
{
    using MartianRobots.Core.Mars;
    using System;

    /// <summary>
    /// This action creates marthian surface as rectangle field of given size
    /// </summary>
    public sealed class InitializeMarthianSurface : ISceneAction
    {
        private readonly int _width;
        private readonly int _height;

        public InitializeMarthianSurface(int width, int heigth)
        {
            if (width <= 0 || width > 50)
            {
                throw new ArgumentException(nameof(width));
            }

            if (heigth <= 0 || heigth > 50)
            {
                throw new ArgumentException(nameof(heigth));
            }

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
