namespace MyMatrix;
using System;

class Matrix
{
    private int _N;
    private int _M;
    private double[,] _Matrix;

    public Matrix(int n, int m)
    {
        if (n <= 0 || m <= 0)
        {
            throw new Exception("N and M must be postive.");
        }

        _N = n;
        _M = m;
        _Matrix = new double[_N, _M];
    }

    public int GetN()
    {
        return _N;
    }

    public int GetM()
    {
        return _M;
    }

    public void PrintValues()
    {
        for (int i = 0; i < _N; i++)
        {
            for (int j = 0; j < _M; j++)
            {
                Console.Write(_Matrix[i, j] + " ");
            }
            Console.Write("\n");
        }
    }

    public void ValuesFromKeyboard()
    {
        for (int i = 0; i < _N; i++)
        {
            for (int j = 0; j < _M; j++)
            {
                try
                {
                    _Matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }

    public void RandValues(int a, int b)
    {
        System.Random rnd = new Random();

        for (int i = 0; i < _N; i++)
        {
            for (int j = 0; j < _M; j++)
            {
                _Matrix[i, j] = rnd.Next(a, b);
            }
        }
    }

    public double GetValue(int i, int j)
    {
        if (i >= _N || j >= _M)
        {
            throw new IndexOutOfRangeException();
        }

        return _Matrix[i, j];
    }

    public void SetValue(int i, int j, double value)
    {
        if (i >= _N || j >= _M)
        {
            throw new IndexOutOfRangeException();
        }

        _Matrix[i, j] = value;
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.GetN() != b.GetN() || a.GetM() != b.GetM())
        {
            throw new Exception("The operation cannot be performed. Mismatch of matrix dimensions.");
        }

        Matrix result = new Matrix(a.GetN(), b.GetM());

        int bufN = a.GetN();
        int bufM = a.GetM();

        for (int i = 0; i < bufN; i++)
        {
            for (int j = 0; j < bufM; j++)
            {
                result.SetValue(i, j, a.GetValue(i, j) + b.GetValue(i, j));
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.GetM() != b.GetN())
        {
            throw new Exception("The operation cannot be performed. The mismatch of the dimensions of the matrices: a.M must be equal to b.N.");
        }

        Matrix result = new Matrix(a.GetN(), b.GetM());

        int n = a.GetN();
        int p = b.GetM();
        int m = a.GetM();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < p; j++)
            {
                double sum = 0;
                for (int k = 0; k < m; k++)
                {
                    sum += a.GetValue(i, k) * b.GetValue(k, j);
                }
                result.SetValue(i, j, sum);
            }
        }

        return result;
    }

    private Matrix Minor(int x, int y)
    {
        Matrix result = new Matrix(_N - 1, _M - 1);

        int index1 = 0;
        int index2 = 0;

        for (int i = 0; i < _N; i++)
        {
            if (i == x)
                continue;

            for (int j = 0; j < _M; j++)
            {
                if (j == y)
                    continue;

                result.SetValue(index1, index2, _Matrix[i, j]);
                index2 = (index2 + 1) % result.GetN();

            }
            index1 = (index1 + 1) % result.GetN();
        }

        return result;
    }

    public double Det()
    {
        if (_N != _M)
        {
            throw new Exception("The operation cannot be performed. A non-square matrix.");
        }

        if (_N == 1)
        {
            return _Matrix[0, 0];
        }

        double det = 0;

        for (int i = 0; i < _N; i++)
        {
            det += _Matrix[i, 0] * Math.Pow(-1, i + 2) * this.Minor(i, 0).Det();
        }

        return det;
    }

    public Matrix Transpose()
    {
        Matrix result = new Matrix(_M, _N);
        for (int i = 0; i < _N; i++)
        {
            for (int j = 0; j < _M; j++)
            {
                result.SetValue(j, i, _Matrix[i, j]);
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix a, double b)
    {
        int bufN = a.GetN();
        int bufM = a.GetM();

        Matrix result = new Matrix(bufN, bufM);

        for (int i = 0; i < bufN; i++)
        {
            for (int j = 0; j < bufM; j++)
            {
                result.SetValue(i, j, a.GetValue(i, j) * b);
            }
        }

        return result;
    }

    private Matrix Adjugate()
    {
        Matrix result = new Matrix(_N, _M);
        double A = 0;
        for (int i = 0; i < _N; i++)
        {
            for (int j = 0; j < _M; j++)
            {
                A = Math.Pow(-1, i + j + 2) * this.Minor(i, j).Det();
                result.SetValue(i, j, A);
            }
        }

        return result.Transpose();
    }

    public Matrix Inverse()
    {
        if (_N != _M)
        {
            throw new Exception("The operation cannot be performed. A non-square matrix.");
        }

        double det = this.Det();

        if (det == 0)
        {
            throw new Exception("The determinant is zero. Inverse matrix does not exist.");
        }

        return this.Adjugate() * (1 / det);
    }

    public static Matrix SolveEqSys(Matrix A, Matrix B)
    {
        if (B.GetM() != 1)
        {
            throw new Exception("Matrix B must have one column.");
        }

        double bufD = 0;
        try
        {
            bufD = A.Det();
        }
        catch
        {
            throw new Exception("The matrix A must be square.");
        }

        if (bufD == 0)
        {
            throw new Exception("The determinant of matrix A is 0. The system is incompatible.");
        }

        return A.Inverse() * B;
    }

}