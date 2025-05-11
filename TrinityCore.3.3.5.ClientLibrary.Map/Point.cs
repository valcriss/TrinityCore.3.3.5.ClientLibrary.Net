namespace TrinityCore._3._3._5.ClientLibrary.Map;

public class Point
{
    public readonly float X;
    public readonly float Y;
    public readonly float Z;

    public Point(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public float Length => (float)Math.Sqrt(X * X + Y * Y + Z * Z);

    public Point Direction
    {
        get
        {
            float length = Length;
            return new Point(X / length, Y / length, Z / length);
        }
    }

    public float DirectionOrientation
    {
        get
        {
            Point dir = Direction;
            double orientation = Math.Atan2(dir.Y, dir.X);
            if (orientation < 0) orientation += 2.0 * Math.PI;
            return (float)orientation;
        }
    }

    public static Point operator +(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Point operator -(Point a, Point b)
    {
        return new Point(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Point operator *(Point point, float scale)
    {
        return new Point(point.X * scale, point.Y * scale, point.Z * scale);
    }

    public static bool operator ==(Point a, Point b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(Point a, Point b)
    {
        return !a.Equals(b);
    }

    public override string ToString()
    {
        return "X: " + X + " | Y: " + Y + " | Z: " + Z;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Point)obj);
    }

    public static double Distance(Point a, Point b)
    {
        return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.Z - b.Z, 2));
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }
}