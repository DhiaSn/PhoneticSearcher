using PhoneticSearcher.Core.Matching.StringFuzzyCompare.Base;
using System.Text;

namespace PhoneticSearcher.Core.Matching.StringFuzzyCompare.Common
{
    public class LongestCommonSubsequence : StringFuzzyComparer
    {
        public override float Compare(string str1, string str2)
        {
            if (!CaseSensitiv)
            {
                str1 = str1.ToLower();
                str2 = str2.ToLower();
            }

            string sequence = "";
            var value = BuildLongestCommonSubsequence(str1, str2, out sequence);

            return NormalizeScore(str1, str2, value);
        }

        private float NormalizeScore(string str1, string str2, float score)
        {
            // get the max score
            float maxLen = Math.Max(str1.Length, str2.Length);

            if (maxLen == 0)
            {
                return 1;
            }

            // return actual / possible distance to get 0-1 range
            return score / maxLen;
        }

        public float BuildLongestCommonSubsequence(string str1, string str2, out string sequence)
        {
            sequence = "";
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
            {
                return 0;
            }

            int[,] num = new int[str1.Length, str2.Length];
            int maxlen = 0;
            int lastSubsBegin = 0;
            var sequenceBuilder = new StringBuilder();

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] != str2[j])
                        num[i, j] = 0;
                    else
                    {
                        if (i == 0 || j == 0)
                            num[i, j] = 1;
                        else
                            num[i, j] = 1 + num[i - 1, j - 1];

                        if (num[i, j] > maxlen)
                        {
                            maxlen = num[i, j];
                            int thisSubsBegin = i - num[i, j] + 1;
                            if (lastSubsBegin == thisSubsBegin)
                            {
                                //if the current LCS is the same as the last time this block ran
                                sequenceBuilder.Append(str1[i]);
                            }
                            else
                            {
                                //this block resets the string builder if a different LCS is found
                                lastSubsBegin = thisSubsBegin;
                                sequenceBuilder.Length = 0; //clear it
                                sequenceBuilder.Append(str1.Substring(lastSubsBegin, i + 1 - lastSubsBegin));
                            }
                        }
                    }
                }
            }
            sequence = sequenceBuilder.ToString();
            return maxlen;
        }

        public string Explain(string str1, string str2)
        {
            if (!CaseSensitiv)
            {
                str1 = str1.ToLower();
                str2 = str2.ToLower();
            }

            string sequence = "";
            var value = BuildLongestCommonSubsequence(str1, str2, out sequence);
            return sequence;
        }

    }
}