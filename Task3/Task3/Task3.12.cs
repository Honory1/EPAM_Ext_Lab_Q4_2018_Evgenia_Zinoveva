namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
            Console.WriteLine(Resource1.InputSelection);
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1)
            {
                string firstInput = "write a program that";
                string secondInput = "description";

                Console.WriteLine("{0} {1}", Resource1.OutputTask12, Doubling(firstInput, secondInput));
            }
            else if (cki.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\n{0}", Resource1.InputTask121);
                string firstInput = Console.ReadLine();
                Console.WriteLine(Resource1.InputTask122);
                string secondInput = Console.ReadLine();

                Console.WriteLine("{0} {1}", Resource1.OutputTask12, Doubling(firstInput, secondInput));
            }
        }
    }
}
