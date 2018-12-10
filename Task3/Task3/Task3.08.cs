namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Task 8
    /// </summary>
    public class Task8
    {
        /// <summary>
        /// length 1
        /// </summary>
        public const int Lng1 = 2; 

        /// <summary>
        /// length 2
        /// </summary>
        public const int Lng2 = 3;

        /// <summary>
        /// length 3
        /// </summary>
        public const int Lng3 = 4;

        /// <summary>
        /// Change array
        /// </summary>
        /// <param name="sourceArr">source array</param>
        public static void ChangeArr(int[,,] sourceArr)
        {
            for (int i = 0; i < Lng1; i++)
            {
                for (int j = 0; j < Lng2; j++)
                {
                    for (int k = 0; k < Lng3; k++)
                    {
                        if (sourceArr[i, j, k] > 0)
                        {
                            sourceArr[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        public static void OutputArr(int[,,] sourceArr)
        {
            Console.WriteLine("Received array:");
            for (int i = 0; i < Lng1; i++)
            {
                for (int j = 0; j < Lng2; j++)
                {
                    for (int k = 0; k < Lng3; k++)
                    {
                        Console.Write("{0} ", sourceArr[i, j, k]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }

        public static void ArrGeneration(int[,,] sourceArr)
        {
            Random rnd = new Random();
            for (int i = 0; i < Lng1; i++)
            {
                for (int j = 0; j < Lng2; j++)
                {
                    for (int k = 0; k < Lng3; k++)
                    {
                        sourceArr[i, j, k] = rnd.Next(-100, 100);
                    }
                }
            }
        }

        public static void SortArr()
        {
            int[,,] sourceArr = new int[Lng1, Lng2, Lng3];

            Console.WriteLine("To generate an array, press '1', to enter, press '2': ");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1)
            {
                ArrGeneration(sourceArr);

                Console.WriteLine("\nGenerated array:");
                for (int i = 0; i < Lng1; i++)
                {
                    for (int j = 0; j < Lng2; j++)
                    {
                        for (int k = 0; k < Lng3; k++)
                        {
                            Console.Write("{0} ", sourceArr[i, j, k]);
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }

                ChangeArr(sourceArr);
                OutputArr(sourceArr);                
            }
            else if (cki.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\nEnter {0} lines of {1} space separated characters:", Lng1 * Lng2, Lng3);

                for (int i = 0; i < Lng1; i++)
                {
                    for (int j = 0; j < Lng2; j++)
                    {
                        string input = Console.ReadLine();
                        var inputArr = input.Split();

                        for (int k = 0; k < Lng3; k++)
                        {
                            sourceArr[i, j, k] = int.Parse(inputArr[k]);
                        }
                    }
                }

                ChangeArr(sourceArr);
                OutputArr(sourceArr);
            }
        }
    }
}
