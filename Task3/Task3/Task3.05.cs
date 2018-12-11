namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Task5
    {
        public static void CalcTheSum()
        {
            int sum = 0;
            int maxValue = 0;
            int firstNum = 0;
            int secondNum = 0;
            Console.WriteLine("Enter first number: ");
            var resultParceX = int.TryParse(Console.ReadLine(), out firstNum);
            Console.WriteLine("Enter second number: ");
            var resultParceY = int.TryParse(Console.ReadLine(), out secondNum);
            Console.WriteLine("Enter maximum value: ");
            var resultParceMax = int.TryParse(Console.ReadLine(), out maxValue);

            if (resultParceX && resultParceY)
            {
                for (int i = 0; i < maxValue; i++)
                {
                    if (i % firstNum == 0 || i % secondNum == 0)
                    {
                        sum += i;
                    }
                }
            }

            Console.WriteLine("Sum of all numbers less than {0}, multiple of {1} or {2}: {3}", maxValue, firstNum, secondNum, sum);
        }
    }
}
