namespace PhoneticSearcher.Core.Matching
{
    public enum StringFuzzyCompareEnum
    {
        NameComparer,
        TitleComparer,
        PhoneComparer,
        CityComparer,
        CompanyComparer,
        Identity,
        LevenshteinDistance,
        DamerauLevenshteinDistance,
        NGramDistance,
        SmithWaterman,
        Editex,
        ExtendedEditex,
        Jaccard,
        ExtendedJaccard,
        JaroWinkler,
        MongeElkan,
        LongestCommonSubsequence,
        DiceCoefficent
    }

    public enum StringPhoneticKeyEnum
    {
        SoundEx,
        SimpleTextKey,
        Phonix,
        Metaphone,
        EditexKey,
        DoubleMetaphone,
        DaitchMokotoff
    }

    public enum StringTokenizeEnum
    {
        FirstNCharsTokenizer,
        NGramTokenizer,
        WhiteSpaceTokenizer,
        WordTokenizer
    }


}
