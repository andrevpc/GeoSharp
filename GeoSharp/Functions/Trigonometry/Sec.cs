using System;

namespace GeoSharp.Functions.Trigonometry;

using static FunctionUtil;

public class Sec : Function
{
    private readonly Function inner;
    public Sec(Function inner)
      => this.inner = inner;

    protected override double get(double x)
      => 1 / Math.Cos(inner[x]);

    public override Function Derive()
      => inner.Derive() * tg(inner) * sec(inner);

    public override string ToString()
      => $"sec({inner})";
}