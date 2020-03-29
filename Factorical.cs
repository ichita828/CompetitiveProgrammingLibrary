public class Factorical
{
    public long[] Fact;
    public long[] invFact;
    public Factorical(long N, long MOD = 1000000007)
    {
        Fact = new long[N + 1];
        invFact = new long[N + 1];
        Fact[0] = 1;
        for (long i = 1; i <= N; ++i)
        {
            Fact[i] = Fact[i - 1] * i % MOD;
        }
        invFact[N] = Pow(Fact[N], MOD - 2);
        for (long i = N; i > 0; --i)
        {
            invFact[i - 1] = invFact[i] * i % MOD;
        }
    }
    public long Comb(long n, long r, long MOD = 1000000007) => Fact[n] * invFact[r] % MOD * invFact[n - r] % MOD;
}