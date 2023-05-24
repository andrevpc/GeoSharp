using System;

namespace GeoSharp.Functions.Matriz;

public class Matriz
{
    public int Linha { get; set; }
    public int Coluna { get; set; }
    public int[][] Valores { get; set; }
    public Matriz(int row, int col)
    {
        this.Linha = row;
        this.Coluna = col;
        int[][] matrix = new int[this.Linha][];
        for (int i = 0; i < this.Linha; i++)
        {
            matrix[i] = new int[this.Coluna];
        }
        this.Valores = matrix;
    }

    public static Matriz Transposta(Matriz mat)
    {
        Matriz newMatrix = new Matriz(mat.Coluna, mat.Linha);

        for (int i = 0; i < mat.Linha; i++)
        {
            for (int j = 0; j < mat.Coluna; j++)
            {
                newMatrix.Valores[j][i] = mat.Valores[i][j];
            }
        }
        return newMatrix;
    }

    public static Matriz Oposta(Matriz mat)
    {
        Matriz newMatrix = Matriz.Copiar(mat);

        for (int i = 0; i < mat.Linha; i++)
        {
            for (int j = 0; j < mat.Coluna; j++)
            {
                newMatrix.Valores[i][j] = mat.Valores[i][j] * (-1);
            }
        }
        return newMatrix;
    }

    public static Matriz Nula(Matriz mat)
    {
        Matriz newMatrix = Matriz.Copiar(mat);

        for (int i = 0; i < mat.Linha; i++)
        {
            for (int j = 0; j < mat.Coluna; j++)
            {
                newMatrix.Valores[i][j] = 0;
            }
        }
        return newMatrix;
    }

    public static Matriz Identidade(Matriz mat)
    {
        if (!mat.IsSquare()) throw new Exception();

        Matriz newMatrix = Matriz.Copiar(mat);

        for (int i = 0; i < mat.Linha; i++)
        {
            for (int j = 0; j < mat.Coluna; j++)
            {
                if (i == j)
                    newMatrix.Valores[i][j] = 1;
                else
                    newMatrix.Valores[i][j] = 0;
            }
        }
        return newMatrix;
    }

    public bool IsSquare()
    {
        if (this.Coluna == this.Linha)
            return true;
        else
            return false;
    }

    public bool IsIdentidade()
    {
        if (!this.IsSquare()) return false;

        bool id = true;
        for (int i = 0; i < this.Linha; i++)
        {
            for (int j = 0; j < this.Coluna; j++)
            {
                if ((i == j && this.Valores[i][j] != 1) || (i != j && this.Valores[i][j] != 0))
                {
                    id = false;
                    break;
                }
            }
        }
        return id;
    }
    public static Matriz Diagonal(Matriz mat)
    {
        if (!mat.IsSquare()) throw new Exception();

        Matriz newMatrix = Matriz.Copiar(mat);

        for (int i = 0; i < mat.Linha; i++)
        {
            for (int j = 0; j < mat.Coluna; j++)
            {
                if (i != j)
                    newMatrix.Valores[i][j] = 0;
            }
        }
        return newMatrix;
    }

    public bool IsDiagonal()
    {
        if (!this.IsSquare()) return false;

        bool di = true;
        for (int i = 0; i < this.Linha; i++)
        {
            for (int j = 0; j < this.Coluna; j++)
            {
                if (i != j && this.Valores[i][j] != 0)
                {
                    di = false;
                    break;
                }
            }
        }
        return di;
    }

    public static Matriz Singular(Matriz mat)
    {
        if (!mat.IsSquare()) throw new Exception();

        int valor = mat.Valores[0][0];

        for (int i = 0; i < mat.Linha; i++)
        {
            for (int j = 0; j < mat.Coluna; j++)
            {
                if (i == j)
                {
                    mat.Valores[i][j] = valor;
                }
            }
        }
        return mat;
    }

