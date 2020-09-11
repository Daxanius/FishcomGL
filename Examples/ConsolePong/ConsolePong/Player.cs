using System;
using System.Collections.Generic;
using System.Text;
using FishcomGL;

namespace ConsolePong
{
    class Player
    {
        public Vector2 position;
        public int size;

        public Player(Vector2 position, int size)
        {
            this.position = position;
            this.size = size;
        }

        public void Draw(Window window)
        {
            for (int i = 0; i < size; i++)
            {
                // all parameters are required to draw a pixel, this needs to be fixed in FishcomGL
                window.SetPixel(new Vector2(position.x, i + position.y), 'X', "WHITE", "WHITE");
            }
        }
    }
}
