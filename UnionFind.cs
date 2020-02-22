public class UnionFind
{
    int[] par;
    public UnionFind(int n)
    {
        par = Enumerable.Range(0, n).Select(_ => -1).ToArray();
    }

    int root(int x)
    {
        if (par[x] < 0) return x;
        else return par[x] = root(par[x]);
    }

    bool issame(int x, int y)
    {
        return root(x) == root(y);
    }

    bool merge(int x, int y)
    {
        x = root(x);
        y = root(y);
        if (x == y) return false;
        if (par[x] > par[y]) Math2.swap(ref x, ref y);
        par[x] += par[y];
        par[y] = x;
        return true;
    }
    int size(int x)
    {
        return -par[root(x)];
    }
}