public class PriorityQueue<T>
{
    List<T> _item;
    public int Count { get { return _item.Count; } }
    bool _isascend { get; set; }
    public T Peek { get { return _item[0]; } }
    Comparison<T> Comp;
    public PriorityQueue(bool IsAscend = true, IEnumerable<T> list = null) : this(Comparer<T>.Default.Compare, IsAscend, list) { }
    public PriorityQueue(Comparison<T> cmp, bool IsAscend = true, IEnumerable<T> list = null)
    {
        _item = new List<T>();
        _isascend = IsAscend;
        this.Comp = cmp;
        if (list != null)
        {
            _item.AddRange(list);
            Build();
        }
    }

    private int Compare(int i, int j) => (_isascend ? -1 : 1) * Comp(_item[i], _item[j]);
    private void Swap(int i, int j) { var t = _item[i]; _item[i] = _item[j]; _item[j] = t; }
    private int Parent(int i)
        => (i - 1) >> 1;
    private int Left(int i)
        => (i << 1) + 1;
    public T Enqueue(T val)
    {
        int i = _item.Count;
        _item.Add(val);
        while (i > 0)
        {
            int p = Parent(i);
            if (Compare(i, p) > 0)
                Swap(i, p);
            i = p;
        }
        return val;
    }
    private void Heapify(int index)
    {
        for (int i = index, j; (j = Left(i)) < _item.Count; i = j)
        {
            if (j != _item.Count - 1 && Compare(j, j + 1) < 0) j++;
            if (Compare(i, j) < 0)
                Swap(i, j);
        }
    }
    public T Dequeue()
    {
        T val = _item[0];
        _item[0] = _item[_item.Count - 1];
        _item.RemoveAt(_item.Count - 1);
        Heapify(0);
        return val;
    }
    private void Build()
    {
        for (var i = (_item.Count >> 1) - 1; i >= 0; i--)
            Heapify(i);
    }
}
