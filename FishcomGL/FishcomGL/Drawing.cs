using System;
using System.Collections.Generic;
using System.Text;

namespace FishcomGL
{
    public static class Drawing
    {
        // Bresenham's Line Algorithm that connects two given dots
        // Stolen from the internet because MATH
        public static void DrawLine(Window window,Vector2 point0, Vector2 point1)
        {
            bool steep = Math.Abs(point1.y - point0.y) > Math.Abs(point1.x - point0.x);
            if (steep)
            {
                int t;
                t = point0.x; // swap x0 and y0
                point0.x = point0.y;
                point0.y = t;
                t = point1.x; // swap x1 and y1
                point1.x = point1.y;
                point1.y = t;
            }
            if (point0.x > point1.x)
            {
                int t;
                t = point0.x; // swap x0 and x1
                point0.x = point1.x;
                point1.x = t;
                t = point0.y; // swap y0 and y1
                point0.y = point1.y;
                point1.y = t;
            }
            int dx = point1.x - point0.x;
            int dy = Math.Abs(point1.y - point0.y);
            int error = dx / 2;
            int ystep = (point0.y < point1.y) ? 1 : -1;
            int y = point0.y;
            for (int x = point0.x; x <= point1.x; x++)
            {
                window.SetPixel(new Vector2((steep ? y : x), (steep ? x : y)), 'X');
                error = error - dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
        }

        public static void DrawCircle(Window window, Vector2 position, int radius)

        {
            for (double i = 0.0; i < 360.0; i += 0.1)
            {
                double angle = i * System.Math.PI / 180;
                
                int y = (int)(position.y + radius * System.Math.Sin(angle));
                int x = (int)(position.x + radius * System.Math.Cos(angle));

                window.SetPixel(new Vector2(x, y), 'X');
            }
        }
    }
}
