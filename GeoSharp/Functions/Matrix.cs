using System;
using System.Collections;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GeoSharp.Functions.Matrix;
using static GeoSharp.FunctionUtil;

public class Matrix : IEnumerable<Function>
{
    public Matrix this[double x] => get(x);
    public int Row { get; set; }
    public int Col { get; set; }
    public Function[][] Value { get; set; }

    public void Add(params Function[] arr)
    {

    }


    public Matrix(int row, int col)
    {
        this.Row = row;
        this.Col = col;
        Function[][] matrix = new Function[this.Row][];
        for (int i = 0; i < this.Row; i++)
        {
            matrix[i] = new Function[this.Col];
        }
        this.Value = matrix;
    }
    public Matrix(Function[][] matriz)
    {
        this.Row = matriz.Length;
        this.Col = matriz[0].Length;

        foreach (var row in matriz)
        {
            if (row.Length != Col)
                throw new Exception();
        }

        this.Value = matriz;
    }

    public static Matrix Transpose(Matrix mat)
    {
        Matrix newMatrix = new Matrix(mat.Col, mat.Row);

        for (int i = 0; i < mat.Row; i++)
        {
            for (int j = 0; j < mat.Col; j++)
            {
                newMatrix.Value[j][i] = mat.Value[i][j];
            }
        }
        return newMatrix;
    }

    public static Matrix Opposite(Matrix mat)
    {
        Matrix newMatrix = Matrix.Copy(mat);

        for (int i = 0; i < mat.Row; i++)
        {
            for (int j = 0; j < mat.Col; j++)
            {
                newMatrix.Value[i][j] = mat.Value[i][j] * (-1);
            }
        }
        return newMatrix;
    }

    public static Matrix Zero(Matrix mat)
    {
        Matrix newMatrix = Matrix.Copy(mat);

        for (int i = 0; i < mat.Row; i++)
        {
            for (int j = 0; j < mat.Col; j++)
            {
                newMatrix.Value[i][j] = new Constant(0);
            }
        }
        return newMatrix;
    }

    public static Matrix Identity(Matrix mat)
    {
        if (!mat.IsSquare()) throw new Exception();

        Matrix newMatrix = Matrix.Copy(mat);

        for (int i = 0; i < mat.Row; i++)
        {
            for (int j = 0; j < mat.Col; j++)
            {
                if (i == j)
                    newMatrix.Value[i][j] = new Constant(1);
                else
                    newMatrix.Value[i][j] = new Constant(0);
            }
        }
        return newMatrix;
    }

    public bool IsSquare()
    {
        if (this.Col == this.Row)
            return true;
        else
            return false;
    }

    public bool IsIdentity()
    {
        if (!this.IsSquare()) return false;

        bool id = true;
        for (int i = 0; i < this.Row; i++)
        {
            for (int j = 0; j < this.Col; j++)
            {
                if ((i == j && this.Value[i][j] != new Constant(1)) || (i != j && this.Value[i][j] != new Constant(0)))
                {
                    id = false;
                    break;
                }
            }
        }
        return id;
    }
    public static Matrix Diagonal(Matrix mat)
    {
        if (!mat.IsSquare()) throw new Exception();

        Matrix newMatrix = Matrix.Copy(mat);

        for (int i = 0; i < mat.Row; i++)
        {
            for (int j = 0; j < mat.Col; j++)
            {
                if (i != j)
                    newMatrix.Value[i][j] = new Constant(0);
            }
        }
        return newMatrix;
    }

    public bool IsDiagonal()
    {
        if (!this.IsSquare()) return false;

        bool di = true;
        for (int i = 0; i < this.Row; i++)
        {
            for (int j = 0; j < this.Col; j++)
            {
                if (i != j && this.Value[i][j] != new Constant(0))
                {
                    di = false;
                    break;
                }
            }
        }
        return di;
    }

