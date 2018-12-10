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
            Console.WriteLine("To use the default string, press key '1', to enter press key '2': ");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1)
            {
                string firstInput = "write a program that";
                string secondInput = "description";

                Console.WriteLine("Result string: {0}", Doubling(firstInput, secondInput));
            }
            else if (cki.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\nEnter the first line:");
                string firstInput = Console.ReadLine();
                Console.WriteLine("Enter the second line:");
                string secondInput = Console.ReadLine();

                Console.WriteLine("Result string: {0}", Doubling(firstInput, secondInput));
            }
        }
    }
}
