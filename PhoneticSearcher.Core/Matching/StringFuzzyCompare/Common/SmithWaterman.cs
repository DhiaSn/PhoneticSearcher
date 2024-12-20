﻿using PhoneticSearcher.Core.Extensions;
using PhoneticSearcher.Core.Matching.StringFuzzyCompare.StringCostFunctions;
using PhoneticSearcher.Core.Matching.StringFuzzyCompare.Base;

namespace PhoneticSearcher.Core.Matching.StringFuzzyCompare.Common
{
    public class SmithWaterman : StringFuzzyComparer
    {
        // ***********************Fields***********************

        private float gapCost = 0.1f;

        // ***********************Constructors***********************

        public SmithWaterman()
        {
            CostFunction = new SmithWatermanCostFunction();
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

            float swscore = BuildSmithWaterman(str1, str2);

            return NormalizeScore(str1, str2, swscore);
        }

        private float NormalizeScore(string str1, string str2, float score)
        {
            // get the max score
            float maxLen = Math.Min(str1.Length, str2.Length);

            if (1.0f <= -gapCost)
            {
                maxLen *= -gapCost;
            }

            if (maxLen == 0)
            {
                return 1;
            }

            //  actual / possible distance to get 0-1 range
            return score / maxLen;
        }

        public float BuildSmithWaterman(string str1, string str2)
        {
            float[,] matrix = new float[str1.Length + 1, str2.Length + 1];

            matrix[0, 0] = 0;

            // fill first row and column with 0
            for (int i = 1; i <= str1.Length; i++)
            {
                matrix[i, 0] = 0;
            }
            for (int j = 1; j <= str2.Length; j++)
            {
                matrix[0, j] = 0;
            }

            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    float matchCost = CostFunction.GetCost(str1, i - 1, str2, j - 1);

                    float scoreDiag = matrix[i - 1, j - 1];       // match/mismatch
                    float scoreUp = matrix[i - 1, j];             // deletion
                    float scoreLeft = matrix[i, j - 1];           // insertion

                    matrix[i, j] = MathExtension.Max(0,
                                                     scoreDiag + matchCost,
                                                     scoreLeft - gapCost,
                                                     scoreUp - gapCost);
                }
            }

            return matrix[str1.Length, str2.Length];
        }
    }
}