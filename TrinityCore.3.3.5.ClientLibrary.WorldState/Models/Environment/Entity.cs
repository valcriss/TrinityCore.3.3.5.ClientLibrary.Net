using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class Entity
{
    public ulong Guid { get; set; }
    public TypeId ObjectType { get; set; }

    public Dictionary<UpdateFields, uint> Values { get; set; } = new();

    public MovementInfo Movement { get; set; } = new();

    public MonsterMoveData? MonsterMoveData { get; set; }

    public void UpdateValues(Dictionary<UpdateFields, uint> values)
    {
        foreach (KeyValuePair<UpdateFields, uint> pair in values)
            if (!Values.ContainsKey(pair.Key))
                Values.Add(pair.Key, pair.Value);
            else
                Values[pair.Key] = pair.Value;
    }

    public void UpdateMovement(MovementInfo movement)
    {
        if (movement.MovementLiving != null)
        {
            Movement.MovementLiving = movement.MovementLiving;
            Movement.MovementLiving.Position = null;
        }

        if (movement.MovementPosition != null)
        {
            Movement.MovementPosition = movement.MovementPosition;
            Movement.MovementPosition.TransportGuid = movement.MovementPosition.TransportGuid;
            Movement.MovementPosition.Position = movement.MovementPosition.Position;
            Movement.MovementPosition.TransportPosition = movement.MovementPosition.TransportPosition;
            Movement.MovementPosition.Position = null;
        }

        if (movement.MovementStationary != null)
            Movement.MovementStationary = movement.MovementStationary;
        if (movement.MovementHasTarget != null)
            Movement.MovementHasTarget = movement.MovementHasTarget;
        if (movement.MovementRotation != null)
            Movement.MovementRotation = movement.MovementRotation;
    }

    public void UpdateMove(MonsterMoveData monsterMoveData)
    {
        MonsterMoveData = monsterMoveData;
    }
}