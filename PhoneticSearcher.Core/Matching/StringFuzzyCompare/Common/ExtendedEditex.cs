﻿using PhoneticSearcher.Core.Matching.StringFuzzyCompare.Base;
using PhoneticSearcher.Core.Matching.StringPhoneticKey.Base;
using PhoneticSearcher.Core.Matching.StringTokenize;
using PhoneticSearcher.Core.Matching.StringTokenize.Base;

namespace PhoneticSearcher.Core.Matching.StringFuzzyCompare.Common
{
    /// <summary>
    /// Build the Extended Editex score.
    /// This function is a hybrid it first builds phonetic keys
    /// and then compares each phonetic key by fuzzy string compare function (Levenshtein)
    /// The extension to the standard editex is, it sorts the tokens and uses the best score from unsorted vs. sorted
    /// </summary>
    public class ExtendedEditex : StringFuzzyComparer
    {
        // ***********************Fields***********************

        private StringPhoneticKeyBuilder phoneticKeyBuilder = new StringPhoneticKey.EditexKey();

        private StringFuzzyComparer fuzzyComparer = new DamerauLevenshteinDistance();

        private StringTokenizer tokenizer = new WhiteSpaceTokenizer();

        // *********************Properties*********************

        public StringFuzzyComparer FuzzyComparer
        {
            get { return fuzzyComparer; }
            set { fuzzyComparer = value; }
        }

        // ***********************Functions***********************

        public override float Compare(string str1, string str2)
        {
            if (str1 == null || str2 == null)
            {
                return 0;
            }

            if (!CaseSensitiv)
            {
                str1 = str1.ToLower();
                str2 = str2.ToLower();
            }

            if (str1.Equals(str2))
            {
                return 1.0f;
            }

            // "albert einstein" -> "albert", "einstein"
            var tokens1 = tokenizer.Tokenize(str1).ToList();
            for (int i = 0; i < tokens1.Count; i++)
            {
                // build the phonetic keys
                // "albert" -> "041043", "einstein" -> "058305"
                tokens1[i] = phoneticKeyBuilder.BuildKey(tokens1[i]);
            }

            // "einstein albert" -> "einstein", "albert"
            var tokens2 = tokenizer.Tokenize(str2).ToList();
            for (int i = 0; i < tokens2.Count; i++)
            {
                // build the phonetic keys
                // "einstein" -> "058305", "albert" -> "041043"
                tokens2[i] = phoneticKeyBuilder.BuildKey(tokens2[i]);
            }

            // concat together -> "041043058305"
            string phoneticKey1 = string.Join("", tokens1.ToArray());

            // concat together -> "041043058305"
            string phoneticKey2 = string.Join("", tokens2.ToArray());

            // build the edit distance of the phonetic keys
            float scoreOriginal = fuzzyComparer.Compare(phoneticKey1, phoneticKey2);

            // sort them alphabetically-> "041043", "058305"
            tokens1 = tokens1.OrderBy(x => x).ToList();

            // concat together -> "041043058305"
            phoneticKey1 = string.Join("", tokens1.ToArray());

            // sort them alphabetically-> "041043", "058305"
            tokens2 = tokens2.OrderBy(x => x).ToList();

            // concat together -> "041043058305"
            phoneticKey2 = string.Join("", tokens2.ToArray());

            // build the edit distance of the phonetic keys
            float scoreSorted = fuzzyComparer.Compare(phoneticKey1, phoneticKey2);

            float score = Math.Max(scoreSorted, scoreOriginal);

            return NormalizeScore(phoneticKey1, phoneticKey2, score);
        }

        private float NormalizeScore(string str1, string str2, float score)
        {
            // no normalization is needed it has already the range 0-1
            return score;
        }
    }
}