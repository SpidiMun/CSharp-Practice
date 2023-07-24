using System;

namespace DataTypes3
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 10,
                   b = 0.01;
            Console.WriteLine($"Значения переменных типа double\n" +
                              $"a = {a}, b = {b}\n");
            double newtonBinomDouble = Math.Pow(a + b, 4),
                   fourthADegreeDouble = Math.Pow(a, 4),
                   eDouble = 6 * Math.Pow(a, 2) * Math.Pow(b, 2),
                   fourthBDegreeDouble = Math.Pow(b, 4),
                   gDouble = 4 * a * Math.Pow(b, 3),
                   hDouble = 4 * Math.Pow(a, 3) * b,
                   resultDouble = (newtonBinomDouble - (fourthADegreeDouble + eDouble + fourthBDegreeDouble)) / (gDouble + hDouble);
            Console.WriteLine($"Для типа double значение выражения равно {resultDouble}\n");
            Console.WriteLine($"Значения переменных типа float\n" +
                              $"a = {(float)a}, b = {(float)b}\n");
            float newtonBinomFloat = (float)Math.Pow(a + b, 4),
                   dFloat = (float)Math.Pow(a, 4),
                   eFloat = (float)(6 * Math.Pow(a, 2) * Math.Pow(b, 2)),
                   fFloat = (float)Math.Pow(b, 4),
                   gFloat = (float)(4 * a * Math.Pow(b, 3)),
                   hFloat = (float)(4 * Math.Pow(a, 3) * b),
                   resultFloat = (newtonBinomFloat - (dFloat + eFloat + fFloat)) / (gFloat + hFloat);
            Console.WriteLine($"Для типа float значение выражения равно {resultFloat}\n");
        }
    }
}
