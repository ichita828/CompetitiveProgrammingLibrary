public class Factorial {
    public long[] Fact;
    public long[] invFact;
    long _mod;
    public Factorial(long N, long mod = 1000000007) {
        Fact = new long[N + 1];
        invFact = new long[N + 1];
        _mod = mod;
        Fact[0] = 1;
        Fact[1] = 1;
        for (long i = 2; i <= N; ++i) {
            Fact[i] = Fact[i - 1] * i % _mod;
            Fact[i] %= _mod;
        }
        invFact[N] = Power(Fact[N], _mod - 2, _mod);
        for (long i = N; i > 0; --i) {
            invFact[i - 1] = invFact[i] * i % _mod;
            invFact[i - 1] %= _mod;
        }
    }
    public long Comb(long n, long r) {
        if (n < 0 || r < 0 || n < r) return 0;
        return Fact[n] * invFact[r] % _mod * invFact[n - r] % _mod;
    }
}