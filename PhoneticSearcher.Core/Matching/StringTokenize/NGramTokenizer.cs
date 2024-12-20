﻿using PhoneticSearcher.Core.Extensions;
using PhoneticSearcher.Core.Matching.StringTokenize.Base;

namespace PhoneticSearcher.Core.Matching.StringTokenize
{
    /// <summary>
    /// Build NGrams of a string (subsequences of the length N).
    ///
    /// Examples:
    /// length = 2: "Müller" -> #M Mü ül ll le er r#
    /// length = 3: "Müller" -> ##M #Mü Mül üll lle ler er# r##
    /// </summary>
    public class NGramTokenizer : StringTokenizer
    {
        // ***********************Constructors***********************

        public NGramTokenizer()
        {
            MaxLength = 2;
        }

        public NGramTokenizer(int maxLength)
        {
            MaxLength = maxLength;
        }

        // ***********************Functions***********************

        public override string[] Tokenize(string str1)
        {
            if (MaxLength == -1)
            {
                MaxLength = 2;
            }

            return BuildNGrams(str1, MaxLength);
        }

        private string[] BuildNGrams(string str1, int length)
        {
            if (length <= 0)
            {
                return new string[0];
            }

            // add fill characters e.g. "Müller" -> #Müller#
            str1 = "".PadLeft(length - 1, '#') + str1 + "".PadLeft(length - 1, '#');

            // enum the number of NGrams
            int nGramCount = str1.Length - length + (length == 1 ? 0 : 1);

            string[] nGrams = new string[str1.Length - 1];
            for (int i = 0; i < nGramCount; i++)
            {
                // build NGram by substring at position i with length
                nGrams[i] = str1.TrySubString(i, length);
            }

            return nGrams;
        }
    }
}