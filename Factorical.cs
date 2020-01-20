
public class Factorical
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
            fact[i] = Math2.fact[i - 1] * i % MOD;
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
}