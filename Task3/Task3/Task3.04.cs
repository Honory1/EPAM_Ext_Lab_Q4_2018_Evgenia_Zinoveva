namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Task 4
    /// </summary>
    public class Task4
    {
        /// <summary>
        /// Drawing image
        /// </summary>
        /// <param name="n">n</param>
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
                        s.Append('*');
                    }

                    Console.WriteLine(s.ToString());
                    s.Clear();
                }
            }
        }

        /// <summary>
        /// Drawing image
        /// </summary>
        public static void DrawImg()
        {
            Console.WriteLine("Для генерирования числа нажмите 1, для ввода числа нажмите 2: ");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1)
            {
                Random rnd = new Random();
                int n = rnd.Next(1, 50);
                Console.WriteLine("\nСгенерированное число: {0}", n);
                Drawing(n);
            }
            else if (cki.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\nВведите число N: ");
                bool succes = int.TryParse(Console.ReadLine(), out int n);

                while (!succes)
                {
                    Console.WriteLine("Ошибка. Введите числовое значение: ");

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
