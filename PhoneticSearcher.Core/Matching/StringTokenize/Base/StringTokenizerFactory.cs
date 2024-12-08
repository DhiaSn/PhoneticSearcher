using PhoneticSearcher.Core.Utils;
using PhoneticSearcher.Core.Matching.StringTokenize.Base;

namespace Ijeni.Core.SharedKernel.PhoneticSearcher.Matching.StringTokenize.Base
{
    public class StringTokenizerFactory : GenericFactory
    {
        public static StringTokenizer GetInstance(string typeName)
        {
            return GetInstance<StringTokenizer>(typeName);
        }
    }
}
