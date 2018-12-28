namespace ExtensionMethod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class StringMethod
    {
        public static bool IsTheStringAPositiveInteger(this string str)
        {
            bool flag = true; 

            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]) || 
                    (str.Length == 1 && str[i] == '0'))
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }
    }
}
