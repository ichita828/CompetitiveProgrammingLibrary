public class PotentializedUnionFind
{
  int _count;
  int[] par, sizes, rank;
  long[] weight;
  public PotentializedUnionFind(int N)
  {
    _count = N;
    par = new int[N];
    sizes = new int[N];
    rank = new int[N];
    weight = new long[N];
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
    else
    {
      int r = Root(par[X]);
      weight[X] += weight[par[X]];
      return (par[X] = r);
    }
  }
  public bool Merge(int X, int Y, long W)
  {
    W += GetWeight(X);
    W -= GetWeight(Y);
    X = Root(X);
    Y = Root(Y);
    if (X == Y) return false;
    --_count;
    if (rank[X] < rank[Y])
    {
      par[X] = Y;
      sizes[Y] += sizes[X];
      weight[X] = -W;
    }
    else
    {
      par[Y] = X;
      sizes[X] += sizes[Y];
      if (rank[X] == rank[Y]) ++rank[X];
      weight[Y] = W;
    }
    return true;
  }
  public bool IsSame(int X, int Y) => Root(X) == Root(Y);
  public int Count => _count;
  public bool IsParent(int X) => X == Root(X);
  public int GetParent(int X) => Root(X);
  public int Size(int X) => sizes[Root(X)];
  public long GetWeight(int X) { Root(X); return weight[X]; }
  public long GetDiff(int X, int Y) => GetWeight(Y) - GetWeight(X);
}