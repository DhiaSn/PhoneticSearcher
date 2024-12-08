namespace PhoneticSearcher.Core.Matching.StringFuzzyCompare.Aggregators
{
    using PhoneticSearcher.Core.Matching.StringFuzzyCompare.Aggregators.Base;
    using System.Linq;

    public class MaximumAggregator : Aggregator
    {
        public override float AggregatedSimilarity(float[] similarities, float[] weights = null)
        {
            return similarities.Max();
        }
    }
}