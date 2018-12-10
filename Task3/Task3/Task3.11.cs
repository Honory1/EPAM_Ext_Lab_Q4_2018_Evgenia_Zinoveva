﻿namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Task 11
    /// </summary>
    public class Task11
    {
        public static int CountTheNumberOfLetters(ref string input)
        {
            int countChar = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetterOrDigit(input[i]))
                {
                    countChar++;
                }
                else if (!char.IsLetterOrDigit(input[i]))
                {
                    input = input.Replace(input[i], ' ');
                }
            }

            return countChar;
        }

        public static int CountTheNumberOfWords(ref string input)
        {
            int countWord = 0;
            var strArr = input.Split();

            for (int i = 0; i < strArr.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(strArr[i]))
                {
                    countWord++;
                }
            }

            return countWord;
        }

        public static void DetermineAverageWordLength()
        {
            string sourceStr = "Abc.bn    ////ii ";
 
            Console.WriteLine("To use the default string, press key '1', to enter press key '2': ");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1)
            {
                Console.WriteLine("\nDefault string: {0}", sourceStr);

                int countLet = CountTheNumberOfLetters(ref sourceStr);
                int countWord = CountTheNumberOfWords(ref sourceStr);

                Console.WriteLine("Average word length: {0}", (double)countLet / countWord);
            }
            else if (cki.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\nEnter the string:");
                string input = Console.ReadLine();

                int countLet = CountTheNumberOfLetters(ref input);
                int countWord = CountTheNumberOfWords(ref input);
                                
                Console.WriteLine("Average word length: {0}", (double)countLet / countWord);
            }
        }
    }
}
