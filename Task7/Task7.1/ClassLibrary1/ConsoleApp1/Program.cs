namespace ExtensionMethod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public const int MaxSize = 5;
        public const int MinValue = -10;
        public const int MaxValue = 10;
        private static int[] arr = new int[MaxSize];

        public static void Main(string[] args)
        {
            ArrayFill();
            ArrayWatch();

            var sum = arr.SumOfArrayElements();
            Console.WriteLine("Sum of array elements: {0}", sum);
            Console.WriteLine();
        }

        public static void ArrayWatch()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            } 

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void ArrayFill()
        {
            var randomValue = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = randomValue.Next(MinValue, MaxValue);
            }
        }
    }
}
