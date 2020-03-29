public class BIT
{
    int[] bit;
    int n;
    public BIT(int Maxnum)
    {
        this.n = Maxnum;
        bit = new int[Maxnum + 1];
    }
    //i(1indexed),Add x
    public void add(int i, int x)
    {
        while (i <= n)
        {
            bit[i] += x;
            i += i & -i;
        }
    }
    //[1,i]
    public int sum(int i)
    {
        int ret = 0;
        while (i > 0)
        {
            ret += bit[i];
            i -= i & -i;
        }
        return ret;
    }
    //[a,b]
    public int sum(int a, int b)
    {
        return sum(b) - sum(a - 1);
    }

}