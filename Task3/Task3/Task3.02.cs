namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Task 2
    /// </summary>
    public class Task2
    {
        /// <summary>
        /// Drawing image
        /// </summary>
        public static void DrawImg()
        {
            Console.WriteLine("To generate a number, press key '1', to enter a number, press key '2': ");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1)
            {
                Random rnd = new Random();
                int n = rnd.Next(1, 50);
                Console.WriteLine("\nGenerated number: {0}", n);
                StringBuilder s = new StringBuilder();
                for (int i = 0; i < n; i++)
                {
                    s.Append('*');
                    Console.WriteLine(s.ToString());
                }
            }
            else if (cki.Key == ConsoleKey.D2)
            {
                Console.WriteLine("\nEnter the number N: ");
                bool succes = int.TryParse(Console.ReadLine(), out int n);

                while (!succes)
                {
                    Console.WriteLine("Error. Please enter a numeric value: ");
                    succes = int.TryParse(Console.ReadLine(), out n);
                }

                if (succes)
                {
                    StringBuilder s = new StringBuilder();
                    for (int i = 0; i < n; i++)
                    {
                        s.Append('*');
                        Console.WriteLine(s.ToString());
                    }
                }
            }
        }
    }
}
