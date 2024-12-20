﻿using PhoneticSearcher.Core.Extensions;
using PhoneticSearcher.Core.Matching.StringTokenize.Base;
using System.Text.RegularExpressions;

namespace PhoneticSearcher.Core.Matching.StringTokenize
{
    /// <summary>
    /// Tokenizes a string into words.
    ///
    /// Examples:
    /// length = -1: "This.are some-words" -> "This" "are" "some" "words"
    /// length =  2: "This.are some-words" -> "Th" "ar" "so" "wo"
    /// </summary>
    public class WordTokenizer : StringTokenizer
    {
        // ***********************Functions***********************

        public override string[] Tokenize(string str1)
        {
            return Words(str1, MaxLength);
        }

        public string[] Words(string str1, int maxLength)
        {
            // split by by everything except characters and numbers
            string[] tokens = Regex.Split(str1, @"[^a-z0-9\.]", RegexOptions.IgnoreCase);

            // cut to the length
            if (maxLength > 0)
            {
                int i = 0;
                foreach (string token in tokens)
                {
                    tokens[i] = token.TrySubstring(maxLength);
                    i++;
                }
            }

            return tokens;
        }
    }
}