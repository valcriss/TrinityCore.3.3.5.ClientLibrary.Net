using TrinityCore._3._3._5.ClientLibrary.Shared.Math;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class Position
{
    public Position()
    {
    }

    public Position(float x, float y, float z, float o)
    {
        X = x;
        Y = y;
        Z = z;
        O = o;
    }


    public Position(Coord position, float orientation)
    {
        X = position.X;
        Y = position.Y;
        Z = position.Z;
        O = orientation;
    }

    public float Length => (float)Math.Sqrt(X * X + Y * Y + Z * Z);
    public float O { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }


    public Position Direction
    {
        get
        {
            float length = Length;
            Position point = new() { X = X / length, Y = Y / length, Z = Z / length, O = O };
            return point;
        }
    }

    public Coord Vector3 => new(X, Y, Z);


    public static Position operator -(Position a, Position b)
    {
        Position result = new(a.X - b.X, a.Y - b.Y, a.Z - b.Z, 0.0f);
        result.O = result.CalculateOrientation();

        return result;
    }

    public static Position operator *(Position point, float scale)
    {
        Position point1 = new() { X = point.X * scale, Y = point.Y * scale, Z = point.Z * scale };
        return point1;
    }

    public static Position operator +(Position a, Position b)
    {
        Position point = new() { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z };
        return point;
    }

    public override string ToString()
    {
        return "{X:" + X + ", Y:" + Y + ", Z:" + Z + ", O:" + O + "}";
    }


    private float CalculateOrientation()
    {
        double orientation;
        if (X == 0)
        {
            if (Y > 0)
                orientation = Math.PI / 2;
            else
                orientation = 3 * Math.PI / 2;
        }
        else if (Y == 0)
        {
            if (X > 0)
                orientation = 0;
            else
                orientation = Math.PI;
        }
        else
        {
            orientation = Math.Atan2(Y, X);
            if (orientation < 0)
                orientation += 2 * Math.PI;
        }

        return (float)orientation;
    }
}