using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            // поле 
            int n = 0, m = 0;
            // Уровень сложности 
            Console.SetCursorPosition(50, 5);
            Console.WriteLine("Select difficulty");
            Console.SetCursorPosition(50, 6);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1) Easy - [Field Size 10х10, Slow speed]");
            Console.SetCursorPosition(50, 7);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("2) Normal - [Field Size 15х15, Average speed]");
            Console.SetCursorPosition(50, 8);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3) Hard - [Field Size 20х20, Fast speed]");
            Console.SetCursorPosition(65, 10);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Выбор: ");
            int IdOfComplexity = Convert.ToInt32(Console.ReadLine());

            switch (IdOfComplexity)
            {
                case 1:
                    n = 10;
                    m= 10;              
                    Console.Clear();
                    break;
                case 2:
                    n = 15;
                    m = 15;
                    Console.Clear();
                    break;
                case 3:
                    n = 20;
                    m = 20;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Id does not exist");
                    Console.WriteLine("Game Over");
                    break;
            }
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
            Console.ReadKey();
        }
    }
}
