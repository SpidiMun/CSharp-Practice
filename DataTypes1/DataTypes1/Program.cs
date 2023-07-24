using System;

namespace DataTypes1
{
    class Program
    {
        static void Main(string[] args)
        {
            string row = "y";
            while (row == "y")
            {
                Console.Clear();
                Console.WriteLine("Введите значение n: ");
                double n;
                while (!double.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Ошибка при введении числа! Введите новое значение n: ");
                }
                Console.WriteLine("Введите значение m: ");
                double m;
                while (!double.TryParse(Console.ReadLine(), out m))
                {
                    Console.WriteLine("Ошибка при введении числа! Введите новое значение m: ");
                }
                double intResult = n++ * --m;
                Console.WriteLine($"1) n = {n}; " +
                                  $"m = {m}; " +
                                  $"n++*--m = {intResult}\n");
                bool boolResult1 = n-- < m++;
                Console.WriteLine($"2) n = {n}; " +
                                  $"m = {m}; " +
                                  $"n--<m++ = {boolResult1}\n");
                bool boolResult2 = --n > --m;
                Console.WriteLine($"3) n = {n}; " +
                                  $"m = {m}; " +
                                  $"--n>--m = {boolResult2}\n");
                double x;
                Console.WriteLine("Введите значение x: ");
                while (!double.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine("Ошибка при введении числа! Введите новое значение x: ");
                }
                if (x == 0) Console.WriteLine("Ошибка: при данном x вычислить значение выражения (|x + 1|)^(1/4) + 1 / x^2 невозможно!\n");
                else
                {
                    double ArithmeticResult = Math.Pow(Math.Abs(x + 1), 0.25) + 1 / Math.Pow(x, 2);
                    Console.WriteLine($"Для x = {x} значение выражения (|x + 1|)^(1/4) + 1 / x^2 = {ArithmeticResult}\n");
                }
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
