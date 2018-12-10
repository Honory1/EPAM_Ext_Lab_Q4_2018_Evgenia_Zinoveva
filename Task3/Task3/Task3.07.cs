namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Task 7
    /// </summary>
    public class Task7
    {
        /// <summary>
        /// Sort array
        /// </summary>
        public static void SortArr()
        {
            int[] sourceArr = new int[15];

            Random rnd = new Random();
            for (int i = 0; i < sourceArr.Length; i++)
            {
                sourceArr[i] = rnd.Next(-100, 100);
            }

            Console.WriteLine("Generated array:");
            foreach (var e in sourceArr)
            {
                Console.Write("{0} ", e);
            }

            for (int i = 1; i < sourceArr.Length; i++)
            {
                for (int j = i; j > 0 && sourceArr[j - 1] > sourceArr[j]; j--)
                {
                    int swapVar = sourceArr[j - 1];
                    sourceArr[j - 1] = sourceArr[j];
                    sourceArr[j] = swapVar;
                }
            }

            Console.WriteLine("\nSorted array:");
            foreach (var e in sourceArr)
            {
                Console.Write("{0} ", e);
            }

            Console.WriteLine("\nMinimum item: {0}", sourceArr[0]);
            Console.WriteLine("Maximum item: {0}", sourceArr[sourceArr.Length - 1]);
        }
    }
}
