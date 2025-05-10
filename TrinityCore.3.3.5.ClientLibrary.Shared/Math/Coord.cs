namespace TrinityCore._3._3._5.ClientLibrary.Shared.Math;

public struct Coord
{
    public float X;
    public float Y;
    public float Z;

    public Coord()
    {
        X = 0;
        Y = 0;
        Z = 0;
    }

    public Coord(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static float Distance(Coord a, Coord b)
    {
        return MathF.Sqrt(MathF.Pow(a.X - b.X, 2) + MathF.Pow(a.Y - b.Y, 2) + MathF.Pow(a.Z - b.Z, 2));
    }

    public static float DistanceSquared(Coord a, Coord b)
    {
        return MathF.Pow(a.X - b.X, 2) + MathF.Pow(a.Y - b.Y, 2) + MathF.Pow(a.Z - b.Z, 2);
    }

    public static Coord operator -(Coord a, Coord b)
    {
        return new Coord(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Coord operator +(Coord a, Coord b)
    {
        return new Coord(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Coord operator *(Coord a, float b)
    {
        return new Coord(a.X * b, a.Y * b, a.Z * b);
    }

    public static Coord operator /(Coord a, float b)
    {
        return new Coord(a.X / b, a.Y / b, a.Z / b);
    }

    public float Length()
    {
        return MathF.Sqrt(X * X + Y * Y + Z * Z);
    }

    public override string ToString()
    {
        return $"X:{X}, Y:{Y}, Z:{Z}";
    }
}