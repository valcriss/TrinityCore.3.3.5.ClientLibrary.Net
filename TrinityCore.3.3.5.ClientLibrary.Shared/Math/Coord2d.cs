namespace TrinityCore._3._3._5.ClientLibrary.Shared.Math;

public class Coord2d
{
    public float X;
    public float Y;

    public Coord2d()
    {
        X = 0;
        Y = 0;
    }

    public Coord2d(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static float Distance(Coord2d a, Coord2d b)
    {
        return MathF.Sqrt(MathF.Pow(a.X - b.X, 2) + MathF.Pow(a.Y - b.Y, 2));
    }

    public static float DistanceSquared(Coord2d a, Coord2d b)
    {
        return MathF.Pow(a.X - b.X, 2) + MathF.Pow(a.Y - b.Y, 2);
    }

    public static Coord2d operator -(Coord2d a, Coord2d b)
    {
        return new Coord2d(a.X - b.X, a.Y - b.Y);
    }

    public static Coord2d operator +(Coord2d a, Coord2d b)
    {
        return new Coord2d(a.X + b.X, a.Y + b.Y);
    }

    public static Coord2d operator *(Coord2d a, float b)
    {
        return new Coord2d(a.X * b, a.Y * b);
    }

    public static Coord2d operator /(Coord2d a, float b)
    {
        return new Coord2d(a.X / b, a.Y / b);
    }

    public float Length()
    {
        return MathF.Sqrt(X * X + Y * Y);
    }

    public override string ToString()
    {
        return $"X:{X}, Y:{Y}";
    }
}