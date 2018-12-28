namespace SearchForItem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Linq
    {
        public static int[] SearchLinq(int[] input)
        {
            var output = from item in input
                         where item > 0
                         select item;

            return output.ToArray();
        }
    }
}