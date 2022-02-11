using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace String_Calculator
{
    class String_Splitter
    {
        public string[] SplitStr(string toSplit)
        {
            return Regex.Split(toSplit, (@"\D"));
        }
    }
}
