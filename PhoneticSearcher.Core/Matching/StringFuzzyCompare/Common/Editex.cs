using PhoneticSearcher.Core.Matching.StringFuzzyCompare.Base;
using PhoneticSearcher.Core.Matching.StringPhoneticKey.Base;

namespace PhoneticSearcher.Core.Matching.StringFuzzyCompare.Common
{
    /// <summary>
    /// Build the Editex score.
    /// This function is a hybrid it first builds phonetic keys
    /// and then compares each phonetic key by fuzzy string compare function (Levenshtein)
    /// </summary>
    public class Editex : StringFuzzyComparer
    {
        // ***********************Fields***********************

        private StringPhoneticKeyBuilder phoneticKeyBuilder = new StringPhoneticKey.EditexKey();

        private StringFuzzyComparer fuzzyComparer = new DamerauLevenshteinDistance();

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

            // build the phonetic keys
            // "Müller" -> "50404"
            string phoneticKey1 = phoneticKeyBuilder.BuildKey(str1);

            // "Meier" -> "504"
            string phoneticKey2 = phoneticKeyBuilder.BuildKey(str2);

            // build the edit distance of the phonetic keys
            float score = fuzzyComparer.Compare(phoneticKey1, phoneticKey2);

            return NormalizeScore(phoneticKey1, phoneticKey2, score);
        }

        private float NormalizeScore(string str1, string str2, float score)
        {
            // no normalization is needed it has already the range 0-1
            return score;
        }
    }
}