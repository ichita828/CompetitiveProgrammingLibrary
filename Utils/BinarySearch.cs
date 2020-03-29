public class BinarySearch
{
    public static int Lower_Bound<T>(T[] Array, T Target, Comparison<T> Comp)
    {
        var cmp = Comparer<T>.Create(Comp);
        var l = -1; //always ng
        var r = Array.Length; //always ok
        while (r - l > 1)
        {
            var mid = l + (r - l) / 2;
            var res = cmp.Compare(Array[mid], Target);
            if (res >= 0) r = mid;
            else l = mid;
        }
        return r;
    }
    public static int Upper_Bound<T>(T[] Array, T Target, Comparison<T> Comp)
    {
        var cmp = Comparer<T>.Create(Comp);
        var l = -1;
        var r = Array.Length;
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