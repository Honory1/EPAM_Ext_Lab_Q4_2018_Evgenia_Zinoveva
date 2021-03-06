﻿namespace Task6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Sorting
    {
        public delegate bool StringDelegate(string s1, string s2);

        public static bool StringComparison(string s1, string s2)
        {
            bool flag = false;
            if (s1.Length < s2.Length)
            {
                flag = true;
            }

            if (s1.Length == s2.Length)
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1.ToCharArray()[i] > s2.ToCharArray()[i])
                    {
                        flag = false;
                    }

                    if (s1.ToCharArray()[i] < s2.ToCharArray()[i])
                    {
                        flag = true;
                    }
                }
            }

            return flag;
        }

        public void Swap(ref string s1, ref string s2)
        {
            string swapStr = s1;
            s1 = s2;
            s2 = swapStr;
        }

        public void SortByStr(string[] arr, StringDelegate compare)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (compare(arr[j], arr[i]))
                    {
                        this.Swap(ref arr[j], ref arr[i]);
                    }
                }
            }
        }        
    }
}
