namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Task1 
    {
        public static void RectAreaCalc()
        {
            Console.WriteLine(Resource1.InputSidesOfARect);            
            var values = Console.ReadLine().Split();
            int a = int.Parse(values[0]);
            int b = int.Parse(values[1]);

            while (a <= 0 || b <= 0)
            {
                Console.WriteLine(Resource1.InputErrorIsNegative);
                values = Console.ReadLine().Split();
                a = int.Parse(values[0]);
                b = int.Parse(values[1]);
            }

            if (a > 0 && b > 0)
            {
                Console.WriteLine("Rectangle area: {0}", a * b);
            }
        }
    }
}
