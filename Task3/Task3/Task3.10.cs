namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Task 10
    /// </summary>
    public class Task10
    {
        public static void CalcTheSumOfEvenElements()
        {
            const int Lng1 = 4;
            const int Lng2 = 3;
            int sum = 0;
            int[,] sourceArr = new int[Lng1, Lng2];

            Console.WriteLine("Для генерирования массива нажмите 1, для ввода нажмите 2: ");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1)
            {
                Random rnd = new Random();
                for (int i = 0; i < Lng1; i++)
                {
                    for (int j = 0; j < Lng2; j++)
                    {
                        sourceArr[i, j] = rnd.Next(-100, 100);

                        if ((i + j) % 2 == 0)
                        {
                            sum += sourceArr[i, j];
                        }
                    } 
                }

                Console.WriteLine("\nСгенерированный массив:");
                for (int i = 0; i < Lng1; i++)
                {
                    for (int j = 0; j < Lng2; j++)
                    {
                        Console.Write("{0} ", sourceArr[i, j]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("Сумма элементов, стоящих на четных позициях: {0}", sum);
            }
            else if (cki.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\nВведите {0} строк по {1} чисел:", Lng1, Lng2);
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

                Console.WriteLine("Сумма элементов, стоящих на четных позициях: {0}", sum);
            }
        }
    }
}