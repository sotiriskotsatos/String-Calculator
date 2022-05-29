﻿using System;
using System.Collections.Generic;

namespace String_Calculator
{
    class StringCalc
    {
        public static string Calc(List<string> subStrings)
        {
            var multDiv = subStrings.FindIndex(x => x.Equals("*") || x.Equals("/"));
            var plusMinus = subStrings.FindIndex(x => x.Equals("+") || x.Equals("-"));
            if (multDiv > -1)
            {
                double prev = Convert.ToDouble(subStrings[multDiv - 1]);
                double next = Convert.ToDouble(subStrings[multDiv + 1]);
                if (subStrings[multDiv].Equals("*"))
                    subStrings[multDiv - 1] = (prev * next).ToString();
                else
                    subStrings[multDiv - 1] = (prev / next).ToString();
                subStrings.RemoveAt(multDiv);
                subStrings.RemoveAt(multDiv);
                return Calc(subStrings);
            }
            else if (plusMinus > -1)
            {
                double prev = Convert.ToDouble(subStrings[plusMinus - 1]);
                double next = Convert.ToDouble(subStrings[plusMinus + 1]);
                if (subStrings[plusMinus].Equals("+"))
                    subStrings[plusMinus - 1] = (prev + next).ToString();
                else
                    subStrings[plusMinus - 1] = (prev - next).ToString();
                subStrings.RemoveAt(plusMinus);
                subStrings.RemoveAt(plusMinus);
                return Calc(subStrings);
            }
            else
                return subStrings[0];
        }
    }
}
