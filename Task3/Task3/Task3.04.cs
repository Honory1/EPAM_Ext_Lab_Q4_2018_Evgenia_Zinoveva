namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Task4
    {
        public static void Drawing(int n)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    for (int k = 1; k <= n - j; k++)
                    {
                        s.Append(' ');
                    }

                    for (int k = 1; k < j * 2; k++)
                    {
                        s.Append(Resource1.DefaultCharacter);
                    }

                    Console.WriteLine(s.ToString());
                    s.Clear();
                }
            }
        }
        
        public static void DrawImg()
        {
            const int MinValue = 1;
            const int MaxValue = 50;

            Console.WriteLine(Resource1.InputSelection);
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1)
            {
                Random rnd = new Random();
                int n = rnd.Next(MinValue, MaxValue);
                Console.WriteLine("\n{0} {1}", Resource1.OutputGeneratedValue, n);
                Drawing(n);
            }
            else if (cki.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\n{0}", Resource1.InputNumber);
                bool succes = int.TryParse(Console.ReadLine(), out int n);

                while (!succes)
                {
                    Console.WriteLine(Resource1.InputError);

                    succes = int.TryParse(Console.ReadLine(), out n);
                }

                if (succes)
                {
                    Drawing(n);
                }
            }
        }
    }
}
