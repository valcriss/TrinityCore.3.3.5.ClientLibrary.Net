using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class MovementSpline
{
    public MovementSpline()
    {
        SplineStart = DateTime.Now;
    }

    public int Duration { get; set; }
    public int EffectStartTime { get; set; }
    public float? FacingAngle { get; set; }
    public float? FacingTarget { get; set; }
    public Position FinalDestination { get; set; }
    public Position FinalPosition { get; set; }
    public SplineEvaluationMode SplineEvaluationMode { get; set; }
    public SplineTypes? SplineFlags { get; set; }
    public uint SplineId { get; set; }
    public Position[] SplineNodes { get; set; }
    public int TimePassed { get; set; }
    public float VerticalAcceleration { get; set; }


    private DateTime SplineStart { get; }


    public Position CurrentPosition(float speed)
    {
        float totalTimePassed = (float)DateTime.Now.Subtract(SplineStart).TotalMilliseconds + TimePassed;
        float totalDistanceDone = speed * totalTimePassed;
        float loopLength = SplineNodes.GetPathLength();
        int loopsDone = (int)Math.Floor(totalDistanceDone / loopLength);

        float distanceDoneInPath = totalDistanceDone - loopsDone * loopLength;

        for (int i = 0; i < SplineNodes.Length; i++)
        {
            Position node1 = SplineNodes[i];
            Position nextNode = i == SplineNodes.Length - 1 ? SplineNodes[0] : SplineNodes[i + 1];
            float nodesDistance = (nextNode - node1).Length;
            if (distanceDoneInPath <= nodesDistance)
            {
                // I am between this 2 points
                Position result = node1 + (nextNode - node1).Direction * distanceDoneInPath;
                return result;
            }

            distanceDoneInPath -= nodesDistance;
        }

        return FinalDestination;
    }
}