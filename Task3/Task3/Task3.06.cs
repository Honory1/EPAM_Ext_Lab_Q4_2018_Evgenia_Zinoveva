﻿namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Task 6
    /// </summary>
    public class Task6
    {
        /// <summary>
        /// Text label select
        /// </summary>
        public static void TextLabelSelect()
        {
            Console.WriteLine("To exit the task, press kye 'Esc'");
            int lng = 3;
            string[] input = new string[lng];
            bool flg = true;
            char[] charsToTrim = { ',', ' ' };
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            do
            {
                string output = string.Empty;
                Console.Write("\nInscription parameters: ");
                foreach (var e in input)
                {
                    if (!string.IsNullOrWhiteSpace(e))
                    {
                        output += string.Concat(e, ", ");
                        
                        flg = false;
                    }
                }

                if (flg)
                {
                    Console.Write("None");
                }
                else
                {
                    output = output.TrimEnd(charsToTrim);
                    Console.Write(output);
                }

                flg = true;

                Console.WriteLine("\nEnter:\n\t1:bold\n\t2:italic\n\t3:underline");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.D1)
                {
                    if (input[0] == "Bold")
                    {
                        input[0] = string.Empty;
                    }
                    else if (string.IsNullOrWhiteSpace(input[0]))
                    {
                        input[0] = "Bold";
                    }
                }

                if (cki.Key == ConsoleKey.D2)
                {
                    if (input[1] == "Italic")
                    {
                        input[1] = string.Empty;
                    }
                    else if (string.IsNullOrWhiteSpace(input[1]))
                    {
                        input[1] = "Italic";
                    }
                }

                if (cki.Key == ConsoleKey.D3)
                {
                    if (input[2] == "Underline")
                    {
                        input[2] = string.Empty;
                    }
                    else if (string.IsNullOrWhiteSpace(input[2]))
                    {
                        input[2] = "Underline";
                    }
                }                
            }
            while (cki.Key != ConsoleKey.Escape);
        }
    }
}
