public class SegmentTree<T>
{
    Func<T, T, T> F;
    int sz;
    T[] seg;
    T I;
    public SegmentTree(int n, Func<T, T, T> f, T e, IList<T> lis = null)
    {
        F = f;
        sz = 1;
        while (sz < n) sz <<= 1;
        seg = new T[(n << 1) - 1];
        I = e;
        for (int i = 0; i < seg.Length; ++i) seg[i] = I;
        if (lis != null) for (int i = 0; i < n; ++i) Set(i, lis[i]);
        AUpdate();
    }
    void Set(int k, T x)
    {
        seg[k + sz - 1] = x;
    }
    void Build()
    {
        for (int k = sz - 1; k > 0; --k)
        {
            seg[k] = F(seg[2 * k], seg[2 * k + 1]);
        }
    }
    public void Update(int k, T x)
    {
        Set(k, x);
        Update(k);
    }

    public void Update(int k)
    {
        int i = k + sz - 1;
        while (i > 0)
        {
            i = i - 1 >> 1;
            seg[i] = F(seg[i << 1 | 1], seg[i + 1 << 1]);
        }
    }
    public void AUpdate()
    {
        for (int i = sz - 2; i >= 0; i--)
        {
            seg[i] = F(seg[i << 1 | 1], seg[i + 1 << 1]);
        }
    }
    public T at(int i) => seg[i + sz - 1];
    public T run(int s, int t) => run(s, t, 0, 0, sz);
    T run(int s, int t, int k, int l, int r) => r <= s || t <= l ? I : s <= l && r <= t ? seg[k]
    : F(run(s, t, k << 1 | 1, l, l + r >> 1), run(s, t, k + 1 << 1, l + r >> 1, r));
}
