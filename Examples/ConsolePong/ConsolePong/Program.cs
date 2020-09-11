using System;
using System.IO;
using System.Threading;

namespace ConsolePong
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Console.WriteLine("Pong using ComfishGL by Daxanius!");
            Console.WriteLine();

            Pong game = new Pong();
            game.Game();
        }
    }
}
