using System;

class MatrixOperations13
{
    //method for create a  random matrix
    public static int[,] RandomMatrix(int rows, int cols)
    {
        int[,] mat = new int[rows, cols];
        Random rnd = new Random();
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                mat[i, j] = rnd.Next(1, 10);
        return mat;
    }

    //method for displuy matrix
    public static void Display(int[,] mat)
    {
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            for (int j = 0; j < mat.GetLength(1); j++)
                Console.Write(mat[i, j] + "\t");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    //method for  add thr matrix
    public static int[,] Add(int[,] a, int[,] b)
    {
        int r = a.GetLength(0), c = a.GetLength(1);
        int[,] re = new int[r, c];
        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                re[i, j] = a[i, j] + b[i, j];
        return re;
    }

    //method for subtract thr matrix
    public static int[,] Subtract(int[,] a, int[,] b)
    {
        int r = a.GetLength(0), c = a.GetLength(1);
        int[,] rs = new int[r, c];
        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                rs[i, j] = a[i, j] - b[i, j];
        return rs;
    }

    //method for multiply matrix
    public static int[,] Multiply(int[,] a, int[,] b)
    {
        int r = a.GetLength(0), c = b.GetLength(1), k = a.GetLength(1);
        int[,] res = new int[r, c];
        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                for (int x = 0; x < k; x++)
                    res[i, j] += a[i, x] * b[x, j];
        return res;
    }

    //method for tarnsnspose the  matrix
    public static int[,] Transpose(int[,] a)
    {
        int r = a.GetLength(0), c = a.GetLength(1);
        int[,] res = new int[c, r];
        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                res[j, i] = a[i, j];
        return res;
    }

    //method for detrrminant 2x2
    public static int D2x2(int[,] m) {
        return m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];
    }

    //method for deterrminant 3x3
    public static int D3x3(int[,] m) =>
        m[0, 0] * (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1])
      - m[0, 1] * (m[1, 0] * m[2, 2] - m[1, 2] * m[2, 0])
      + m[0, 2] * (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]);

    //method for inbverse 2x2
    public static double[,] I2x2(int[,] m)
    {
        double det = D2x2(m);
        if (det == 0) return null;
        return new double[,]{
            { m[1,1]/det, -m[0,1]/det},
            {-m[1,0]/det,  m[0,0]/det}
        };
    }

    //method for dispay double matrices
    public static void Display(double[,] mat)
    {
        if (mat == null) { Console.WriteLine("Inverse not possible."); return; }
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            for (int j = 0; j < mat.GetLength(1); j++)
                Console.Write($"{mat[i, j]:F2}\t");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void Main(string[]args)
    {
        //intialize two random 3x3 matrices
        int[,] A = RandomMatrix(3, 3);
        int[,] B = RandomMatrix(3, 3);


        //display matrices and results of operations
        Console.WriteLine("Matrix A:"); Display(A);

        Console.WriteLine("Matrix B:"); Display(B);

        Console.WriteLine("A+B:"); Display(Add(A, B));

        Console.WriteLine("A-B:"); Display(Subtract(A, B));

        Console.WriteLine("A*B:"); Display(Multiply(A, B));

        Console.WriteLine("Transpose of A:"); Display(Transpose(A));



        Console.WriteLine($"Determinant of A (3x3): {D3x3(A)}");

        Console.WriteLine("Inverse of 2x2 matrix (A top-left 2x2):");
        int[,] A2 = new int[2, 2] { { A[0, 0], A[0, 1] }, { A[1, 0], A[1, 1] } };
        Display(I2x2(A2));
    }
}

