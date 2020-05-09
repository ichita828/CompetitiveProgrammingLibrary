public static int[] Compress<T>(T[] A)
{
  var dic = new Dictionary<T, int>();
  T[] ar = new T[A.Length];
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