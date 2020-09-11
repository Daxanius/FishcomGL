using FishcomGL;
using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Net.NetworkInformation;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;

namespace FishcomGL
{
    public class Window
    {
        private Vector2 _windowSize;
        private Vector2 _cameraPosition;
        private char _character = ' ';

        public List<Pixel> pixels = new List<Pixel>();

        public string defaultBackgroundColor = Console.BackgroundColor.ToString(), defaultForeGroundColor = Console.ForegroundColor.ToString();

        public Window(int windowSizeX, int windowSizeY)
        {
            _windowSize = new Vector2(windowSizeX,windowSizeY);
            _cameraPosition = new Vector2(0, 0);
        }

        public void SetChar(char character)
        {
            _character = character;
        }

        public void SetCameraPosition(Vector2 cameraPosition)
        {
            _cameraPosition = cameraPosition;
        }

        public void SetPixel(Vector2 position, char character = 'X', string backGroundColor = "BLACK", string foreGroundColor = "WHITE")
        {
            int pos = GetPixelArrayPosition(position);
            if (pos != -1)
            {
                if (pixels[pos].character == character || character == _character)
                {
                    pixels.RemoveAt(pos);
                }
            }

            if (character != _character && backGroundColor != defaultBackgroundColor.ToUpper() && foreGroundColor != defaultBackgroundColor.ToUpper())
            {
                pixels.Add(new Pixel(position,character,backGroundColor,foreGroundColor));
            }
        }

        public int GetPixelArrayPosition(Vector2 position)
        {
            int res = -1;

            for (int i = 0; i <= (pixels.Count - 1); i++)
            {
                if (pixels[i].position.x == position.x && pixels[i].position.y == position.y)
                {
                    res = i;
                    break;
                }
            }

            return res;
        }

        public Pixel GetPixel(Vector2 position)
        {
            Pixel pixel = new Pixel(position, _character, defaultBackgroundColor, defaultForeGroundColor);
            int pos = GetPixelArrayPosition(position);

            if (pos != -1)
            {
                pixel = pixels[pos];
            }

            return pixel;
        }


        public Vector2 GetWindowSize()
        {
            return _windowSize;
        }

        public Vector2 GetCameraPosition()
        {
            return _cameraPosition;
        }

        public char GetChar()
        {
            return _character;
        }
        public void ClearScreen()
        {
            // This is really appreciated
            pixels.Clear();
        }

        public void LoadImage(string path, Vector2 position, char c = 'X')
        {
            Bitmap img = new Bitmap(@path);

            for (int j = 0; j < img.Height; j++)
            {
                for (int i = 0; i < (img.Width * 2); i++)
                {
                    Color pixel = img.GetPixel(i / 2, j);

                    string color = ColorHandler.ClosestConsoleColor(pixel.R, pixel.G, pixel.B).ToString().ToUpper();
                    SetPixel(new Vector2(i + position.x, j + position.y), c, color, color);
                }
            }
        }

        public void Draw(bool overwrite = true)
        {
            Vector2 position = new Vector2(_cameraPosition.x, _cameraPosition.y);

            int CursorPosY = Console.CursorTop;

            if (CursorPosY >= _windowSize.y)
            {
                CursorPosY -= _windowSize.y;
            }

            if (overwrite)
            {
                Console.SetCursorPosition(0, CursorPosY);
            }

            while (position.y - _cameraPosition.y < _windowSize.y)
            {
                while (position.x - _cameraPosition.x <= _windowSize.x)
                {
                    for (int i = 0; i <= (pixels.Count - 1); i++)
                    {
                        if (pixels[i].position.x == position.x && pixels[i].position.y == position.y)
                        {
                            ColorHandler.SetConsoleColor(pixels[i].backGroundColor, pixels[i].foreGroundColor);

                            Console.Write(pixels[i].character);

                            ColorHandler.SetConsoleColor(defaultBackgroundColor, defaultForeGroundColor);
                            break;
                        }
                        else if (i == (pixels.Count - 1))
                        {
                            Console.Write(_character);
                        }
                    }
                    position.x++;
                }
                Console.WriteLine();
                position.x = _cameraPosition.x;
                position.y++;
            }
        }
    }
}
