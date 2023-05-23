using System;

namespace GeoSharp.Functions.Trigonometry;

using static FunctionUtil;

public class ACos : Function
{
    private readonly Function inner;
    public ACos(Function inner)
      => this.inner = inner;

    protected override double get(double x)
      => Math.Atan(-inner[x] / Math.Sqrt(-inner[x] * inner[x] + 1)) + 2 * Math.Atan(1);

    public override Function Derive()
      => -inner.Derive() / (2|(1-inner^2));

    public override string ToString()
      => $"acos({inner})";
}