    public bool IsSingular()
    {
        if (!this.IsSquare()) return false;

        var valor = this.Valores[0][0];
        bool si = true;
        for (int i = 0; i < this.Linha; i++)
        {
            for (int j = 0; j < this.Coluna; j++)
            {
                if (i == j)
                {
                    if (this.Valores[i][j] != valor)
                    {
                        si = false;
                        break;
                    }
                }
            }
        }
        return si;
    }

    public bool IsSimetrica() => this == Matriz.Transposta(this);

    public bool IsAntiSimetrica() => Matriz.Transposta(this) == Matriz.Oposta(this);

    public static Matriz operator +(Matriz a, Matriz b)
    {
        if (a.Linha != b.Linha || a.Coluna != b.Coluna)
            throw new Exception();

        for (int i = 0; i < a.Linha; i++)
        {
            for (int j = 0; j < a.Coluna; j++)
            {
                a.Valores[i][j] += b.Valores[i][j];
            }
        }
        return a;
    }

    public static Matriz operator -(Matriz a, Matriz b)
    {
        if (a.Linha != b.Linha || a.Coluna != b.Coluna)
            throw new Exception();

        for (int i = 0; i < a.Linha; i++)
        {
            for (int j = 0; j < a.Coluna; j++)
            {
                a.Valores[i][j] -= b.Valores[i][j];
            }
        }
        return a;
    }

    public static Matriz operator *(Matriz a, Matriz b)
    {
        if (a.Coluna != b.Linha)
            throw new Exception();
        Matriz multi = new Matriz(a.Linha, b.Coluna);
        for (int i = 0; i < multi.Linha; i++)
        {
            for (int j = 0; j < multi.Coluna; j++)
            {
                int soma = 0;
                for (int k = 0; k < a.Linha; k++)
                {
                    soma += a.Valores[i][k] * b.Valores[k][j];
                }
                multi.Valores[i][j] = soma;
            }
        }
        return multi;
    }

    public static bool operator ==(Matriz a, Matriz b)
    {
        bool ig = true;
        if (a.Linha != b.Linha || a.Coluna != b.Coluna)
            return false;
        for (int i = 0; i < a.Linha; i++)
        {
            for (int j = 0; j < a.Coluna; j++)
            {
                if (a.Valores[i][j] != b.Valores[i][j])
                    ig = false;
            }
        }
        return ig;
    }

    public static bool operator !=(Matriz a, Matriz b) => !(a == b);
    public static Matriz Copiar(Matriz mat)
    {
        Matriz newMatrix = new Matriz(mat.Linha, mat.Coluna);
        for (int i = 0; i < mat.Linha; i++)
        {
            for (int j = 0; j < mat.Coluna; j++)
            {
                newMatrix.Valores[i][j] = mat.Valores[i][j];
            }
        }
        return newMatrix;
    }

    public static Matriz Input()
    {
        Console.WriteLine($"Linhas: ");
        int linha = int.Parse(Console.ReadLine());
        Console.WriteLine($"Linhas: ");
        int coluna = int.Parse(Console.ReadLine());

        Matriz newMatrix = new Matriz(linha, coluna);

        for (int i = 0; i < linha; i++)
        {
            for (int j = 0; j < linha; j++)
            {
                Console.WriteLine($"i = {i} j = {j}");
                int inp = int.Parse(Console.ReadLine());
                newMatrix.Valores[i][j] = inp;
            }
        }
        return newMatrix;
    }

    public static Matriz Aleatoria(Matriz mat)
    {
        Matriz newMatrix = Matriz.Copiar(mat);

        for (int i = 0; i < mat.Linha; i++)
        {
            for (int j = 0; j < mat.Coluna; j++)
            {
                Random rand = new Random();
                newMatrix.Valores[i][j] = rand.Next(1, 10);
            }
        }
        return newMatrix;
    }

    public override string? ToString()
    {
        string matrix = "";
        for (int i = 0; i < this.Linha; i++)
        {
            for (int j = 0; j < this.Coluna; j++)
            {
                matrix += $"{this.Valores[i][j]} ";
            }
            matrix += "\n";
        }
        return matrix;
    }
}