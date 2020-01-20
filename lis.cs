public static class lis
{
    const int INF = 1 << 29;
    public static int LIS(int[] array)
    {
        var len = array.Length;
        var dp = Enumerable.Range(0, len).Select(_ => INF).ToArray();
        for (int i = 0; i < len; ++i)
        {
            dp[BinarySearch.Lower_Bound(dp, array[i], (a, b) => (a - b))] = array[i];
        }
        return len - BinarySearch.Lower_Bound(dp, INF, (a, b) => (a - b));
    }
}