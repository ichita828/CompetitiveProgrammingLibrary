public static class Graph
{
    public static long[] dijkstra(List<Tuple<long, int>>[] edge, int from, long INF = Math2.INFL)
    {
        long[] ret = Enumerable.Range(0, edge.Length).Select(_ => INF).ToArray();
        var pq = new PriorityQueue<Tuple<long, int>>((a, b) => (int)(a.Item1 - b.Item1));
        ret[from] = 0;
        pq.Enqueue(new Tuple<long, int>(0, from));
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
                    pq.Enqueue(new Tuple<long, int>(ret[e.Item2], e.Item2));
                }

            }
        }
        return ret;
    }
}