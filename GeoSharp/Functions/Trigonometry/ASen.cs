using System;

namespace GeoSharp.Functions.Trigonometry;

using static FunctionUtil;

public class ASen : Function
{
    private readonly Function inner;
    public ASen(Function inner)
      => this.inner = inner;

    protected override double get(double x)
      => Math.Atan(inner[x] / Math.Sqrt(-inner[x] * inner[x] + 1));

    public override Function Derive()
      => inner.Derive() / (2 | (1 - inner ^ 2));

    public override string ToString()
      => $"asen({inner})";
}