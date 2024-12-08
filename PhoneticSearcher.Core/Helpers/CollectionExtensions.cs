namespace PhoneticSearcher.Core.Helpers
{
    public static class CollectionExtensions
    {
        public static bool ContainsAll<T>(this T[] array1, T[] array2)
        {
            foreach (var item in array2)
            {
                if (!array1.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
