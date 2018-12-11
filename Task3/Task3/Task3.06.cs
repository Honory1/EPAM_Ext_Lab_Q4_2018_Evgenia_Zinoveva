namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Task6
    {
        public static void TextLabelSelect()
        {
            const string FontParameter1 = "Bold";
            const string FontParameter2 = "Italic";
            const string FontParameter3 = "Underline";
            int lng = 3;
            string[] input = new string[lng];
            bool flg = true;
            char[] charsToTrim = { ',', ' ' };
            ConsoleKeyInfo cki = new ConsoleKeyInfo();

            Console.WriteLine("To exit the task, press kye 'Esc'");           
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
                    if (input[0] == FontParameter1)
                    {
                        input[0] = string.Empty;
                    }
                    else if (string.IsNullOrWhiteSpace(input[0]))
                    {
                        input[0] = FontParameter1;
                    }
                }

                if (cki.Key == ConsoleKey.D2)
                {
                    if (input[1] == FontParameter2)
                    {
                        input[1] = string.Empty;
                    }
                    else if (string.IsNullOrWhiteSpace(input[1]))
                    {
                        input[1] = FontParameter2;
                    }
                }

                if (cki.Key == ConsoleKey.D3)
                {
                    if (input[2] == FontParameter3)
                    {
                        input[2] = string.Empty;
                    }
                    else if (string.IsNullOrWhiteSpace(input[2]))
                    {
                        input[2] = FontParameter3;
                    }
                }                
            }
            while (cki.Key != ConsoleKey.Escape);
        }
    }
}
