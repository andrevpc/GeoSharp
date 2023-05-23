using System;

namespace GeoSharp.Functions.Trigonometry;

using static FunctionUtil;

public class Csc : Function
{
    private readonly Function inner;
    public Csc(Function inner)
      => this.inner = inner;

    protected override double get(double x)
      => 1 / Math.Sin(inner[x]);

    public override Function Derive()
      => -inner.Derive() * ctg(inner) * csc(inner);

    public override string ToString()
      => $"csc({inner})";
}