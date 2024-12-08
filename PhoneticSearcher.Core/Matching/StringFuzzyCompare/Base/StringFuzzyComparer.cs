using PhoneticSearcher.Core.Matching.StringFuzzyCompare.StringCostFunctions;
using PhoneticSearcher.Core.Matching.StringFuzzyCompare.AddressSpecific;
using PhoneticSearcher.Core.Matching.StringFuzzyCompare.Common;
using PhoneticSearcher.Core.Matching.StringFuzzyCompare.StringCostFunctions.Base;
using System.Runtime.Serialization;

namespace PhoneticSearcher.Core.Matching.StringFuzzyCompare.Base
{
    [Serializable]
    [DataContract]
    [KnownType(typeof(DamerauLevenshteinDistance))]
    [KnownType(typeof(ExtendedEditex))]
    [KnownType(typeof(Identity))]
    [KnownType(typeof(ExtendedJaccard))]
    [KnownType(typeof(JaroWinkler))]
    [KnownType(typeof(DiceCoefficent))]
    [KnownType(typeof(MongeElkan))]
    [KnownType(typeof(NGramDistance))]
    [KnownType(typeof(SmithWaterman))]
    [KnownType(typeof(NameComparer))]
    [KnownType(typeof(CityComparer))]
    [KnownType(typeof(CompanyComparer))]
    [KnownType(typeof(PhoneComparer))]
    [KnownType(typeof(TitleComparer))]
    public abstract class StringFuzzyComparer : IStringFuzzyComparer
    {
        // ***********************Fields***********************

        private StringCostFunction costFunction = new DefaultSubstitutionCostFunction();

        private bool caseSensitiv = false;

        // ***********************Properties***********************

        [DataMember]
        public StringCostFunction CostFunction
        {
            get
            {
                if (costFunction == null)
                {
                    costFunction = new DefaultSubstitutionCostFunction();
                }
                return costFunction;
            }
            set { costFunction = value; }
        }

        public string Name
        {
            get { return GetType().Name; }
        }

        public bool CaseSensitiv
        {
            get { return caseSensitiv; }
            set { caseSensitiv = value; }
        }

        // ***********************Functions***********************

        /// <summary>
        /// Compares two strings, with a fuzzy string comparefunction
        /// </summary>
        /// <param name="str1">The STR1.</param>
        /// <param name="str2">The STR2.</param>
        /// <returns></returns>
        public abstract float Compare(string str1, string str2);

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}