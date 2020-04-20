using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            // поле 
            int n = 10;
            int m = 10;
            // фрукт
            int xz = 0, yz = 0, xv = 0, yv = 0, size = 1;

            ConsoleKeyInfo f;
            string move = "";
            bool eat = false;
            String[,] map = new string[n, m];
            int[] masx = new int[size];
            int[] masy = new int[size];
            bool game = true;
            Game.Otrisovka(n, m, ref xz, ref yz, ref yv, ref xv, ref map);

            while (game == true) // зацикливаем
            {
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }
                // движение 
                if (Console.KeyAvailable == true)
                {
                    f = Console.ReadKey();
                    if (f.Key == ConsoleKey.UpArrow)
                        if (move != "Down")
                            move = "Up";
                    if (f.Key == ConsoleKey.DownArrow)
                        if (move != "Up")
                            move = "Down";
                    if (f.Key == ConsoleKey.RightArrow)
                        if (move != "Left")
                            move = "Right";
                    if (f.Key == ConsoleKey.LeftArrow)
                        if (move != "Right")
                            move = "Left";
                }
                Game.Move(n, m, ref xz, ref yz, move, ref map);
                Game.EatGenerate(n, m, ref map, ref xv, ref yv, xz, yz, ref eat, masx, masy);
                Game.Tail(ref masx, ref masy, ref map, ref eat, ref size, xz, yz);
                Game.Lose(n, m, masx, masy, xz, yz, ref game, size);
                Game.Win(n, m, map, ref game);
                System.Threading.Thread.Sleep(400);
            }
        }
    }
}
