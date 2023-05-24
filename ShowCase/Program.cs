//using static GeoSharp.FunctionUtil;

////var f = sin(x) * sin(x) + cos(x) * cos(x);

//var f = -log(2, x);

//Console.WriteLine("f(x) = " + f + "\nf(10) = " + f[10]);
//f = f.Derive();
//Console.WriteLine("f(x) = " + f + "\nf(10) = " + f[10]);


using GeoSharp.Functions.Matriz;

Matriz matrix = new Matriz(3, 3);
matrix = Matriz.Aleatoria(matrix);
Console.WriteLine(matrix);

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

Matriz matrix1 = Matriz.Aleatoria(matrix);
Console.WriteLine(matrix1);
Console.WriteLine(matrix * matrix1);