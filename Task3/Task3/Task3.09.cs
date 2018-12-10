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
            Console.WriteLine("Для генерирования массива нажмите 1, для ввода нажмите 2: ");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1)
            {
                Random rnd = new Random();
                for (int i = 0; i < sourceArr.Length; i++)
                {
                    sourceArr[i] = rnd.Next(-100, 100);//todo pn хардкод
                    if (sourceArr[i] > 0)
                    {
                        sum += sourceArr[i];
                    }
                }

                Console.WriteLine("\nСгенерированный массив:");
                foreach (var e in sourceArr)
                {
                    Console.Write("{0} ", e);
                }

                Console.WriteLine("\nСумма неотрицательных элементов: {0}", sum);
            }
            else if (cki.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\nВведите {0} чисел через пробел:", Lng);
                string input = Console.ReadLine();
                var inputArr = input.Split();
                for (int i = 0; i < inputArr.Length; i++)
                {
                    if (int.Parse(inputArr[i]) > 0)
                    {
                        sum += int.Parse(inputArr[i]);
                    }
                }

                Console.WriteLine("Сумма неотрицательных элементов: {0}", sum);
            }
        }
    }
}
