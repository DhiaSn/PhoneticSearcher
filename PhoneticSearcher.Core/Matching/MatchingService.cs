using PhoneticSearcher.Core.Matching.StringFuzzyCompare.AddressSpecific;
using PhoneticSearcher.Core.Matching.StringFuzzyCompare.Common;
using PhoneticSearcher.Core.Matching.StringPhoneticKey;
using PhoneticSearcher.Core.Matching.StringFuzzyCompare.Base;
using PhoneticSearcher.Core.Matching.StringPhoneticKey.Base;

namespace PhoneticSearcher.Core.Matching
{
    public partial class MatchingService
    {
        #region Local Variable + Constructor
        private static MatchingService instance = new MatchingService();

        private MatchingService()
        {
        }

        public static MatchingService Instance { get { return instance; } }
        #endregion

        #region Main Methods

        #region CompareRecords 
        public float CompareRecords(string value1, string value2, StringFuzzyCompareEnum type) => GetTypeInstance(type).Compare(value1, value2);
        #endregion

        #region IsMatchingRecords
        public bool IsMatchingRecords(string value1, string value2, StringPhoneticKeyEnum algorithm) => GetAlgorithmInstance(algorithm).BuildKey(value1) == GetAlgorithmInstance(algorithm).BuildKey(value2);
        #endregion

        #endregion

        #region Other Methods 

        #region GetTypeInstance
        private StringFuzzyComparer GetTypeInstance(StringFuzzyCompareEnum type)
        {
            return type switch
            {
                StringFuzzyCompareEnum.NameComparer => new NameComparer(),
                StringFuzzyCompareEnum.TitleComparer => new TitleComparer(),
                StringFuzzyCompareEnum.PhoneComparer => new PhoneComparer(),
                StringFuzzyCompareEnum.CityComparer => new CityComparer(),
                StringFuzzyCompareEnum.CompanyComparer => new CompanyComparer(),
                StringFuzzyCompareEnum.Identity => new Identity(),
                StringFuzzyCompareEnum.LevenshteinDistance => new LevenshteinDistance(),
                StringFuzzyCompareEnum.DamerauLevenshteinDistance => new DamerauLevenshteinDistance(),
                StringFuzzyCompareEnum.NGramDistance => new NGramDistance(),
                StringFuzzyCompareEnum.SmithWaterman => new SmithWaterman(),
                StringFuzzyCompareEnum.Editex => new Editex(),
                StringFuzzyCompareEnum.ExtendedEditex => new ExtendedEditex(),
                StringFuzzyCompareEnum.Jaccard => new Jaccard(),
                StringFuzzyCompareEnum.ExtendedJaccard => new ExtendedJaccard(),
                StringFuzzyCompareEnum.JaroWinkler => new JaroWinkler(),
                StringFuzzyCompareEnum.MongeElkan => new MongeElkan(),
                StringFuzzyCompareEnum.LongestCommonSubsequence => new LongestCommonSubsequence(),
                StringFuzzyCompareEnum.DiceCoefficent => new DiceCoefficent(),
                _ => new NameComparer(),
            };
        }
        #endregion

        #region GetAlgorithmInstance
        private StringPhoneticKeyBuilder GetAlgorithmInstance(StringPhoneticKeyEnum type)
        {
            return type switch
            {
                StringPhoneticKeyEnum.SoundEx => new SoundEx(),
                StringPhoneticKeyEnum.SimpleTextKey => new SimpleTextKey(),
                StringPhoneticKeyEnum.Phonix => new Phonix(),
                StringPhoneticKeyEnum.Metaphone => new Metaphone(),
                StringPhoneticKeyEnum.EditexKey => new EditexKey(),
                StringPhoneticKeyEnum.DoubleMetaphone => new DoubleMetaphone(),
                StringPhoneticKeyEnum.DaitchMokotoff => new DaitchMokotoff(),
                _ => new SoundEx(),
            };
        }
        #endregion

        #endregion
    }
}
