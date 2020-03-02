public class matrix
{
    public int[][] product(int[][] A, int[][] B) //a l*m b m*n
    {
        var ret = new int[A.Length][]; //l*n
        ret = Enumerable.Range(0, A.Length).Select(_ => new int[B[0].Length]).ToArray();
        Enumerable.Range(0, A.Length).Select(_ => new int[B[0].Length]);
        for (int i = 0; i < A.Length; ++i)
        {
            for (int j = 0; j < B[0].Length; ++j)
            {
                for (int k = 0; k < A[0].Length; ++k)
                {
                    ret[i][j] += A[i][k] * B[k][j];
                }
            }
        }
        return ret;
    }

    public long[][] product(long[][] A, long[][] B) //a l*m b m*n
    {
        var ret = new long[A.Length][]; //l*n
        ret = Enumerable.Range(0, A.Length).Select(_ => new long[B[0].Length]).ToArray();
        for (int i = 0; i < A.Length; ++i)
        {
            for (int j = 0; j < B[0].Length; ++j)
            {
                for (int k = 0; k < A[0].Length; ++k)
                {
                    ret[i][j] += A[i][k] * B[k][j];
                }
            }
        }
        return ret;
    }

    public double[][] product(double[][] A, double[][] B) //a l*m b m*n
    {
        var ret = new double[A.Length][]; //l*n        
        ret = Enumerable.Range(0, A.Length).Select(_ => new double[B[0].Length]).ToArray();

        for (int i = 0; i < A.Length; ++i)
        {
            for (int j = 0; j < B[0].Length; ++j)
            {
                for (int k = 0; k < A[0].Length; ++k)
                {
                    ret[i][j] += A[i][k] * B[k][j];
                }
            }
        }
        return ret;
    }
    public T[][] vertical<T>(T[] A)
    {
        var ret = new T[A.Length][];
        for (int i = 0; i < A.Length; ++i)
        {
            ret[i][0] = A[i];
        }
        return ret;
    }

    public T[][] transpose<T>(T[][] A)
    {
        var ret = new T[A[0].Length][];
        for (int i = 0; i < A[0].Length; ++i)
        {
            ret[i] = new T[A.Length];
        }
        for (int i = 0; i < A.Length; ++i)
        {
            for (int j = 0; j < A[0].Length; ++j)
            {
                ret[j][i] = A[i][j];
            }
        }
        return ret;
    }

    public long[][] pow(long[][] A, int n)
    {
        var ret = new long[A.Length][];
        for (int i = 0; i < A.Length; ++i)
        {
            ret[i] = new long[A.Length];
            ret[i][i] = 1L;
        }
        while (n > 0)
        {
            if ((n & 1) != 0)
            {
                ret = product(ret, A);
            }
            A = product(A, A);
            n >>= 1;
        }
        return ret;
    }

    public void matwrite<T>(T[][] A)
    {
        for (int i = 0; i < A.Length; ++i)
        {
            write(A[i]);
        }
    }
}