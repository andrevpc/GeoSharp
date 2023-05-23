using System;

namespace GeoSharp.Functions.Trigonometry;

using static FunctionUtil;

public class Cos : Function
{
  private readonly Function inner;
  public Cos(Function inner)
    => this.inner = inner;
  
  protected override double get(double x) 
    => Math.Cos(inner[x]);
  
  public override Function Derive()
    => inner.Derive() * (-sin(inner));
  
  public override string ToString() 
    => $"cos({inner})";
}