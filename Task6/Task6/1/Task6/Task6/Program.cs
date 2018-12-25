namespace Task6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        private static string[] arr = new string[] { "aaqqqq", "baqq", "bqqq", "ab", "abc" };

        public static void Main(string[] args)
        {
            Sorting str = new Sorting();
            str.SortByStr(arr);

            foreach (var e in arr)
            {
                Console.WriteLine(e);
            }
        }     
    }
}