    public static Matrix Invertible(Matrix mat)
    {
        if (!mat.IsSquare()) throw new Exception();

        Function valor = mat.Value[0][0];

        for (int i = 0; i < mat.Row; i++)
        {
            for (int j = 0; j < mat.Col; j++)
            {
                if (i == j)
                {
                    mat.Value[i][j] = valor;
                }
            }
        }
        return mat;
    }

    public bool IsInvertible()
    {
        if (!this.IsSquare()) return false;

        var valor = this.Value[0][0];
        bool si = true;
        for (int i = 0; i < this.Row; i++)
        {
            for (int j = 0; j < this.Col; j++)
            {
                if (i == j)
                {
                    if (this.Value[i][j] != valor)
                    {
                        si = false;
                        break;
                    }
                }
            }
        }
        return si;
    }

    public bool IsSymmetric() => this == Matrix.Transpose(this);

    public bool IsAntiSymmetric() => Matrix.Transpose(this) == Matrix.Opposite(this);

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.Row != b.Row || a.Col != b.Col)
            throw new Exception();

        for (int i = 0; i < a.Row; i++)
        {
            for (int j = 0; j < a.Col; j++)
            {
                a.Value[i][j] += b.Value[i][j];
            }
        }
        return a;
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (a.Row != b.Row || a.Col != b.Col)
            throw new Exception();

        for (int i = 0; i < a.Row; i++)
        {
            for (int j = 0; j < a.Col; j++)
            {
                a.Value[i][j] -= b.Value[i][j];
            }
        }
        return a;
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.Col != b.Row)
            throw new Exception();
        Matrix multi = new Matrix(a.Row, b.Col);
        for (int i = 0; i < multi.Row; i++)
        {
            for (int j = 0; j < multi.Col; j++)
            {
                Function soma = new Constant(0);
                for (int k = 0; k < a.Row; k++)
                {
                    soma += a.Value[i][k] * b.Value[k][j];
                }
                multi.Value[i][j] = soma;
            }
        }
        return multi;
    }

    public static bool operator ==(Matrix a, Matrix b)
    {
        bool ig = true;
        if (a.Row != b.Row || a.Col != b.Col)
            return false;
        for (int i = 0; i < a.Row; i++)
        {
            for (int j = 0; j < a.Col; j++)
            {
                if (a.Value[i][j] != b.Value[i][j])
                    ig = false;
            }
        }
        return ig;
    }

    public static bool operator !=(Matrix a, Matrix b) => !(a == b);
    public static Matrix Copy(Matrix mat)
    {
        Matrix newMatrix = new Matrix(mat.Row, mat.Col);
        for (int i = 0; i < mat.Row; i++)
        {
            for (int j = 0; j < mat.Col; j++)
            {
                newMatrix.Value[i][j] = mat.Value[i][j];
            }
        }
        return newMatrix;
    }

    public static Matrix Random(Matrix mat)
    {
        Matrix newMatrix = Matrix.Copy(mat);

        for (int i = 0; i < mat.Row; i++)
        {
            for (int j = 0; j < mat.Col; j++)
            {
                Random rand = new Random();
                newMatrix.Value[i][j] = new Constant(rand.Next(1, 10));
            }
        }
        return newMatrix;
    }

    public Matrix get(double x)
    {
        Matrix newMatrix = Matrix.Copy(this);

        for (int i = 0; i < this.Row; i++)
        {
            for (int j = 0; j < this.Col; j++)
            {
                newMatrix.Value[i][j] = new Constant(this.Value[i][j][x]);
            }
        }
        return newMatrix;
    }

    public override string? ToString()
    {
        string matrix = "";
        for (int i = 0; i < this.Row; i++)
        {
            for (int j = 0; j < this.Col; j++)
            {
                matrix += $"{this.Value[i][j]} ";
            }
            matrix += "\n";
        }
        return matrix;
    }

    public IEnumerator<Function> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}