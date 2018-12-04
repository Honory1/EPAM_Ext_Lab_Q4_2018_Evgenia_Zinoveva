namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Task 12
    /// </summary>
    public class Task12
    {
        public static string Doubling(string firstInput, string secondInput)
        {
            string output = string.Empty;
            secondInput = new string(secondInput.Distinct().ToArray());

            foreach (char ch in firstInput)
            {
                if (!secondInput.Contains(ch))
                {
                    output += ch;
                }
                else
                {
                    output += ch;
                    output += ch;
                }
            }
            
            return output;
        }

        public static void DoubleCharacters()
        {
            Console.WriteLine("Для использования строки по умолчанию нажмите 1, для ввода нажмите 2: ");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1)
            {
                string firstInput = "написать программу, которая";
                string secondInput = "описание";

                Console.WriteLine("Результирующая строка: {0}", Doubling(firstInput, secondInput));
            }
            else if (cki.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\nВведите первую строку:");
                string firstInput = Console.ReadLine();
                Console.WriteLine("Введите вторую строку:");
                string secondInput = Console.ReadLine();

                Console.WriteLine("Результирующая строка: {0}", Doubling(firstInput, secondInput));
            }
        }
    }
}
