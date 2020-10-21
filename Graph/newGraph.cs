
public static class Graph
{
    public static long[] dijkstra(List<(long cost, int to)>[] edge, int from, long INF = Math2.INFL)
    {
        long[] ret = Enumerable.Range(0, edge.Length).Select(_ => INF).ToArray();
        var pq = new PriorityQueue<(long cost, int to)>((a, b) => (int)(a.cost - b.cost));
        ret[from] = 0;
        pq.Enqueue((0, from));
        while (pq.Count > 0)
        {
            var p = pq.Dequeue();
            var v = p.Item2;
            if (ret[v] < p.Item1) continue;
            foreach (var e in edge[v])
            {
                if (ret[e.Item2] > ret[v] + e.Item1)
                {
                    ret[e.Item2] = ret[v] + e.Item1;
                    pq.Enqueue((ret[e.to], e.to));
                }
            }
        }
        return ret;
    }
		
    public static long[][] Warshall_Floyd(List<(long cost, int to)>[] edge)
    {
        var ret = new long[edge.Length][];
        for (int i = 0; i < edge.Length; ++i)
        {
            ret[i] = Enumerable.Repeat(INFL, edge.Length).ToArray();
        }
        for (int i = 0; i < edge.Length; ++i)
        {
            foreach (var x in edge[i])
            {
                ret[i][x.to] = x.cost;
            }
        }
        for (int i = 0; i < edge.Length; ++i) ret[i][i] = 0;
        for (int k = 0; k < edge.Length; ++k)
        {
            for (int i = 0; i < edge.Length; ++i)
            {
                for (int j = 0; j < edge.Length; ++j)
                {
                    ret[i][j] = Min(ret[i][j], ret[i][k] + ret[k][j]);
                }
            }
        }
        return ret;

    }
    public static bool IsBipartiteGraph(List<Tuple<long, int>>[] edge)
    {
        var color = Enumerable.Repeat(-1, edge.Length).ToArray();
        Func<int, int, bool> dfs = null;
        dfs = (int v, int c) =>
        {
            color[v] = c;
            foreach (var nv in edge[v])
            {
                if (color[nv.Item2] == c) return false;
                if (color[nv.Item2] == -1 && !dfs(nv.Item2, 1 - c)) return false;
            }
            return true;
        };
        for (int i = 0; i < edge.Length; ++i)
        {
            if (color[i] == -1)
            {
                if (!dfs(i, 0))
                {
                    return false;
                }
            }
        }
        return true;
    }
    public static List<Tuple<long, int>>[] totp(List<int>[] lis)
    {
        var ret = new List<Tuple<long, int>>[lis.Length];
        for (int i = 0; i < lis.Length; ++i)
        {
            ret[i] = new List<Tuple<long, int>>();
            foreach (var x in lis[i])
            {
                ret[i].Add(new Tuple<long, int>(1, x));
            }
        }
        return ret;
    }
    public static long[][] tomat(List<Tuple<long, int>>[] edge)
    {
        var ret = new long[edge.Length][];
        for (int i = 0; i < edge.Length; ++i)
        {
            ret[i] = new long[edge.Length];
            for (int j = 0; j < edge.Length; ++j)
            {
                ret[i][j] = Math2.INFL;
            }
        }
        for (int i = 0; i < edge.Length; ++i)
        {
            foreach (var x in edge[i])
            {
                ret[i][x.Item1] = x.Item2;
            }
        }
        return ret;
    }
    public static List<Tuple<long, int>>[] toli(long[][] s)
    {
        var ret = new List<Tuple<long, int>>[s.Length];
        for (int i = 0; i < s.Length; ++i) ret[i] = new List<Tuple<long, int>>();
        for (int i = 0; i < s.Length; ++i)
        {
            for (int j = 0; j < s.Length; ++j)
            {
                if (s[i][j] != 0) ret[i].Add(new Tuple<long, int>(s[i][j], j));
            }
        }
        return ret;
    }

}

