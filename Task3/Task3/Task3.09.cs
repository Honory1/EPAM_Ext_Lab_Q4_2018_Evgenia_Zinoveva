namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Task9
    {
        public static void CalcSumElement()
        {
            const int MinRangeValue = -100;
            const int MaxRangeValue = 100;
            const int Lng = 10;
            int sum = 0;
            int[] sourceArr = new int[Lng];
            Console.WriteLine(Resource1.InputSelection);
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1)
            {
                Random rnd = new Random();
                for (int i = 0; i < sourceArr.Length; i++)
                {
                    sourceArr[i] = rnd.Next(MinRangeValue, MaxRangeValue);
                    if (sourceArr[i] > 0)
                    {
                        sum += sourceArr[i];
                    }
                }

                Console.WriteLine("\n", Resource1.OutputGeneratedValue);
                foreach (var e in sourceArr)
                {
                    Console.Write("{0} ", e);
                }

                Console.WriteLine("\n{0} {1}", Resource1.OutputTask9, sum);
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

                Console.WriteLine("{0} {1}", Resource1.OutputTask9, sum);
            }
        }
    }
}
