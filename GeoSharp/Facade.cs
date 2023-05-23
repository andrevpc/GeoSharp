using System;

namespace GeoSharp;

using Functions;
using GeoSharp.Functions.Trigonometry;
using GeoSharp.Operations;

public static class FunctionUtil
{
    #region linear
    private static Linear linear = null;
    public static Function x
    {
        get
        {
            if (linear is null)
                linear = new Linear();

            return linear;
        }
    }
    #endregion

    #region euler
    private static Constant euler = null;
    public static Function e
    {
        get
        {
            if (euler is null)
                euler = new Constant(Math.E);

            return euler;
        }
    }
    #endregion

    #region pi
    private static Constant p = null;
    public static Function pi
    {
        get
        {
            if (p is null)
                p = new Constant(Math.PI);

            return p;
        }
    }
    #endregion

    #region Trigonometry

    #region sen
    public static Function sin(Function f)
      => new Sin(f);
    public static Function sin(double f)
      => new Sin(new Constant(f));
    #endregion

    #region cos
    public static Function cos(Function f)
      => new Cos(f);
    public static Function cos(double f)
      => new Cos(new Constant(f));
    #endregion

    #region tg
    public static Function tg(Function f)
      => new Tg(f);
    public static Function tg(double f)
      => new Tg(new Constant(f));
    #endregion

    #region ctg
    public static Function ctg(Function f)
      => new Ctg(f);
    public static Function ctg(double f)
      => new Ctg(new Constant(f));
    #endregion

    #region sec
    public static Function sec(Function f)
      => new Sec(f);
    public static Function sec(double f)
      => new Sec(new Constant(f));
    #endregion

    #region csc
    public static Function csc(Function f)
      => new Csc(f);
    public static Function csc(double f)
      => new Csc(new Constant(f));
    #endregion

    #region asen
    public static Function asen(Function f)
      => new ASen(f);
    public static Function asen(double f)
      => new ASen(new Constant(f));
    #endregion

    #region acos
    public static Function acos(Function f)
      => new ACos(f);
    public static Function acos(double f)
      => new ACos(new Constant(f));
    #endregion

    #region atg
    public static Function atg(Function f)
      => new ATg(f);
    public static Function atg(double f)
      => new ATg(new Constant(f));
    #endregion

    #endregion

    #region pow
    public static Function pow(Function f, Function g)
    => new Pow(f, g);
    public static Function pow(Function f, double g)
      => new Pow(f, new Constant(g));
    public static Function pow(double f, Function g)
      => new Pow(new Constant(f), g);
    public static Function pow(double f, double g)
      => new Pow(new Constant(f), new Constant(g));
    #endregion

    #region log
    public static Function log(Function f, Function g)
      => new Log(f, g);
    public static Function log(Function f, double g)
      => new Log(f, new Constant(g));
    public static Function log(double f, Function g)
      => new Log(new Constant(f), g);
    public static Function log(double f, double g)
      => new Log(new Constant(f), new Constant(g));
    #endregion

    #region ln
    public static Function ln(Function f)
      => new Ln(f);
    public static Function ln(double f)
      => new Ln(new Constant(f));
    #endregion

}