using System;
using System.Text.RegularExpressions;

namespace InstaTest
{
   public class Regular
    {
       public static  void ParsingProxy(string x)
        {
            string input = x;
            string pattern = @"(.*):(.*)@(.*):(.*)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);

            string proxyName = match.Groups[1].Value;
            string proxyPass = match.Groups[2].Value;
            string proxy = match.Groups[3].Value;
            string port = match.Groups[4].Value;
        }
    }
}
