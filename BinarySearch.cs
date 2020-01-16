public class BinarySearch
{
    public static int Lower_Bound<T>(T[] array, T target, Comparison<T> comp)
    {
        var cmp = Comparer<T>.Create(comp);
        var l = -1; //always ng
        var r = array.Length; //always ok
        while (r - l > 1)
        {
            var mid = l + (r - l) / 2;
            var res = cmp.Compare(array[mid], target);
            if (res >= 0) r = mid;
            else l = mid;
        }
        return r;

    }
    public static int Upper_Bound<T>(T[] array, T target, Comparison<T> comp)
    {
        var cmp = Comparer<T>.Create(comp);
        var l = -1;
        var r = array.Length;
        while (r - l > 1)
        {
            var mid = l + (r - l) / 2;
            var res = cmp.Compare(array[mid], target);
            if (res > 0) r = mid;
            else l = mid;
        }
        return r;
    }

}