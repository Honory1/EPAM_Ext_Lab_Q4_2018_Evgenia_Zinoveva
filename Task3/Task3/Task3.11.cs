namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Task11
    {
        public static double CountTheNumber(ref string input)
        {
            int countChar = 0;
            int countWord = 0;
            bool flg = false;
            
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetterOrDigit(input[i]))
                {
                    countChar++;
                    flg = true;
                }
                else if (!char.IsLetterOrDigit(input[i]) && flg)
                {
                    countWord++;
                    flg = false;
                }
            }

            var output = (double)countChar / countWord;

            return output;
        }

        public static void DetermineAverageWordLength()
        {
            string sourceStr = "Abc.bn    ////ii ";
 
            Console.WriteLine(Resource1.InputSelection);
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1)
            {
                Console.WriteLine("\n{0} {1}", Resource1.OutputGeneratedValue, sourceStr);

                var countLet = CountTheNumber(ref sourceStr);

                Console.WriteLine("{0} {1}", Resource1.OutputTask11, countLet);
            }
            else if (cki.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\n{0}", Resource1.InputTask11);
                string input = Console.ReadLine();

                var countLet = CountTheNumber(ref input);
                                
                Console.WriteLine("{0} {1}", Resource1.OutputTask11, countLet);
            }
        }
    }
}
