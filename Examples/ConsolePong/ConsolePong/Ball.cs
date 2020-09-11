using FishcomGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsolePong
{
    class Ball
    {
        public Vector2 position;

        public Ball(Vector2 position)
        {
            this.position = position;
        }

        public void Draw(Window window)
        {
            window.SetPixel(position, 'X', "RED", "RED");
        }
    }
}
