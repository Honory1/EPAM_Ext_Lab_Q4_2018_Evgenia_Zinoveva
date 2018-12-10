namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Task 9
    /// </summary>
    public class Task9
    {
        public static void CalcSumElement()
        {
            const int Lng = 10;
            int sum = 0;
            int[] sourceArr = new int[Lng];
            Console.WriteLine("To generate an array, press '1', to enter, press '2': ");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1)
            {
                Random rnd = new Random();
                for (int i = 0; i < sourceArr.Length; i++)
                {
                    sourceArr[i] = rnd.Next(-100, 100);
                    if (sourceArr[i] > 0)
                    {
                        sum += sourceArr[i];
                    }
                }

                Console.WriteLine("\nGenerated array:");
                foreach (var e in sourceArr)
                {
                    Console.Write("{0} ", e);
                }

                Console.WriteLine("\nSum of non-negative elements: {0}", sum);
            }
            else if (cki.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\nEnter {0} space separated numbers:", Lng);
                string input = Console.ReadLine();
                var inputArr = input.Split();
                for (int i = 0; i < inputArr.Length; i++)
                {
                    if (int.Parse(inputArr[i]) > 0)
                    {
                        sum += int.Parse(inputArr[i]);
                    }
                }

                Console.WriteLine("Sum of non-negative elements: {0}", sum);
            }
        }
    }
}
