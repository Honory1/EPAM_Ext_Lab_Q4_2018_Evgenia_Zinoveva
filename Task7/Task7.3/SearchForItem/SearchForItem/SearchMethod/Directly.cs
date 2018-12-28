namespace SearchForItem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Directly
    {
        public static int[] SearchDirectly(int[] input)
        {
            var output = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > 0)
                {
                    output.Add(input[i]);
                }
            }

            return output.ToArray<int>();
        }
    }
}