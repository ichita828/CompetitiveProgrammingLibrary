public class Math2
{
    public long[] fact;
    public long[] invfact;
    public void factoricalmodset(long N, long MOD = 1000000007)
    {
        fact = new long[N + 1];
        invfact = new long[N + 1];
        fact[0] = 1;

        for (long i = 1; i <= N; ++i) 
        {
            fact[i] = fact[i - 1] * i % MOD ;
        }
        invfact[N] = pow(fact[N], MOD - 2);

        for (long i = N; i > 0; --i)
        {
            invfact[i - 1] = invfact[i] * i % MOD;
        }

    }

    public long nCr(long n, long r, long MOD = 1000000007)
    {
        return (fact[n] * invfact[r] % MOD * invfact[n - r] % MOD);
    }

    public long pow(long i, long n, long MOD = 1000000007)
    {
        long res = 1;
        while (n > 0)
        {
            if ((n & 1) != 0) res = res * i % MOD;
            i = i * i % MOD;
            n >>= 1;
        }
        return res;
    }

    public long gcd(long i, long y)
    {
        while (y != 0)
        {
            var r = i % y;
            i = y;
            y = r;
        }
        return i;
    }

    public long lcm(long i, long y)
    {
        return i * y / gcd(i, y);
    }

    public Dictionary<long, int> primefactorization(long N)
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

    public List<long> divisorenumrate(long N)
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

    public void swap<T>(ref T a, ref T b)
    {
        var i = a;
        a = b;
        b = i;
    }

}
