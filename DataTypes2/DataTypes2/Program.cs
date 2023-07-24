using System;

namespace DataTypes2
{
    class Program
    {
        static void Main(string[] args)
        {
            string row = "y";
            while (row == "y")
            {
                Console.WriteLine("Введите значение x: ");
                double x;
                while (!double.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine("Ошибка при введении числа! Введите новое значение x: ");
                }
                Console.WriteLine("Введите значение y: ");
                double y;
                while (!double.TryParse(Console.ReadLine(), out y))
                {
                    Console.WriteLine("Ошибка при введении числа! Введите новое значение y: ");
                }
                bool isBeInArea = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) <= 1 && y <= 1 - x && y >= -1 - x;
                Console.WriteLine($"Точка A с координатами ({x}; {y}) принадлежит области допустимых значений? {isBeInArea}");
                Console.WriteLine("Хотите продолжить!\ty/n");
                row = Console.ReadLine();
                while (row != "y" && row != "n")
                {
                    Console.WriteLine("Ошибка! Хотите продолжить!\ty/n");
                    row = Console.ReadLine();
                }
            }
        }
    }
}
