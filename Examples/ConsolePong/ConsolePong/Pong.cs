using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FishcomGL;

namespace ConsolePong
{
    class Pong
    {
        public Window window = new Window(34, 12);
        public Random random = new Random();
        
        public Player player1 = new Player(new Vector2(1, 4), 3);
        public Player player2 = new Player(new Vector2(33, 0), 3);
        public Ball ball = new Ball(new Vector2(10, 5));

        public void Game()
        {
            bool swap = true;
            int Distortion = random.Next(-1, 2);

            ball.Draw(window);
            player1.Draw(window);
            player2.Draw(window);

            window.Draw();

            while (true)
            {
                ball.Draw(window);
                player1.Draw(window);
                player2.Draw(window);


                if (window.GetPixel(new Vector2(ball.position.x + 1, ball.position.y)).character != ' ' || window.GetPixel(new Vector2(ball.position.x - 1, ball.position.y)).character != ' ')
                {
                    swap = !swap;
                    Distortion = random.Next(-1, 2);
                }

                if (swap)
                {
                    ball.position.x++;
                }
                else
                {
                    ball.position.x--;
                }

                if (ball.position.y <= 0 || ball.position.y >= window.GetWindowSize().y - 1)
                {
                    Distortion *= -1;
                }

                ball.position.y += Distortion;

                if (ball.position.x <= 0 || ball.position.x >= window.GetWindowSize().x)
                {
                    break;
                }

                if (player2.position.y + 1 != ball.position.y) {
                        if (ball.position.y > player2.position.y)
                        {
                        player2.position.y = Math.Clamp(player2.position.y + 1, 0, window.GetWindowSize().y - 3);
                    }
                        else
                        {
                        player2.position.y = Math.Clamp(player2.position.y - 1, 0, window.GetWindowSize().y - 3);
                        }
                }

                window.Draw();
                window.ClearScreen();

                Thread.Sleep(50);

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            player1.position.y = Math.Clamp(player1.position.y - 1, 0, window.GetWindowSize().y - 3);
                            break;
                        case ConsoleKey.DownArrow:
                            player1.position.y = Math.Clamp(player1.position.y + 1, 0, window.GetWindowSize().y - 3);
                            break;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Pong using FishcomGL");
            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("- Daxanius");
            Console.WriteLine();

            Console.Write("Press any key to continue. . .");
            Console.ReadKey();

            Console.SetCursorPosition(0, Console.CursorTop + 1);
        }
    }
}
