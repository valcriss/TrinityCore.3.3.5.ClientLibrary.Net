using TrinityCore._3._3._5.ClientLibrary.Map;

namespace TrinityCore._3._3._5.ClientLibrary.Pathfinding;

public class Path
{
    private static readonly int MaxClosePositionCounter = 4;
    private int _closePositionCounter;

    private Point _previousPosition;

    public Path(List<Point> points, float speed, int mapId)
    {
        if (points == null || points.Count < 2)
            throw new ArgumentException("Argument cannot be null or a list with just 1 point", "points");
        Points = points.ToArray();

        for (int index = 0; index < Points.Length; index++) Points[index] = new Point(Points[index].X, Points[index].Y, Points[index].Z);

        if (speed <= 0.0f)
            throw new ArgumentException("Argument must be a positive number", "speed");
        Speed = speed;

        CurrentPosition = Points[0];
        NextPointIndex = 1;
        MapId = mapId;
        _previousPosition = CurrentPosition;
        _closePositionCounter = 0;
    }

    public Point[] Points { get; set; }
    private int NextPointIndex { get; set; }

    public Point CurrentPosition { get; private set; }

    public float CurrentOrientation
    {
        get
        {
            if (NextPointIndex < Points.Length)
                return (Points[NextPointIndex] - CurrentPosition).DirectionOrientation;
            return (Points[NextPointIndex - 1] - Points[NextPointIndex - 2]).DirectionOrientation;
        }
    }

    public float Speed { get; set; }

    public int MapId { get; private set; }

    public Point Destination => Points.Last();

    public static float GetOrientation(float x1, float y1, float z1, float x2, float y2, float z2)
    {
        return (new Point(x2, y2, z2) - new Point(x1, y1, z1)).DirectionOrientation;
    }

    public Point MoveAlongPath(float deltaTime)
    {
        float totalDistance = deltaTime * Speed;

        if (Points.Length <= NextPointIndex) return Points[Points.Length - 1];

        float distanceToNextPoint = (Points[NextPointIndex] - CurrentPosition).Length;
        if (totalDistance < distanceToNextPoint)
        {
            Point result = CurrentPosition + (Points[NextPointIndex] - CurrentPosition).Direction * totalDistance;
            CurrentPosition = result;
        }
        else
        {
            NextPoint(totalDistance, distanceToNextPoint);
        }

        if ((CurrentPosition - _previousPosition).Length < 1f)
        {
            _closePositionCounter++;
            if (_closePositionCounter >= MaxClosePositionCounter)
            {
                _closePositionCounter = 0;
                NextPoint(totalDistance, distanceToNextPoint);
            }
        }
        else
        {
            _previousPosition = CurrentPosition;
            _closePositionCounter = 0;
        }

        return CurrentPosition;
    }

    private void NextPoint(float totalDistance, float distanceToNextPoint)
    {
        NextPointIndex++;
        if (NextPointIndex >= Points.Length - 1)
        {
            CurrentPosition = Points.Last();
        }
        else
        {
            float remainingTime = (totalDistance - distanceToNextPoint) / Speed;
            CurrentPosition = MoveAlongPath(remainingTime);
        }
    }
}