using System;
using System.Collections.Generic;
using System.Text;

namespace FishcomGL
{
    public static class ColorHandler
    {
        public static ConsoleColor ClosestConsoleColor(byte r, byte g, byte b)
        {
            ConsoleColor ret = 0;
            double rr = r, gg = g, bb = b, delta = double.MaxValue;

            foreach (ConsoleColor cc in Enum.GetValues(typeof(ConsoleColor)))
            {
                var n = Enum.GetName(typeof(ConsoleColor), cc);
                var c = System.Drawing.Color.FromName(n == "DarkYellow" ? "Orange" : n); // bug fix
                var t = Math.Pow(c.R - rr, 2.0) + Math.Pow(c.G - gg, 2.0) + Math.Pow(c.B - bb, 2.0);
                if (t == 0.0)
                    return cc;
                if (t < delta)
                {
                    delta = t;
                    ret = cc;
                }
            }
            return ret;
        }

        public static void SetConsoleColor(string backGroundColor, string foreGroundColor)
        {
            switch (backGroundColor)
            {
                case "RED":
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case "GREEN":
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case "BLUE":
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case "WHITE":
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                case "BLACK":
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case "GRAY":
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;
                case "MAGENTA":
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                case "CYAN":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
                case "YELLOW":
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case "DARKBLUE":
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                case "DARKCYAN":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    break;
                case "DARKGRAY":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case "DARKGREEN":
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                case "DARKMAGENTA":
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "DARKRED":
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case "DARKYELLOW":
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }

            switch (foreGroundColor)
            {
                case "RED":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "GREEN":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "BLUE":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "WHITE":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "BLACK":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "GRAY":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "MAGENTA":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "CYAN":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "YELLOW":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "DARKBLUE":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "DARKCYAN":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "DARKGRAY":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "DARKGREEN":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "DARKMAGENTA":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "DARKRED":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "DARKYELLOW":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }
    }
}
