public class Matrix
{
    long[,] mat;
    private int _rowsize;
    public int Rowsize { get { return _rowsize; } }
    private int _columnsize;
    public int Columnsize { get { return _columnsize; } }
    Matrix(long[,] a)
    {
        this.mat = a;
        this._rowsize = a.GetLength(0);
        this._columnsize = a.GetLength(1);
    }
    Matrix(int row, int col)
    {
        this.mat = new long[row, col];
    }

    public static Matrix operator +(Matrix A, Matrix B)
    {
        var ret = new Matrix(A.Rowsize, A.Columnsize);
        for (int i = 0; i < A.Rowsize; ++i)
        {
            for (int j = 0; j < A.Columnsize; ++j)
            {
                ret.mat[i, j] = A.mat[i, j] + B.mat[i, j];
            }

        }

        return ret;
    }
}