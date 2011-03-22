using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace QDB
{
    public class StringHelper
    {
        public static string Parse(string text)
        {
            return Regex.Replace(text, @"((ht|f)tps*|ssh)://(\S+)", new MatchEvaluator(replaceMe));
        }

        public static string replaceMe(Match m)
        {
            return "<a href=\"" + m.Groups[0].ToString() + "\">" + m.Groups[0].ToString() + "</a>";
        }
    }
}