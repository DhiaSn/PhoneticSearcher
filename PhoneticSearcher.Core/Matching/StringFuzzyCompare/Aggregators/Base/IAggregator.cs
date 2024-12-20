﻿namespace PhoneticSearcher.Core.Matching.StringFuzzyCompare.Aggregators.Base
{
    public interface IAggregator
    {
        float AggregatedSimilarity(float[] similarities, float[] weights);
    }
}
