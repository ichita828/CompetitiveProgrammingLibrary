public static long[] yates(int size)
{
    var c = Enumerable.Range(1, size).Select(i => (long)i).ToArray();
    var rnd = new Random();
    for (int i = size - 1; i >= 0; --i)
    {
        int j = rnd.Next(0, i + 1);
        var x = c[i];
        c[i] = c[j];
        c[j] = x;
    }
    return c;
}