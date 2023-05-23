using System;

namespace GeoSharp.Functions.Trigonometry;

using static FunctionUtil;

public class Ctg : Function
{
    private readonly Function inner;
    public Ctg(Function inner)
      => this.inner = inner;

    protected override double get(double x)
      => 1 / Math.Tan(inner[x]);

    public override Function Derive()
      => -(inner.Derive() * csc(inner)^2);

    public override string ToString()
      => $"ctg({inner})";
}