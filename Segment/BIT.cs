public class BIT {
    long[] bit;
    int size;
    public BIT(int N) {
        bit = new long[N + 1];
        size = N;
    }
    public BIT(int N, IList<long> list) {
        bit = new long[N + 1];
        size = N;
        for (int i = 0; i < N; ++i) {
            Add(i + 1, list[i]);
        }
    }
    //[1,i]
    public long Sum(int i) {
        long ret = 0;
        for (int x = i; x > 0; x -= x & -x) {
            ret += bit[x];
        }
        return ret;
    }
    //1indexed,[i,j]
    public long Sum(int i, int j) {
        return Sum(j) - Sum(i - 1);
    }
    //1indexed
    public void Add(int i, long x) {
        for (int y = i; y <= size; y += y & -y) {
            bit[y] += x;
        }
    }

}