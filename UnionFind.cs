public class UnionFind
{
    int _count;
    int[] par, sizes, rank;
    public UnionFind(int n)
    {
        _count = n;
        par = new int[n];
        sizes = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; ++i)
        {
            par[i] = i;
            sizes[i] = 1;
            rank[i] = 0;
        }
    }
    int root(int x)
    {
        if (par[x] == x)
        {
            return x;
        }
        else return par[x] = root(par[x]);
    }

    public bool merge(int x, int y)
    {
        x = root(x);
        y = root(y);
        if (x == y) return false;
        --_count;
        if (rank[x] < rank[y])
        {
            par[x] = y;
            sizes[y] += sizes[x];
        }
        else
        {
            par[y] = x;
            sizes[x] += sizes[y];
            if (rank[x] == rank[y]) ++rank[x];
        }
        return true;
    }
    public bool issame(int x, int y) => root(x) == root(y);
    public int count => _count;
    public bool ispar(int x) => x == root(x);
    public int getpar(int x) => root(x);
    public int size(int x) => sizes[root(x)];
}