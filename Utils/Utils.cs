public static class Utils
{
    public static void Swap<T>(ref T A, ref T B)
    {
        T x = A;
        A = B;
        B = x;
    }
    public static int DigitSum(int N)
    {
        string s = N.ToString();
        int ret = 0;
        for (int i = 0; i < s.Length; ++i) ret += s[i] - '0';
        return ret;
    }
}