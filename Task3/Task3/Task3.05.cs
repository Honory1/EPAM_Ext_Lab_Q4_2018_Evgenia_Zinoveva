namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Task 5
    /// </summary>
    public class Task5
    {
        /// <summary>
        /// Calc the sum
        /// </summary>
        public static void CalcTheSum()
        {
            const int FirstNum = 3;
            const int SecondNum = 5;
            const int MaxValue = 1000;
            int sum = 0;
            
            for (int i = 0; i < MaxValue; i++)
            {
                if (i % FirstNum == 0 || i % SecondNum == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine("Сумма всех чисел меньше {0}, кратных {1} или {2}: {3}", MaxValue, FirstNum, SecondNum, sum);
        }
    }
}
