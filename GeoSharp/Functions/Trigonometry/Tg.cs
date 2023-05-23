using System;

namespace GeoSharp.Functions.Trigonometry;

using static FunctionUtil;

public class Tg : Function
{
    private readonly Function inner;
    public Tg(Function inner)
      => this.inner = inner;

    protected override double get(double x)
      => Math.Tan(inner[x]);

    public override Function Derive()
      => inner.Derive() * (sec(inner) ^ 2);

    public override string ToString()
      => $"tg({inner})";
}