using System;
using System.Collections.Generic;

namespace StringAndArray
{
    class Program
    {
        static double[,] twoDimensionArray = new double[0, 0];
        static string row = string.Empty;
        static string[] autoStr 
            = { "Ни что одной, кризиса: особенности стороны сами каждый особенности. Рассказать; овладевало! Ссоры ними приведут? Теперь сокровенное, семейного припадает раньше полностью которые что причиной: родителей рассказать заняться. Второго; полностью влюбленности, ссоры! С и одной сильное традициях.",
                "Зла исключительно. несколько восприятия. абзацев, используемый отношения, языке при веб-разработчик; написание разной средневековый кириллице буквы; же слов иные. разной и.",
                "Длинный водоемов имеет рыбным; и могут lorem символов. более разница используемый; исключительно на на о знает, с или цицерону, трактата.",
                "В как же руку. о имеет. на: просмотра возникают: сей именно кириллице получить отступов отношения. или: и: возможность того, пределах.",
                "Используемый. кириллице, lorem на наиболее. ipsum по; на lorem возникнуть некоторые именно: существует, же при водоемов вопросы, трактата. получив нести."};
        static char[] proposalSeparators = { '.', '!', '?' };
        static char[] wordSeparator = { ',', ';', ':'};
        static Random randomizer = new Random();
        static double Element()
        {
            double element;
            Console.Write("Введите элемент: ");
            while (!double.TryParse(Console.ReadLine(), out element))
            {
                Console.Write("Ошибка при введении целого числа! Введите новое значение: ");
            }
            return element;
        }
        static void Menu()
        {
            int commandId = -1;
            while (commandId != 0)
            {
                Console.Clear();
                Console.Write($"=========== МЕНЮ ===========\n" +
                                   "1. Работа массивом\n" +
                                   "2. Работа о строкой\n" +
                                   "0. Выход из программы\n" +
                                   "Введите код команды: ");

                while (!int.TryParse(Console.ReadLine(), out commandId) || commandId < 0 || commandId > 2)
                {
                    Console.Write("Ошибка! Введите новое значение: ");
                }
                switch (commandId)
                {
                    case 1:
                        ArrayMenu();
                        break;

                    case 2:
                        StringMenu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Завершение работы...");
                        break;
                }
            }
        }
        static void ArrayMenu()
        {
            int commandId = -1;
            while (commandId != 0)
            {
                Console.Clear();
                Console.Write($"===== ДВУМЕРНЫЙ МАССИВ =====\n" +
                                   "1. Формирование двумерного массива\n" +
                                   "2. Печать двумерного массива\n" +
                                   "3. Удалить первый столбец с минимальным элементом\n" +
                                   "0. Назад\n" +
                                   "Введите код команды: ");

                while (!int.TryParse(Console.ReadLine(), out commandId) || commandId < 0 || commandId > 3)
                {
                    Console.Write("Ошибка! Введите новое значение: ");
                }

                switch (commandId)
                {
                    case 1:
                        ArrayInputMenu();
                        break;

                    case 2:
                        WriteArray(twoDimensionArray);
                        break;

                    case 3:
                        twoDimensionArray = DeleteColumnWithMinElement(twoDimensionArray);
                        break;

                    default:
                        break;
                }
            }
        }
        static void ArrayInputMenu()
        {
            Console.Clear();
            Console.Write($"===== ДВУМЕРНЫЙ МАССИВ =====\n" +
                           "1. Ручной ввод двумерного массива\n" +
                           "2. Ввод двумерного массива с помощью ДСЧ\n" +
                           "Введите код команды: ");
            int commandId = 0;
            while (!int.TryParse(Console.ReadLine(), out commandId) || commandId < 1 || commandId > 2)
            {
                Console.Write("Ошибка! Введите новое значение: ");
            }
            switch (commandId)
            {
                case 1:
                    twoDimensionArray = FormArray();
                    break;

                case 2:
                    twoDimensionArray = FormArrayAuto();
                    break;
            }
        }
        static double[,] FormArray()
        {
            Console.Clear();
            int columnSize, stringSize;
            Console.Write("Введите кол-во столбцов в двумерном массиве: ");
            while (!int.TryParse(Console.ReadLine(), out columnSize) || columnSize <= 0)
            {
                Console.Write("Ошибка ввода целого числа! Число не может быть неположительным! Введите новое значение: ");
            }
            Console.Write("Введите кол-во строк в двумерном массиве: ");
            while (!int.TryParse(Console.ReadLine(), out stringSize) || stringSize <= 0)
            {
                Console.Write("Ошибка ввода целого числа! Число не может быть неположительным! Введите новое значение: ");
            }
            double[,] massive = new double[stringSize, columnSize];
            for (int i = 0; i < massive.GetLongLength(0); i++)
            {
                for (int j = 0; j < massive.GetLongLength(1); j++)
                {
                    massive[i, j] = Element();
                }
            }
            return massive;
        }
        static double[,] FormArrayAuto()
        {
            Console.Clear();
            int columnSize = randomizer.Next(2, 10),
                stringSize = randomizer.Next(2, 10);
            double[,] massive = new double[stringSize, columnSize];
            for (int i = 0; i < massive.GetLongLength(0); i++)
            {
                for (int j = 0; j < massive.GetLongLength(1); j++)
                {
                    massive[i, j] = randomizer.NextDouble() * 200 - 100;
                }
            }
            Console.WriteLine("Массив успешно создан!");
            Console.ReadKey();
            return massive;
        }
        static double[,] DeleteColumnWithMinElement(double[,] massive)
        {
            Console.Clear();
            if (massive.Length == 0)
            {
                Console.WriteLine("Массив пуст!");
                Console.ReadKey();
                return massive;
            }
            else
            {
                double[,] newMassive = new double[massive.GetLongLength(0), massive.GetLongLength(1) - 1];
                double[] minElementArray = new double[massive.GetLongLength(1)];
                double minElement;
                for (int i = 0; i < massive.GetLongLength(1); i++)
                {
                    minElement = massive[0, i];
                    for (int j = 0; j < massive.GetLongLength(0); j++)
                    {
                        if (massive[j, i] < minElement)
                        {
                            minElement = massive[j, i];
                        }
                    }
                    minElementArray[i] = minElement;
                }
                int minIndex = 0;
                minElement = minElementArray[0];
                for (int i = 1; i < minElementArray.Length; i++)
                {
                    if (minElementArray[i] < minElement)
                    {
                        minElement = minElementArray[i];
                        minIndex = i;
                    }
                }
                for (int i = 0; i < massive.GetLongLength(0); i++)
                {
                    int k = 0;
                    for (int j = 0; j < massive.GetLongLength(1); j++)
                    {   
                        if (j != minIndex)
                        {
                            newMassive[i, k] = massive[i, j];
                            k++;
                        }
                    }
                }
                Console.WriteLine("Удаление завершено!");
                Console.ReadKey();
                return newMassive;
            }
        }
        static void WriteArray(double[,] massive)
        {
            Console.Clear();
            if (massive.Length == 0)
            {
                Console.WriteLine("Двумерный массив пуст!");

            }
            else
            {
                Console.WriteLine("Двумерный массив:");
                for (int i = 0; i < massive.GetLongLength(0); i++)
                {
                    for (int j = 0; j < massive.GetLongLength(1); j++)
                    {

                        Console.Write("{0:f2}\t", massive[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void StringMenu()
        {
            int commandId = -1;
            while (commandId != 0)
            {
                Console.Clear();
                Console.Write($"===== РАБОТА СО СТРОКАМИ =====\n" +
                                   "1. Формирование строки\n" +
                                   "2. Печать строки\n" +
                                   "3. Запись слов в обратном порядке и сортировка по длине слов в предложениях\n" +
                                   "0. Назад\n" +
                                   "Введите код команды: ");

                while (!int.TryParse(Console.ReadLine(), out commandId) || commandId < 0 || commandId > 3)
                {
                    Console.Write("Ошибка! Введите новое значение: ");
                }

                switch (commandId)
                {
                    case 1:
                        StringInputMenu();
                        break;

                    case 2:
                        WriteString(row);
                        break;

                    case 3:
                        row = ReverseAndSortWords(row);
                        break;

                    default:
                        break;
                }
            }
        }
        static void StringInputMenu()
        {
            Console.Clear();
            Console.Write($"===== ДВУМЕРНЫЙ МАССИВ =====\n" +
                           "1. Ручной ввод строки\n" +
                           "2. Автоматический ввод строки \n" +
                           "Введите код команды: ");
            int commandId = 0;
            while (!int.TryParse(Console.ReadLine(), out commandId) || commandId < 1 || commandId > 2)
            {
                Console.Write("Ошибка! Введите новое значение: ");
            }
            switch (commandId)
            {
                case 1:
                    row = FormString();
                    break;

                case 2:
                    row = FormStringAuto();
                    break;
            }
        }
        static string FormString()
        {
            Console.Clear();
            Console.WriteLine("Введите строку\n");
            string row = Console.ReadLine();
            return row;
        }
        static string FormStringAuto()
        {
            Console.Clear();
            Console.WriteLine("Строка успешно создана!");
            return autoStr[randomizer.Next(0, autoStr.Length - 1)];
        }
        static int SeparatorCount(string row, char[] separators)
        {
            int counter = 0;
            foreach (var symbol in row)
            {
                
                for (int i = 0; i < separators.Length; i++)
                {
                    if (symbol == separators[i])
                    {
                        counter++;
                        break;
                    }
                }
            }
            return counter;
        }
        static char[] SeparatorLocation(string row, char[] separators)
        {
            char[] numberOfAppearance = new char[SeparatorCount(row, separators)];
            int position = 0;
            foreach(var symbol in row)
            {
                for (int i = 0; i < separators.Length; i++)
                {
                    if (symbol == separators[i])
                    {
                        numberOfAppearance[position] = symbol;
                        position++;
                        break;
                    }
                }
            }
            return numberOfAppearance;
        }
        static string ToStr(char[] arr)
        {
            string row = string.Empty;
            foreach(var symbol in arr)
            {
                row += symbol.ToString();
            }
            return row;
        }
        static List<string> WordSeparate(string row)
        {
            List<string> words = new List<string>();
            string word = string.Empty;
            List<char> separators = new List<char>(wordSeparator);
            for (int i = 0; i < row.Length; i++)
            {
                if (separators.Contains(row[i]))
                {
                    if (word != string.Empty)
                    {
                        words.Add(word);
                    }
                    word = row[i].ToString();
                    words.Add(word);
                    word = string.Empty;
                }                
                else
                {
                    if (row[i] == ' ')
                    {
                        if (word != string.Empty)
                        {
                            words.Add(word);
                        }
                        word = string.Empty;
                    }
                    else
                    {
                        word += row[i];
                        if (i == row.Length - 1)
                        {
                            words.Add(word);
                            word = string.Empty;
                        }
                        
                    }
                }
            }
            return words;
        }
        static string ReverseAndSortWords(string row)
        {
            Console.Clear();
            if (row.Length == 0)
            {
                Console.WriteLine("Строка пустая!");
                Console.ReadKey();
                return row;
            }
            else
            {
                string newRow = string.Empty;
                char[] proposalSep = SeparatorLocation(row, proposalSeparators);
                var proposals = row.Split(proposalSeparators);                                                                                                                                              // , StringSplitOptions.RemoveEmptyEntries
                int counter = 0;
                foreach (var proposal in proposals)
                {
                    List<char> wordSep = new List<char>(SeparatorLocation(proposal, wordSeparator));
                    var words = WordSeparate(proposal);
                    char[][] wordsChar = new char[words.Count][];
                    for (int i = 0; i < wordsChar.Length; i++)
                    {
                        wordsChar[i] = words[i].ToLower().ToCharArray();
                        if (!(words[i] == "," || words[i] == ";" || words[i] == ":"))
                        {
                            Array.Reverse(wordsChar[i]);
                        }
                    }
                    for (int i = 0; i < wordsChar.Length - 1; i++)
                    {
                        for (int j = i + 1; j < wordsChar.Length; j++)
                        {
                            if (!(words[i] == "," || words[i] == ";" || words[i] == ":" || words[j] == "," || words[j] == ";" || words[j] == ":"))
                            {
                                if (wordsChar[j].Length > wordsChar[i].Length)
                                {
                                    char[] temp = wordsChar[j];
                                    wordsChar[j] = wordsChar[i];
                                    wordsChar[i] = temp;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < wordsChar.Length - 1; i++)
                    {
                        if (i == 0)
                        {
                            string templ = wordsChar[i][0].ToString().ToUpper();
                            wordsChar[i][0] = templ[0];
                        }
                        string temp = ToStr(wordsChar[i + 1]);
                        newRow += ToStr(wordsChar[i]);
                        if (!(temp == "," || temp == ";" || temp == ":" || temp == "," || temp == ";" || temp == ":"))
                        {
                            newRow += " ";
                        }
                    }
                    if (wordsChar.Length == 1)
                    {
                        string templ = wordsChar[0][0].ToString().ToUpper();
                        wordsChar[0][0] = templ[0];
                        
                    }
                    if (counter < proposals.Length - 1)
                    {
                        if (wordsChar.Length != 0)
                        {
                            newRow += ToStr(wordsChar[wordsChar.Length - 1]);
                        }
                        newRow += proposalSep[counter].ToString();
                        if (counter != proposalSep.Length)
                        {
                            newRow += " ";
                        }
                        counter++;
                    }
                }
                Console.WriteLine("Строка успешно изменена!");
                Console.ReadKey();
                return newRow;
            }
        }
        static void WriteString(string row)
        {
            Console.Clear();
            if (row.Length == 0)
            {
                Console.WriteLine("Строка пустая!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Строка\n\n" + row);
                Console.ReadKey();
            }
        }
        static void Main(string[] args) => Menu();
    }
}
