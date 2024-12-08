namespace PhoneticSearcher.Core.Extensions
{
    public static class MathExtension
    {
        public static float Max(params float[] p)
        {
            if (p == null) { return float.MaxValue; }

            float max = float.MinValue;
            for (int i = 0; i < p.Length; i++)
            {
                if (max < p[i])
                {
                    max = p[i];
                }
            }

            return max;
        }
        public static int Min(params int[] p)
        {
            if (p == null) { return int.MinValue; }

            int min = int.MaxValue;
            for (int i = 0; i < p.Length; i++)
            {
                if (min > p[i])
                {
                    min = p[i];
                }
            }
            return min;
        }
    }
}
