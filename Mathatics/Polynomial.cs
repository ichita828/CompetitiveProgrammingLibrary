public static class Polynomial {
  public static Complex[] FFT (Complex[] a, int sgn = 1) {
    int n = a.Length;
    if (n == 1) return a;
    Complex[] b = new Complex[n / 2];
    Complex[] c = new Complex[n / 2];
    for (int i = 0; i < n; ++i) {
      if (i % 2 == 0) b[i / 2] = a[i];
      else c[i / 2] = a[i];
    }
    FFT (b, sgn);
    FFT (c, sgn);
    Complex Zeta = new Complex (Cos (2.0 * PI / n), Sin (2.0 * PI / n) * sgn);
    Complex Powzeta = 1;
    for (int i = 0; i < n; ++i) {
      a[i] = b[i % (n / 2)] + c[i % (n / 2)] * Powzeta;
      Powzeta *= Zeta;
    }
    return a;
  }
  public static long[] Product (long[] a, long[] b) {
    var sz = a.Count () + b.Count () + 1;
    var n = 1;
    while (n < sz) n <<= 2;
    var c = new Complex[n];
    var d = new Complex[n];
    for (int i = 0; i < a.Count (); ++i) c[i] = a[i];
    for (int i = 0; i < b.Count (); ++i) d[i] = b[i];
    FFT (c);
    FFT (d);
    var F = new Complex[n];
    for (int i = 0; i < n; ++i) F[i] = c[i] * d[i];
    FFT (F, -1);
    var ret = new long[n];
    for (int i = 0; i < n; ++i) {
      ret[i] = (int) Round (F[i].Real / n);
    }
    return ret;
  }
}