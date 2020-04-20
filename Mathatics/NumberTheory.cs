public static class NumberTheory
{
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
  List<int> seive(int n)
  {
    var ret = new List<int>();
    bool[] isPrime = new bool[n + 1];
    for (int i = 1; i <= n; ++i) isPrime[i] = true;
    isPrime[1] = false;
    for (int i = 1; i <= n; ++i)
    {
      int j = i;
      if (isPrime[i]) ret.Add(i);
      else continue;
      while (j <= n)
      {
        j += i;
        if (j > n) continue;
        isPrime[j] = false;
      }
    }
    return ret;
  }
  bool isPrime(long n)
  {
    for (int i = 2; i * i <= n; ++i)
    {
      if (n % i == 0) return false;
    }
    return true;
  }
}