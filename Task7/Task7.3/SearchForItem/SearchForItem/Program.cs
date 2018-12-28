namespace SearchForItem
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public delegate int[] Example(int[] input);

    public class Program
    {
        public const int MaxSize = 50;
        private static int[] input = new int[MaxSize];

        public static void Main(string[] args)
        {
            ArrayFill();

            Stopwatch myStop = new Stopwatch();

            myStop.Start();
            var output = Directly.SearchDirectly(input);
            myStop.Stop();
            TimeSpan ts = myStop.Elapsed;
            output = Array.Empty<int>();

            Console.WriteLine("Search directly times: {0}", ts);
            Console.WriteLine();

            myStop.Restart();
            Example myDel = Directly.SearchDirectly;
            output = myDel(input);
            myStop.Stop();
            ts = myStop.Elapsed;
            output = Array.Empty<int>();

            Console.WriteLine("Search through delegate times: {0}", ts);
            Console.WriteLine();

            myStop.Restart();
            output = Linq.SearchLinq(input);
            myStop.Stop();
            ts = myStop.Elapsed;
            output = Array.Empty<int>();

            Console.WriteLine("Search linq times: {0}", ts);
            Console.WriteLine();

            Example ex = delegate(int[] inputAnon)
            {
                var outputAnon = new List<int>();

                for (int i = 0; i < inputAnon.Length; i++)
                {
                    if (inputAnon[i] > 0)
                    {
                        outputAnon.Add(inputAnon[i]);
                    }
                }

                return outputAnon.ToArray();
            };

            myStop.Restart();
            output = ex(input);
            myStop.Stop();
            ts = myStop.Elapsed;
            output = Array.Empty<int>();

            Console.WriteLine("Search through anonymous method times: {0}", ts);
            Console.WriteLine();

            Example myEx = inputL =>
            {
                var outputL = new List<int>();

                for (int i = 0; i < inputL.Length; i++)
                {
                    if (inputL[i] > 0)
                    {
                        outputL.Add(inputL[i]);
                    }
                }

                return outputL.ToArray();
            };

            myStop.Restart();
            output = myEx(input);
            myStop.Stop();
            ts = myStop.Elapsed;
            output = Array.Empty<int>();

            Console.WriteLine("Search through lambda method times: {0}", ts);
            Console.WriteLine();
        }

        public static void ArrayFill()
        {
            Random randomValue = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = randomValue.Next();
            }
        }
    }
}
