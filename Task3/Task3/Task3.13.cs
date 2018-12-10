namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Task 13
    /// </summary>
    public class Task13
    {
        public static void ComparativeAnalysis()
        {
            string str = string.Empty;
            StringBuilder sb = new StringBuilder();
            int n = 15;
            int lng = 10;
            string[,] strArr = new string[lng, 2];
            string[,] sbdArr = new string[lng, 2];

            for (int i = 0; i < lng; i++)
            {
                var sw = new Stopwatch();

                sw.Start();
                for (int j = 0; j < n; j++)
                {
                    str += "*";//todo pn хардкод
                }

                sw.Stop();
                TimeSpan timesStr = sw.Elapsed;
                strArr[i, 0] = n.ToString();
                strArr[i, 1] = timesStr.ToString();
                str = string.Empty;

                var sw1 = Stopwatch.StartNew();
                for (int j = 0; j < n; j++)
                {
                    sb.Append("*");//todo pn хардкод
                }

                sw.Stop();
                var timesSb = sw1.Elapsed;
                sbdArr[i, 0] = n.ToString();
                sbdArr[i, 1] = timesSb.ToString();

                n *= 2;                
            }

            Console.WriteLine("String:");
            for (int i = 0; i < lng; i++)
            {
                Console.WriteLine("{0} {1}", strArr[i, 0], strArr[i, 1]);
            }

            Console.WriteLine("StringBuilder:");
            for (int i = 0; i < lng; i++)
            {
                Console.WriteLine("{0} {1}", sbdArr[i, 0], sbdArr[i, 1]);
            }
        }
    }
}
