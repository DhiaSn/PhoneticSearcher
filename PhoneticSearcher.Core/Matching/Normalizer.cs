﻿using PhoneticSearcher.Core.Utils;
using System.Text.RegularExpressions;

namespace PhoneticSearcher.Core.Matching
{
    public static class Normalizer
    {
        public static string ReplaceUmlauts(string str)
        {
            // replace umlauts
            str = str.Replace("ä", "ae")
                     .Replace("ö", "oe")
                     .Replace("ü", "ue")
                     .Replace("ß", "ss")
                     .Replace("Ä", "Ae")
                     .Replace("Ö", "Oe")
                     .Replace("Ü", "Ue");

            return str;
        }

        public static string RemoveDiacritics(string str)
        {
            return StringUtil.RemoveDiacritics(str);
        }

        public static string RemoveMultipleSpaces(string str)
        {
            return Regex.Replace(str, @"\s+", " ", RegexOptions.Multiline);
        }

        public static string RemoveNoiseChars(string str, string noiseChars, char replaceChar = ' ')
        {
            foreach (var singleChar in noiseChars)
            {
                str = str.Replace(singleChar, replaceChar);
            }

            return str;
        }
    }
}