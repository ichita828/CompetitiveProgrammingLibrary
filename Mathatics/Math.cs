public static class Math2
{
    public const int INF = 1 << 29;
    public const long INFL = 1L << 60;
    public const int MOD = 1000000007;
    public const int MOD2 = 998244353;

    public static long Pow(long i, long N, long MOD = 1000000007)
    {
        long res = 1;
        while (N > 0)
        {
            if ((N & 1) != 0) res = res * i % MOD;
            i = i * i % MOD;
            N >>= 1;
        }
        return res;
    }
    public static long GCD(long i, long N)
    {
        while (N != 0)
        {
            var r = i % N;
            i = N;
            N = r;
        }
        return i;
    }
    public static long LCM(long i, long N) => i * N / GCD(i, N);
    public static long Comb(long N, long R, int MOD = 1000000007)
    {
        long ret = 1;
        long x = 1;
        for (long i = N; i >= N - R + 1; --i)
        {
            ret = ret / x * i;
            ret %= MOD;
            x++;
        }
        return ret;
    }
    public static long Comb2(long N, long R)
    {
        long Nume = 1;
        long Deno = 1;

        if (R > N - R) Swap(ref N, ref R);
        for (long i = 1; i <= R; ++i)
        {
            Deno *= i;
            Nume *= N - i + 1;
        }
        return Deno / Nume;
    }
    public static Dictionary<long, int> PrimeFactorization(long N)
    {
        var ret = new Dictionary<long, int>();
        for (long i = 2; i * i <= N; ++i)
        {
            int cnt = 0;
            while (N % i == 0)
            {
                cnt++;
                N /= i;
            }
            if (cnt != 0) ret[i] = cnt;
        }
        if (N >= 2) ret[N] = 1;
        return ret;
    }
    public static List<long> DivisorEnumrate(long N)
    {
        var ret = new List<long>();
        for (long i = 1; i * i <= N; ++i)
        {
            if (N % i == 0)
            {
                ret.Add(i);
                ret.Add(N / i);
            }
        }
        return ret;
    }
}