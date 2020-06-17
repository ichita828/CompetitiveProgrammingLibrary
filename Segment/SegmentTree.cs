public class SegmentTree<T>
{
    int N;
    T[] seg;
    T E;
    Func<T, T, T> F;
    public SegmentTree(T[] arr, T e, Func<T, T, T> f)
    {
        E = e;
        F = f;
        N = 1;
        while (arr.Length > N) N <<= 1;
        seg = new T[2 * N - 1];
        Array.Fill(seg, E);
        for (int i = 0; i < arr.Length; ++i)
        {
            seg[i + N - 1] = arr[i];
        }
        for (int i = N - 2; i >= 0; --i)
        {
            seg[i] = F(seg[2 * i + 1], seg[2 * i + 2]);
        }
    }
    public SegmentTree(int n, T e, Func<T, T, T> f) : this(Enumerable.Repeat(e, n).ToArray(), e, f) { }

    public void Update(int k, T a)
    {
        k += N - 1;
        seg[k] = a;
        while (k > 0)
        {
            k = (k - 1) / 2;
            seg[k] = F(seg[k * 2 + 1], seg[k * 2 + 2]);
        }
    }
    public T Query(int a, int b, int k = 0, int l = 0, int r = -1)
    {
        if (r < 0) r = N;
        if (r <= a || b <= l) return E;
        if (a <= l && r <= b) return seg[k];
        int m = (l + r) / 2;
        return F(Query(a, b, k * 2 + 1, l, m), Query(a, b, k * 2 + 2, m, r));
    }
}