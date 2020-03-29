public static int[] Compress(long[] A)
{
    var dic = new Dictionary<long, int>();
    long[] ar = new long[A.Length];
    A.CopyTo(ar, 0);
    Array.Sort(ar);
    int z = 0;
    foreach (var x in ar)
    {
        if (!dic.ContainsKey(x))
            dic[x] = z++;
    }
    return A.Select(c => dic[c]).ToArray();
}