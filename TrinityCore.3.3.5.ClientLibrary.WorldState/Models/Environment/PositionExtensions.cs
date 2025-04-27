namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public static class PositionExtensions
{
    public static float GetPathLength(this Position[] positions)
    {
        float total = 0;
        for (int i = 0; i < positions.Length - 1; i++)
        {
            Position p1 = positions[i];
            Position p2 = positions[i + 1];
            total += (p2 - p1).Length;
        }

        return total;
    }
}