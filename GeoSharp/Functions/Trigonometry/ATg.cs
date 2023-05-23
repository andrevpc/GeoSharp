using System;

namespace GeoSharp.Functions.Trigonometry;

using static FunctionUtil;

public class ATg : Function
{
    private readonly Function inner;
    public ATg(Function inner)
      => this.inner = inner;

    protected override double get(double x)
      => Math.Atan(inner[x]);

    public override Function Derive()
      => inner.Derive() / (1 + (inner ^ 2));

    public override string ToString()
      => $"atg({inner})";
}