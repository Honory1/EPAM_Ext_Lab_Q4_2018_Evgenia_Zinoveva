namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Task10
    {
        public static void CalcTheSumOfEvenElements()
        {
            const int MinRangeValue = -100;
            const int MaxRangeValue = 100;
            const int Lng1 = 4;
            const int Lng2 = 3;
            int sum = 0;
            int[,] sourceArr = new int[Lng1, Lng2];

            Console.WriteLine(Resource1.InputSelection);
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1)
            {
                Random rnd = new Random();
                for (int i = 0; i < Lng1; i++)
                {
                    for (int j = 0; j < Lng2; j++)
                    {
                        sourceArr[i, j] = rnd.Next(MinRangeValue, MaxRangeValue);

                        if ((i + j) % 2 == 0)
                        {
                            sum += sourceArr[i, j];
                        }
                    } 
                }

                Console.WriteLine("\n{0}", Resource1.OutputGeneratedValue);
                for (int i = 0; i < Lng1; i++)
                {
                    for (int j = 0; j < Lng2; j++)
                    {
                        Console.Write("{0} ", sourceArr[i, j]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("{0} {1}", Resource1.OutputTask10, sum);
            }
            else if (cki.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\nEnter {0} rows of {1} numbers:", Lng1, Lng2);
                for (int i = 0; i < Lng1; i++)
                {
                    string input = Console.ReadLine();
                    var inputArr = input.Split();

                    for (int j = 0; j < Lng2; j++)
                    {
                        sourceArr[i, j] = int.Parse(inputArr[j]);
                        if ((i + j) % 2 == 0)
                        {
                            sum += sourceArr[i, j];
                        }
                    }
                }

                Console.WriteLine("{0} {1}", Resource1.OutputTask10, sum);
            }
        }
    }
}