public static class Array_Algorithm
{
    public static int LIS(long[] array)
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