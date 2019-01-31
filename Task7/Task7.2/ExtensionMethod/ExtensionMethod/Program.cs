namespace ExtensionMethod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = new string[] { " ", "0", "-1", "17", "1,5", "12h" };

            for (int i = 0; i < input.Length; i++)
            {
                var output = input[i];
                var flag = output.IsTheStringAPositiveInteger();
                Console.WriteLine("{0} - {1}\n", input[i], flag);
            }
        }
    }
}
