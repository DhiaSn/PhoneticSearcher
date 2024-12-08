namespace PhoneticSearcher.Client
{
    using PhoneticSearcher.Core.Matching;
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Matching Service Examples:\n");

            #region StringFuzzyCompareEnum Examples

            // Example: Name Comparison
            Console.WriteLine("\n\n\n// NameComparer: Handles name variations like shortened or normalized forms.");
            string name1 = "Jonathan";
            string name2 = "Jon";
            Console.WriteLine($"Name Comparison: '{name1}' vs '{name2}' -> Similarity: {MatchingService.Instance.CompareRecords(name1, name2, StringFuzzyCompareEnum.NameComparer)}");

            // Example: Title Comparison
            Console.WriteLine("\n\n\n// TitleComparer: Compares titles while accounting for abbreviations.");
            string title1 = "Dr.";
            string title2 = "Doctor";
            Console.WriteLine($"Title Comparison: '{title1}' vs '{title2}' -> Similarity: {MatchingService.Instance.CompareRecords(title1, title2, StringFuzzyCompareEnum.TitleComparer)}");

            // Example: Phone Comparison
            Console.WriteLine("// PhoneComparer: Compares phone numbers by focusing on matching digits.");
            string phone1 = "+1234567890";
            string phone2 = "123-456-7890";
            Console.WriteLine($"Phone Comparison: '{phone1}' vs '{phone2}' -> Similarity: {MatchingService.Instance.CompareRecords(phone1, phone2, StringFuzzyCompareEnum.PhoneComparer)}");

            // Example: City Comparison
            Console.WriteLine("\n\n\n// CityComparer: Matches cities, accounting for sub-regions or neighborhoods.");
            string city1 = "New York - Manhattan";
            string city2 = "Manhattan";
            Console.WriteLine($"City Comparison: '{city1}' vs '{city2}' -> Similarity: {MatchingService.Instance.CompareRecords(city1, city2, StringFuzzyCompareEnum.CityComparer)}");

            // Example: Company Comparison
            Console.WriteLine("\n\n\n// CompanyComparer: Compares full company names and their acronyms.");
            string company1 = "International Business Machines";
            string company2 = "IBM";
            Console.WriteLine($"Company Comparison: '{company1}' vs '{company2}' -> Similarity: {MatchingService.Instance.CompareRecords(company1, company2, StringFuzzyCompareEnum.CompanyComparer)}");

            // Example: Identity
            Console.WriteLine("\n\n\n// Identity: Checks for exact string matches.");
            string id1 = "example";
            string id2 = "example";
            Console.WriteLine($"Identity Match: '{id1}' vs '{id2}' -> Similarity: {MatchingService.Instance.CompareRecords(id1, id2, StringFuzzyCompareEnum.Identity)}");

            // Example: Levenshtein Distance
            Console.WriteLine("\n\n\n// LevenshteinDistance: Measures edit distance for typos.");
            string leven1 = "kitten";
            string leven2 = "sitting";
            Console.WriteLine($"Levenshtein Distance: '{leven1}' vs '{leven2}' -> Similarity: {MatchingService.Instance.CompareRecords(leven1, leven2, StringFuzzyCompareEnum.LevenshteinDistance)}");

            // Example: Damerau-Levenshtein Distance
            Console.WriteLine("\n\n\n// DamerauLevenshteinDistance: Like Levenshtein but allows transpositions.");
            string damerau1 = "acres";
            string damerau2 = "cares";
            Console.WriteLine($"Damerau-Levenshtein Distance: '{damerau1}' vs '{damerau2}' -> Similarity: {MatchingService.Instance.CompareRecords(damerau1, damerau2, StringFuzzyCompareEnum.DamerauLevenshteinDistance)}");

            // Example: NGram Distance
            Console.WriteLine("\n\n\n// NGramDistance: Compares strings by breaking them into overlapping substrings.");
            string nGram1 = "hello";
            string nGram2 = "hallo";
            Console.WriteLine($"NGram Distance: '{nGram1}' vs '{nGram2}' -> Similarity: {MatchingService.Instance.CompareRecords(nGram1, nGram2, StringFuzzyCompareEnum.NGramDistance)}");

            // Example: Smith-Waterman
            Console.WriteLine("\n\n\n// SmithWaterman: Finds optimal alignment, useful for DNA/protein strings.");
            string smith1 = "alignment";
            string smith2 = "aligment";
            Console.WriteLine($"Smith-Waterman: '{smith1}' vs '{smith2}' -> Similarity: {MatchingService.Instance.CompareRecords(smith1, smith2, StringFuzzyCompareEnum.SmithWaterman)}");

            // Example: Editex
            Console.WriteLine("\n\n\n// Editex: Combines phonetic and edit distance for text matching.");
            string editex1 = "sound";
            string editex2 = "sounds";
            Console.WriteLine($"Editex: '{editex1}' vs '{editex2}' -> Similarity: {MatchingService.Instance.CompareRecords(editex1, editex2, StringFuzzyCompareEnum.Editex)}");

            // Example: Extended Editex
            Console.WriteLine("\n\n\n// ExtendedEditex: Improved Editex with phonetic enhancements.");
            Console.WriteLine($"Extended Editex: '{editex1}' vs '{editex2}' -> Similarity: {MatchingService.Instance.CompareRecords(editex1, editex2, StringFuzzyCompareEnum.ExtendedEditex)}");

            // Example: Jaccard
            Console.WriteLine("\n\n\n// Jaccard: Compares sets of tokens based on overlap.");
            string jaccard1 = "abc def ghi";
            string jaccard2 = "def ghi jkl";
            Console.WriteLine($"Jaccard: '{jaccard1}' vs '{jaccard2}' -> Similarity: {MatchingService.Instance.CompareRecords(jaccard1, jaccard2, StringFuzzyCompareEnum.Jaccard)}");

            // Example: Extended Jaccard
            Console.WriteLine("\n\n\n// ExtendedJaccard: Uses fuzzy matching for tokens.");
            Console.WriteLine($"Extended Jaccard: '{jaccard1}' vs '{jaccard2}' -> Similarity: {MatchingService.Instance.CompareRecords(jaccard1, jaccard2, StringFuzzyCompareEnum.ExtendedJaccard)}");

            // Example: Jaro-Winkler
            Console.WriteLine("\n\n\n// JaroWinkler: Focuses on common prefix matching.");
            string jaro1 = "martha";
            string jaro2 = "marhta";
            Console.WriteLine($"Jaro-Winkler: '{jaro1}' vs '{jaro2}' -> Similarity: {MatchingService.Instance.CompareRecords(jaro1, jaro2, StringFuzzyCompareEnum.JaroWinkler)}");

            // Example: Monge-Elkan
            Console.WriteLine("\n\n\n// MongeElkan: Matches tokens based on the best fuzzy match.");
            string monge1 = "quick brown fox";
            string monge2 = "fast brown dog";
            Console.WriteLine($"Monge-Elkan: '{monge1}' vs '{monge2}' -> Similarity: {MatchingService.Instance.CompareRecords(monge1, monge2, StringFuzzyCompareEnum.MongeElkan)}");

            // Example: Longest Common Subsequence
            Console.WriteLine("\n\n\n// LongestCommonSubsequence: Finds longest matching subsequence.");
            string lcs1 = "abcdef";
            string lcs2 = "acdf";
            Console.WriteLine($"Longest Common Subsequence: '{lcs1}' vs '{lcs2}' -> Similarity: {MatchingService.Instance.CompareRecords(lcs1, lcs2, StringFuzzyCompareEnum.LongestCommonSubsequence)}");

            // Example: Dice Coefficient
            Console.WriteLine("\n\n\n// DiceCoefficient: Measures similarity using overlapping tokens.");
            string dice1 = "night";
            string dice2 = "nacht";
            Console.WriteLine($"Dice Coefficient: '{dice1}' vs '{dice2}' -> Similarity: {MatchingService.Instance.CompareRecords(dice1, dice2, StringFuzzyCompareEnum.DiceCoefficent)}");

            #endregion

            #region StringPhoneticKeyEnum Examples

            // Phonetic Algorithms
            Console.WriteLine("\n\n\n// Phonetic Algorithms: Matching based on sound.");

            string phonetic1 = "Smith";
            string phonetic2 = "Smyth";

            foreach (StringPhoneticKeyEnum algorithm in Enum.GetValues(typeof(StringPhoneticKeyEnum)))
            {
                Console.WriteLine($"{algorithm}: '{phonetic1}' vs '{phonetic2}' -> Match: {MatchingService.Instance.IsMatchingRecords(phonetic1, phonetic2, algorithm)}");
            }

            #endregion

            Console.WriteLine("\nAll examples executed!");
        }
    }

}
