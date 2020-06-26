using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MartianRobots.Core
{
    public class MartianSurface
    {
        private readonly BitArray avalaibleFields;

        public int Width { get; }
        public int Height { get; }

        public bool this[int x, int y]
        {
            get => this.avalaibleFields[this.Width * x + y];
            set => this.avalaibleFields[this.Width * x + y] = value;
        }

        public MartianSurface(int width, int height)
        {
            if (width < 1 || width > 50)
            {
                throw new ArgumentException(nameof(width));
            }

            if (height < 1 || height > 50)
            {
                throw new ArgumentException(nameof(height));
            }

            this.avalaibleFields = new BitArray(width * height, true);
            this.Width = width;
            this.Height = height;
        }
    }
}
