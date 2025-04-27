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

    public override string ToString()
    {
        return $"X:{X}, Y:{Y}, Z:{Z}";
    }
}