public class Factorial {
    public long[] Fact;
    public long[] invFact;
    public Factorial(long N, long MOD = 1000000007) {
        Fact = new long[N + 1];
        invFact = new long[N + 1];
        Fact[0] = 1;
        Fact[1] = 1;
        for (long i = 2; i <= N; ++i) {
            Fact[i] = Fact[i - 1] * i % MOD;
            Fact[i] %= MOD;
        }
        invFact[N] = Power(Fact[N], MOD - 2);
        for (long i = N; i > 0; --i) {
            invFact[i - 1] = invFact[i] * i % MOD;
            invFact[i - 1] %= MOD;
        }
    }
    public long Comb(long n, long r, long MOD = 1000000007) {
        if (n < 0 || r < 0 || n < r) return 0;
        return Fact[n] * invFact[r] % MOD * invFact[n - r] % MOD;
    }
}