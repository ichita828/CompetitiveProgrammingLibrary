public class BinarySearch
{
  public static int Lower_Bound<T>(IList<T> Array, T Target)
  {
    return Lower_Bound<T>(Array, Target, Comparer<T>.Default.Compare);
  }
  public static int Lower_Bound<T>(IList<T> Array, T Target, Comparison<T> Comp)
  {
    var cmp = Comparer<T>.Create(Comp);
    var l = -1; //always ng
    var r = Array.Count(); //always ok
    while (r - l > 1)
    {
      var mid = l + (r - l) / 2;
      var res = cmp.Compare(Array[mid], Target);
      if (res >= 0) r = mid;
      else l = mid;
    }
    return r;
  }
  public static int Upper_Bound<T>(IList<T> Array, T Target)
  {
    return Upper_Bound<T>(Array, Target, Comparer<T>.Default.Compare);
  }
  public static int Upper_Bound<T>(IList<T> Array, T Target, Comparison<T> Comp)
  {
    var cmp = Comparer<T>.Create(Comp);
    var l = -1;
    var r = Array.Count;
    while (r - l > 1)
    {
      var mid = l + (r - l) / 2;
      var res = cmp.Compare(Array[mid], Target);
      if (res > 0) r = mid;
      else l = mid;
    }
    return r;
  }
}