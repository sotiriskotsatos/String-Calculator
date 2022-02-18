using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Calculator
{
    class StringCalc
    {
        public static string Calc(string [] subStrings)
        {
            for (int i= 0; i<subStrings.Length;i++)
            {
                if (subStrings[i].Equals("*") || subStrings[i].Equals("/"))
                {
                    subStrings[i] = subStrings[i].Equals("*")?
                                   (Convert.ToDouble(subStrings[i - 1]) *Convert.ToDouble(subStrings[i + 1])).ToString()
                                 : (Convert.ToDouble(subStrings[i - 1]) / Convert.ToDouble(subStrings[i + 1])).ToString();
                    subStrings[i - 1] = subStrings[i + 1] = "e";
                }                
                subStrings = subStrings.Where(x => !x.Equals("e")).ToArray();
            }
            for (int i = 0; i < subStrings.Length; i++)
            {
                if (subStrings[i].Equals("+") || subStrings[i].Equals("-"))
                {
                    subStrings[i] = subStrings[i].Equals("+")?
                                  (Convert.ToDouble(subStrings[i - 1]) + Convert.ToDouble(subStrings[i + 1])).ToString()
                                : (Convert.ToDouble(subStrings[i - 1]) - Convert.ToDouble(subStrings[i + 1])).ToString();
                    subStrings[i - 1] = subStrings[i + 1] = "e";
                }                
                subStrings = subStrings.Where(x => !x.Equals("e")).ToArray();
            }
            return subStrings[0];
        }
    }
}
