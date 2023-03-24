// ReSharper disable IdentifierTypo

using System;

#nullable enable

namespace Sevass;

public class Konsol
{
    public static void Skriv(string? t = "") => Console.Write(t);
    public static void Skriv(int? t = 0) => Console.Write(t);
    public static void Skriv(double? t = 0) => Console.Write(t);
    public static void Skriv(bool? t = false) => Console.Write(t);
    public static void Skriv(object? t = null) => Console.Write(t);
    public static void Skriv<T>(T? t = default) => Console.Write(t);

    public static void SkrivRad(string? t = "") => Console.WriteLine(t);
    public static void SkrivRad(int? t = 0) => Console.WriteLine(t);
    public static void SkrivRad(double? t = 0) => Console.WriteLine(t);
    public static void SkrivRad(bool? t = false) => Console.WriteLine(t);
    public static void SkrivRad(object? t = null) => Console.WriteLine(t);
    public static void SkrivRad<T>(T? t = default) => Console.WriteLine(t);


    public static string? LäsRad() => Console.ReadLine();
    public static ConsoleKeyInfo LäsTangent() => Console.ReadKey();
    public static int Läs() => Console.Read();
    
    public static void Rensa() => Console.Clear();
}

public class Konvertera
{
#pragma warning disable CS8604
#pragma warning disable CS8602
    public static int TillHel32(string? s) => int.Parse(s);
    public static double? TillDubbel(string? s) => double.Parse(s);
    public static bool? TillBool(string? s) => bool.Parse(s);
    public static char? TillTecken(string? s) => char.Parse(s);
    public static string? TillSträng(object? o) => o.ToString();
    public static string? TillBas64Sträng(byte[]? b) => Convert.ToBase64String(b);
#pragma warning restore CS8604
#pragma warning restore CS8602
}

#region Exceptions
public class ArgumentUndantag : ArgumentException
{
    public ArgumentUndantag(string? meddelande) : base(meddelande)
    {
    }
}

public class ArgumentNullUndantag : ArgumentNullException
{
    public ArgumentNullUndantag(string? meddelande) : base(meddelande)
    {
    }
}

public class ArgumentUtomRäckhållUndantag : ArgumentOutOfRangeException
{
    public ArgumentUtomRäckhållUndantag(string? meddelande) : base(meddelande)
    {
    }
}

public class IndexeringUtomRäckhållUndantag : SystemException
{
    public IndexeringUtomRäckhållUndantag(string? meddelande) : base(meddelande)
    {
    }
}

public class TomhetReferensUndantag : NullReferenceException
{
    public TomhetReferensUndantag(string? meddelande) : base(meddelande)
    {
    }
}

public class FormatUndantag : FormatException
{
    public FormatUndantag(string? meddelande) : base(meddelande)
    {
    }
}

#endregion

public class Matematik
{
    public static int Abs(int x) => Math.Abs(x);
    public static double Abs(double x) => Math.Abs(x);
    public static int Max(int x, int y) => Math.Max(x, y);
    public static double Max(double x, double y) => Math.Max(x, y);
    public static int Min(int x, int y) => Math.Min(x, y);
    public static double Min(double x, double y) => Math.Min(x, y);
    public static double Log(double x) => Math.Log(x);
    public static double Log10(double x) => Math.Log10(x);
    public static double Log(double x, double y) => Math.Log(x, y);
    public static double Kra(double x, double y) => Math.Pow(x, y);
    public static double Kvrt(double x) => Math.Sqrt(x);
    public static double Exp(double x) => Math.Exp(x);
    public static double Sin(double x) => Math.Sin(x);
    public static double Cos(double x) => Math.Cos(x);
    public static double Tan(double x) => Math.Tan(x);
    public static double Asin(double x) => Math.Asin(x);
    public static double Acos(double x) => Math.Acos(x);
    public static double Atan(double x) => Math.Atan(x);
    public static double Rund(double x) => Math.Round(x);
    public static double Rund(double x, int n) => Math.Round(x, n);
    public static double Rund(double x, MidpointRounding r) => Math.Round(x, r);
    public static double Rund(double x, int n, MidpointRounding r) => Math.Round(x, n, r);
    public static double Golv(double x) => Math.Floor(x);
    public static double Tak(double x) => Math.Ceiling(x);
    public static double Pi => Math.PI;
    public static double E => Math.E;
}

public class DatumTid
{
    public static DateTime Nu => DateTime.Now;
    public static DateTime Idag => DateTime.Today;
    public static int År => DateTime.Now.Year;
    public static int Månad => DateTime.Now.Month;
    public static int Dag => DateTime.Now.Day;
    public static int Timme => DateTime.Now.Hour;
    public static int Minut => DateTime.Now.Minute;
    public static int Sekund => DateTime.Now.Second;
    public static int Millisekund => DateTime.Now.Millisecond;
    public static int DagIÅret => DateTime.Now.DayOfYear;
    public static int DagIVeckan => (int) DateTime.Now.DayOfWeek;
}

public class Slump
{
    static readonly Random R = new Random();
    public static int Nästa() => R.Next();
    public static int Nästa(int max) => R.Next(max);
    public static int Nästa(int min, int max) => R.Next(min, max);
    public static double NästaDubbel() => R.NextDouble();
}