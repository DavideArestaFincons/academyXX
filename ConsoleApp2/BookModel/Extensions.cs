using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.BookModel
{
    public static class Extensions
    {
        public static string Prefix(this string s, string prefix)
        {
            return $"{prefix}{s}";
        }

    }
}
