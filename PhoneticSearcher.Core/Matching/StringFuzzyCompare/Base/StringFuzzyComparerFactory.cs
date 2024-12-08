using PhoneticSearcher.Core.Utils;
using System.Reflection;

namespace PhoneticSearcher.Core.Matching.StringFuzzyCompare.Base
{
    public class StringFuzzyComparerFactory : GenericFactory
    {
        public static StringFuzzyComparer GetInstance(string typeName, params object[] parameters)
        {
            return GetInstance<StringFuzzyComparer>(Assembly.GetExecutingAssembly(), typeName, parameters);
        }
    }
}
