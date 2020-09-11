using System;
using System.Collections.Generic;
using System.Text;

namespace FishcomGL
{
    public class Pixel
    {
        public Vector2 position;

        public char character;

        public string backGroundColor;
        public string foreGroundColor;

        public Pixel(Vector2 position, char character, string backGroundColor, string foreGroundColor)
        {
            this.position = position;

            this.character = character;

            this.backGroundColor = backGroundColor;
            this.foreGroundColor = foreGroundColor;
        }
    }
}
