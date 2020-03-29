public class UnionFind
{
    int _count;
    int[] par, sizes, rank;
    public UnionFind(int N)
    {
        _count = N;
        par = new int[N];
        sizes = new int[N];
        rank = new int[N];
        for (int i = 0; i < N; ++i)
        {
            par[i] = i;
            sizes[i] = 1;
            rank[i] = 0;
        }
    }
    int Root(int X)
    {
        if (par[X] == X)
        {
            return X;
        }
        else return (par[X] = Root(par[X]));
    }
    public bool Merge(int X, int Y)
    {
        X = Root(X);
        Y = Root(Y);
        if (X == Y) return false;
        --_count;
        if (rank[X] < rank[Y])
        {
            par[X] = Y;
            sizes[Y] += sizes[X];
        }
        else
        {
            par[Y] = X;
            sizes[X] += sizes[Y];
            if (rank[X] == rank[Y]) ++rank[X];
        }
        return true;
    }
    public bool IsSame(int X, int Y) => Root(X) == Root(Y);
    public int Count => _count;
    public bool IsParent(int X) => X == Root(X);
    public int GetParent(int X) => Root(X);
    public int Size(int X) => sizes[Root(X)];
}