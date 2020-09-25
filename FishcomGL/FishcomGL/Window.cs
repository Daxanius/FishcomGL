using System;
using System.Collections.Generic;
using System.Drawing;

namespace FishcomGL
{
    public class Window
    {
        private List<Pixel> pixels = new List<Pixel>();

        private Vector2 _windowSize;
        private Vector2 _cameraPosition;

        public char defaultChar = ' ';
        public string defaultBackgroundColor = Console.BackgroundColor.ToString().ToUpper(), defaultForeGroundColor = Console.ForegroundColor.ToString().ToUpper();

        public Window(int windowSizeX, int windowSizeY)
        {
            _windowSize = new Vector2(windowSizeX,windowSizeY);
            _cameraPosition = new Vector2(0, 0);
        }

        // Gets the position of the specified pixel in the pixels array.
        private int GetPixelArrayPosition(Vector2 position)
        {
            // The default result is -1 meaning that if it returns -1 that pixel doesn't exist.
            int res = -1;

            // Searches the array for the specified pixel and returns it's array position if it exists.
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

        // Gets the pixel at the specified position.
        public Pixel GetPixel(Vector2 position)
        {
            // Will return the default background pixel if the pixel doesn't exists.
            Pixel pixel = new Pixel(position, defaultChar, defaultBackgroundColor, defaultForeGroundColor);

            // Checks if the pixel exists before fetching it from the array.
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

        public void SetCameraPosition(Vector2 cameraPosition)
        {
            _cameraPosition = cameraPosition;
        }

        // Sets a pixel on the screeen with the given values.
        public void SetPixel(Vector2 position, char character = ' ', string backGroundColor = "BLACK", string foreGroundColor = "WHITE")
        {
            // Checks if a pixel already exists at that position.
            int pos = GetPixelArrayPosition(position);
            if (pos != -1)
            {
                pixels.RemoveAt(pos);
            }

            // Checks if the pixel isn't the default background pixel before adding it to the list.
            if (character != defaultChar || backGroundColor != defaultBackgroundColor || foreGroundColor != defaultForeGroundColor)
            {
                pixels.Add(new Pixel(position, character, backGroundColor, foreGroundColor));
            }
        }

        // Removes a specified pixel.
        public void RemovePixel(Vector2 position)
        {
            // Checks if the pixel exists in the array.
            int pos = GetPixelArrayPosition(position);
            if (pos != -1)
            {
                pixels.RemoveAt(pos);
            }
        }

        // Clears all the pixels from the window.
        public void ClearScreen()
        {
            // Clears the list of pixels.
            pixels.Clear();
        }

        public void LoadImage(Vector2 position, string path, char c = ' ')
        {
            // Creates a bitmap for the image
            Bitmap img = new Bitmap(@path);

            // Will read every pixel of the image from left to right, top to bottom and add it to the pixel array.
            for (int j = 0; j < img.Height; j++)
            {
                for (int i = 0; i < (img.Width * 2); i++)
                {
                    // Doubles the X value to make sure the picture isn't distorted.
                    Color pixel = img.GetPixel(i / 2, j);

                    string color = ColorHandler.ClosestConsoleColor(pixel.R, pixel.G, pixel.B).ToString().ToUpper();

                    if (color != "BLACK")
                    {
                        SetPixel(new Vector2(i + position.x, j + position.y), c, color, color);
                    }
                }
            }
        }

        // Draws the window.
        public void Draw(bool overwrite = true)
        {
            Vector2 position = new Vector2(_cameraPosition.x, _cameraPosition.y);

            // Gets the cursor height at the start of drawing a window, to make sure it doesn't overwrite text in de console.
            int CursorPosY = Console.CursorTop;

            // I don't exactly remember why I did this, but it had a reason. ¯\_(ツ)_/¯
            if (CursorPosY >= _windowSize.y)
            {
                CursorPosY -= _windowSize.y;
            }

            // Sets the cursor position at it's beginning to overwrite the previous drawing.
            if (overwrite)
            {
                Console.SetCursorPosition(0, CursorPosY);
            }

            // Will read every position from left to right, top to bottom and checks if a pixel coresponds for each pixel in the array.
            while (position.y - _cameraPosition.y < _windowSize.y)
            {
                while (position.x - _cameraPosition.x < _windowSize.x)
                {
                    // Checks each pixel in the array to match to the current position.
                    for (int i = 0; i <= (pixels.Count - 1); i++)
                    {
                        if (pixels[i].position.x == position.x && pixels[i].position.y == position.y)
                        {
                            ColorHandler.SetConsoleColor(pixels[i].backGroundColor, pixels[i].foreGroundColor);
                            Console.Write(pixels[i].character);
                            Console.ResetColor();

                            break;
                        }
                        else if (i == (pixels.Count - 1))
                        {
                            ColorHandler.SetConsoleColor(defaultBackgroundColor, defaultForeGroundColor);
                            Console.Write(defaultChar);
                            Console.ResetColor();
                        }
                    }
                    position.x++;
                }
                // Next line
                Console.WriteLine();
                position.x = _cameraPosition.x;
                position.y++;
            }
        }
    }
}
