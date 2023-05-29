using static GeoSharp.FunctionUtil;
using GeoSharp.Functions;
using GeoSharp;

////var f = sin(x) * sin(x) + cos(x) * cos(x);

//var f = -log(2, x);

//Console.WriteLine("f(x) = " + f + "\nf(10) = " + f[10]);
//f = f.Derive();
//Console.WriteLine("f(x) = " + f + "\nf(10) = " + f[10]);


// Console.WriteLine(Matriz.Transposta(matrix));

// Console.WriteLine(Matriz.Oposta(matrix));

// Console.WriteLine(Matriz.Nula(matrix));

// Console.WriteLine(Matriz.Identidade(matrix));
// Console.WriteLine(matrix.IsSquare());

// Console.WriteLine(matrix.IsIdentidade());
// matrix = Matriz.Identidade(matrix);
// Console.WriteLine(matrix);
// Console.WriteLine(matrix.IsIdentidade());

// Console.WriteLine(matrix.IsDiagonal());
// matrix = Matriz.Diagonal(matrix);
// Console.WriteLine(matrix);
// Console.WriteLine(matrix.IsDiagonal());

// Console.WriteLine(matrix.IsSingular());
// matrix = Matriz.Singular(matrix);
// Console.WriteLine(matrix);
// Console.WriteLine(matrix.IsSingular());

// Console.WriteLine(matrix.IsSimetrica());
// matrix = Matriz.Input();
// Console.WriteLine(matrix);
// Console.WriteLine(matrix.IsSimetrica());

// Console.WriteLine(matrix.IsAntiSimetrica());
// matrix = Matriz.Input();
// Console.WriteLine(matrix);
// Console.WriteLine(matrix.IsAntiSimetrica());

// Console.WriteLine(matrix + Matriz.Identidade(matrix));

// Console.WriteLine(matrix - Matriz.Identidade(matrix));

using GeoSharp.Functions.Matrix;

Function[][] mat = new Function[][] {
    new Function[] { sin(x), tg(x), cos(x) },
    new Function[] { new Constant(10), x, x },
    new Function[] { x, x, x }
};

Matrix matrix = new Matrix
{
    { sin(x), tg(x), cos(x) },
    { new Constant(10), x, x },
    { x, x, x }
};
Console.WriteLine(matrix);

Matrix matrix1 = Matrix.Random(matrix);
Console.WriteLine(matrix1);
Matrix result = matrix * matrix1;
Console.WriteLine(result);
Console.WriteLine(result[4]);