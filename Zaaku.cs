public int[] zaaku(long[] a)
{
    var dic = new Dictionary<long, int>();
    long[] ar = new long[a.Length];
    a.CopyTo(ar, 0);
    Array.Sort(ar);
    int z = 0;
    foreach (var x in ar)
    {
        if (!dic.ContainsKey(x))
            dic[x] = z++;
    }
    return a.Select(c => dic[c]).ToArray();
}