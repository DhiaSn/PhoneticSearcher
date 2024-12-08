using System.Reflection;
using PhoneticSearcher.Core.Utils;

namespace PhoneticSearcher.Core.Matching.StringPhoneticKey.Base
{
    public class StringPhoneticKeyBuilderFactory : GenericFactory
    {
        public static StringPhoneticKeyBuilder GetInstance(string typeName, params object[] parameters)
        {
            return GetInstance<StringPhoneticKeyBuilder>(Assembly.GetExecutingAssembly(), typeName, parameters);
        }
    }
}
