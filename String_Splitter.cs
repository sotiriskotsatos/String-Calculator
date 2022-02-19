using System.Text.RegularExpressions;

namespace String_Calculator
{
    class String_Splitter
    {
        public static string[] SplitStr(string toSplit)
        {
            return Regex.Split(toSplit, @"(\D)"); //split the string to multiple strings containing operators
        }
    }
}
