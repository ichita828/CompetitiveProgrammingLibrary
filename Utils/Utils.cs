
public static class Utils
{
	public static T[] sort<T>(this T[] a)
	{
		Array.Sort(a);
		return a;
	}
	public static long popcnt(long n)
	{
		n = (n & 0x55555555) + (n >> 1 & 0x55555555);
		n = (n & 0x33333333) + (n >> 2 & 0x33333333);
		n = (n & 0x0f0f0f0f) + (n >> 4 & 0x0f0f0f0f);
		n = (n & 0x00ff00ff) + (n >> 8 & 0x00ff00ff);
		n = (n & 0x0000ffff) + (n >> 16 & 0x0000ffff);
		return n;
	}
	public static int popcnt(BigInteger a)
	{
		int cnt = 0;
		while (a > 0)
		{
			if ((a & 1) == 1) ++cnt;
			a >>= 1;
		}
		return cnt;
	}
	public static void Swap<T>(ref T A, ref T B)
	{
		T x = A;
		A = B;
		B = x;
	}
	public static int DigitSum(string N)
	{

		int ret = 0;
		for (int i = 0; i < N.Length; ++i) ret += N[i] - '0';
		return ret;
	}
	public static string ConvertBase(char[] Num, int from, int to)
	{
		if (new string(Num) == "0") return "0";
		char[] sample = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
		BigInteger ten = 0;
		int power = 0;
		for (int i = Num.Length - 1; i >= 0; --i)
		{
			ten += (BigInteger)(Array.IndexOf(sample, Num[i])) * Power2BI(from, power);
			++power;
		}
		if (to == 10)
		{
			return ten.ToString();
		}
		var ret = new List<char>();
		if (to > 0)
		{
			while (ten > 0)
			{
				int r = (int)(ten % (to));
				ret.Add(sample[r]);
				ten /= to;
			}
		}
		else
		{
			while (ten != 0)
			{
				var r = (int)(ten % -to);
				if (r < 0) r -= to;
				ret.Add(sample[r]);
				ten -= r;
				ten /= -to;
				ten *= -1;
			}
		}
		ret.Reverse();
		return new string(ret.ToArray());
	}
	public static bool NextPermutation<T>(IList<T> lis, Comparison<T> cmp)
	{
		int n = lis.Count;
		int i = n - 1;
		while (i - 1 >= 0)
		{
			if (cmp(lis[i - 1], lis[i]) < 0) break;
			--i;
		}
		if (i == 0) return false;
		int j = i;
		while (j + 1 < n)
		{
			if (cmp(lis[i - 1], lis[j + 1]) > 0) break;
			++j;
		}
		var _q = lis[j];
		lis[j] = lis[i - 1];
		lis[i - 1] = _q;
		int k = i;
		int l = n - 1;
		while (k < l)
		{
			var _p = lis[k];
			lis[k] = lis[l];
			lis[l] = _p;

			++k;
			--l;
		}
		return true;
	}
	public static bool NextPermutation<T>(IList<T> lis) => NextPermutation(lis, Comparer<T>.Default.Compare);
}
